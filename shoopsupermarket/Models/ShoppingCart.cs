using System;
using System.Collections.Generic;
using System.Linq;
using shoopsupermarket.Data;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace shoopsupermarket.Models
{
    public partial class ShoppingCart
    {
        ApplicationDbContext context1 = new ApplicationDbContext();
        [Key]
        public string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart(HttpContext context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(Articulo articulo)
        {
            // Get the matching cart and Articulo instances
            var cartItem = context1.Carts.SingleOrDefault(
                c => c.CartId == ShoppingCartId 
                && c.ArticuloId == articulo.ID);
 
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Cart
                {
                    ArticuloId = articulo.ID,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                context1.Carts.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.Count++;
            }
            // Save changes
            context1.SaveChanges();
        }
        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = context1.Carts.Single(
                cart => cart.CartId == ShoppingCartId 
                && cart.RecordId == id);
 
            int itemCount = 0;
 
            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    context1.Carts.Remove(cartItem);
                }
                // Save changes
                context1.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = context1.Carts.Where(
                cart => cart.CartId == ShoppingCartId);
 
            foreach (var cartItem in cartItems)
            {
                context1.Carts.Remove(cartItem);
            }
            // Save changes
            context1.SaveChanges();
        }
        public List<Cart> GetCartItems()
        {
            return context1.Carts.Where(
                cart => cart.CartId == ShoppingCartId).ToList();
        }
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in context1.Carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            // Multiply Articulo price by count of that Articulo to get 
            // the current price for each of those Articulos in the cart
            // sum all Articulo price totals to get the cart total
            decimal? total = (from cartItems in context1.Carts
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count *
                              cartItems.Articulo.PRE_VENT).Sum();

            return total ?? decimal.Zero;
        }
        public int CreateOrder(Pedido pedido)
        {
            decimal orderTotal = 0;
 
            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new DetallePedido
                {
                    ART_ID = item.ArticuloId,
                    ORD_ID = pedido.ID,
                    PRE_UNIT = item.Articulo.PRE_VENT,
                    CANT = item.Count
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Articulo.PRE_VENT);
 
                context1.DetallePedidos.Add(orderDetail);
 
            }
            // Set the order's total to the orderTotal count
            pedido.Total = orderTotal;
 
            // Save the order
            context1.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return pedido.ID;
        }
        // We're using HttpContext to allow access to cookies.
        public string GetCartId(HttpContext context)
        {
            if (context.Session.GetString(CartSessionKey) == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session.SetString(CartSessionKey, context.User.Identity.Name);
                }
                else
                {
                    var tempCartId = Guid.NewGuid();
                    context.Session.SetString(CartSessionKey, tempCartId.ToString());
                }
            }

            return context.Session.GetString(CartSessionKey);
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = context1.Carts.Where(
                c => c.CartId == ShoppingCartId);
 
            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }
            context1.SaveChanges();
        }
    }
}