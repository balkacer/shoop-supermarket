using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace shoopsupermarket.Models.Login
{
    public class Login
    {
        [Display(Name="E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Dirección de correo invalida!")]
        public string EMAIL { get; set; }
        [Display(Name="Contraseña")]
        [DataType(DataType.Password)]
        public string PASSWORD { get; set; }
    }
}