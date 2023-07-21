using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AlquilerVehiculoP2.Models.ViewModels
{
    public class FacturaViewModel
    {
        public int Id_Facturas { get; set; }
        public int Id_Vehiculos { get; set; }
        public int Id_Empleados { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        [StringLength(50)]
        public string NombreCliente { get; set; }

        [Required]
        [Display(Name = "Cedula")]
        [StringLength(10)]
        public string CedulaCliente { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        [StringLength(100)]
        public string DireccionCliente { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        [StringLength(10)]
        public string TelefonoCliente { get; set; }

        [Required]
        [Display(Name = "Fecha del Alquiler")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaAlquiler { get; set; }

        [Required]
        [Display(Name = "Fecha devolución")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaDevolucion { get; set; }

        [Required]
        [Display(Name = "Precio de alquiler diario")]
        public double PrecioAlquilerDia { get; set; }

        [Required]
        [Display(Name = "Abono del Alquiler")]
        public double AbonoAlquiler { get; set; }

        public double TotalAlquiler { get; set; }
    }
}