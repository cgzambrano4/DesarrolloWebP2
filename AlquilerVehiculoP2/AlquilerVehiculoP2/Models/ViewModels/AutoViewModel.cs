using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AlquilerVehiculoP2.Models.ViewModels
{
    //Raquel
    public class AutoViewModel
    {
        public int Id_Vehiculos { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Required]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Required]
        [Display(Name = "Año")]
        public int Anio { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [Required]
        [Display(Name = "Disponibilidad")]
        public string Disponibilidad { get; set; }

        [Display(Name = "Imagen de Auto")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase img_cli { get; set; }//imagen agregada
    }
}