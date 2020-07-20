using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace shoopsupermarket.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        public string Rol { get; set; }
    }
}