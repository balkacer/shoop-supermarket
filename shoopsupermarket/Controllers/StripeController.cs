using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(PaymentIntentCreateRequest request)
        {
            var paymentIntents = new PaymentIntentService();
            var paymentIntent = paymentIntents.Create(new PaymentIntentCreateOptions
            {
                Amount = CalculateOrderAmount(request.Items),
                Currency = "usd",
                Metadata = new Dictionary<string, string>
                {
                    {"Manzana", "$10"} 
                    
                },
                ReceiptEmail = "medranomendezalex@gmail.com",
            });

            return Json(new { clientSecret = paymentIntent.ClientSecret });
        }

        private int CalculateOrderAmount(Item[] items)
        {   
            return 1400;
        }
    }
}