using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shoopsupermarket.Data;
using shoopsupermarket.Models;
using Stripe;
using Stripe.Checkout;

namespace shoopsupermarket.Controllers
{
    [Route("Pago")]
    [ApiController]
    public class StripeController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult Index(int id)
        {
            //var pedido = _context.Pedidos.Find(id);
            return View();
        } 

        [HttpPost]
        public IActionResult Index(PaymentIntentCreateRequest request)
        {
            StripeConfiguration.ApiKey = "sk_test_51HAmjTDeFU75Q4GnHtJZKBfKpHBbMrpzdpImMYDXWl9A2sHOItIUeEbJcLwFKGq04NhknQiOsHgpzptD4zuipXFK00Ds6cFC0K";

            var paymentIntents = new PaymentIntentService();
            var paymentIntent = paymentIntents.Create(new PaymentIntentCreateOptions
            {
                Amount =  CalculateOrderAmount(request.Items),
                Currency = "usd",
            });

            return Json(new { clientSecret = paymentIntent.ClientSecret });
        }

        private int CalculateOrderAmount(Item[] items)
        {   
            return 1400;
        }

        /* private int Conversion(double dop){

            double usd = 0.017;
            dop = dop * usd;
            string tostal = dop.ToString();
            tostal = tostal.Trim().Replace(".","");

            int totall = int.Parse(tostal);
             Console.WriteLine(totall);
            return totall;
        } */
    }
}