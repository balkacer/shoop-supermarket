using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shoopsupermarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Configuration;
using shoopsupermarket.Data;
using Microsoft.EntityFrameworkCore;

namespace shoopsupermarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public ActionResult Index()
        {
            return View(new Articulo());
        }

        [HttpGet]
        [Route("/{action}")]
        public async Task<IActionResult> Search(string q, string c)
        {
            ViewData["Desc"] = q;

            var articulos = from s in _context.Articulos select s;
            var categorias = from s in _context.Categorias select s;

            int PassId = 0;

            foreach (var item in categorias)
            {
                if (item.CAT == c)
                {
                    PassId = item.ID;
                }
            }

            if (!String.IsNullOrEmpty(c))
            {
                if(c == "Bebida")
                {
                    articulos = articulos.Where(s => s.CAT_ID == PassId);
                } 
                    
                else if(c == "Comida")
                {
                    articulos = articulos.Where(s => s.CAT_ID == PassId);
                }
            }

            if (!String.IsNullOrEmpty(q))
            {
                articulos = articulos.Where(s => s.DESC.Contains(q));
            }

            articulos = articulos.OrderBy(s => s.DESC);

            return View(await articulos.AsNoTracking().ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
