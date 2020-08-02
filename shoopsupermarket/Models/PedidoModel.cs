using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using shoopsupermarket.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace shoopsupermarket.Models
{
    public class Pedido
    {
        private readonly PageModel _page;
        public int ID { get; set; }
        private string _CLI_ID;
        public string CLI_ID
        {
            get { return _CLI_ID;}
            set { _CLI_ID = _userManager.GetUserId(_page.User);}
        }        
        private readonly UserManager<IdentityUser> _userManager;
        public Pedido(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        private DateTime _FECH_ORD;
        private DateTime _FECH_ENV;

        [Display(Name = "Estado")]
        [Required (ErrorMessage = "¡Este campo es requerido!")]
        public int EST_ID { get; set; }
        [Display(Name = "Estado")]
        public virtual Estado ESTADO { get; set; }
        public string NOM_CLI { get; set; }
        private string _CLIENTE;
        public string CLIENTE
        {
            get { return _CLIENTE;}
            set { _CLIENTE = _userManager.GetUserName(_page.User);}
        }
        private IdentityUser user;
        public string EMAIL { get; set; }
        private async Task GetUserEmail (){
            string mail = await _userManager.GetEmailAsync(user);
            EMAIL = mail;
        }
        public decimal LONG { get; set; }
        public decimal LAT { get; set; }
        public string COMENT { get; set; }
        private double _TOTAL;
        public double TOTAL
        {
            get { return _TOTAL = SubtotalSum();}
            set 
            { 
                _TOTAL = value;
            }
        }

        public double SubtotalSum(){
            using(var db = new ApplicationDbContext()){
                var pr = db.DetallePedidos.Where(dp => dp.ORD_ID == ID).ToList();
                double totalSuma = 0;
                foreach (var item in pr)
                {
                    totalSuma += item.SUB_TOTAL;
                }
                return totalSuma;
            }            
        }
        public virtual ICollection<DetallePedido> Articulos {get;set;}

        [Display(Name = "Fecha de orden")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd mm yyy hh:mm:ss}")]
        public DateTime FECH_ORD { 
            get{ return _FECH_ORD; } 
            set{ _FECH_ORD = DateTime.Now; }
        }
    }
}