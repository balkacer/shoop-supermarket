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
        public int    ID   { get; set; }
        public string Username   { get; set; }
        public string FirstName  { get; set; }
        public string LastName   { get; set; }
        public string Address    { get; set; }
        public string City       { get; set; }
        public string State      { get; set; }
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }
        public string Country    { get; set; }
        public string Phone      { get; set; }
        public decimal Total     { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
        public System.DateTime OrderDate      { get; set; }
        public List<DetallePedido> DetallePedidos { get; set; }
    }
}
    //     public double SubtotalSum(){
    //         using(var db = new ApplicationDbContext()){
    //             var pr = db.DetallePedidos.Where(dp => dp.ORD_ID == ID).ToList();
    //             double totalSuma = 0;
    //             foreach (var item in pr)
    //             {
    //                 totalSuma += item.SUB_TOTAL;
    //             }
    //             return totalSuma;
    //         }            
    //     }