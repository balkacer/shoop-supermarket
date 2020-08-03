using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shoopsupermarket.Data;
using shoopsupermarket.Models;

namespace shoopsupermarket.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarritoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        // private List<DetallePedido> product;
        // public List<DetallePedido> Product { get => _context.DetallePedidos.ToList(); set => product = value; }

        // Session["cart"] = Product;

        // public ActionResult AddToCart(int Id)
        // {
        //     if (Session["cart"] == null)
        //     {
        //         List<Item> cart = new List<Item>();
        //         var product = _context.Articulos.Find(Id);
        //         cart.Add(new Item()
        //         {
        //             Product = product,
        //             Quantity = 1
        //         });
        //         Session["cart"] = cart;
        //     }
        //     else
        //     {
        //         List<Item> cart = (List<Item>)Session["cart"];
        //         var product = ctx.Tbl_Product.Find(Id);
        //         cart.Add(new Item()
        //         {
        //             Product = product,
        //             Quantity = 1
        //         });
        //         Session["cart"] = cart;
        //     }
        //     return Redirect("Index");
        // }
    }
}