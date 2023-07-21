using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlquilerVehiculoP2.Models.ViewModels
{
    public class ListaFacturaViewModel
    {
        public int Id_Facturas { get; set; }
        public string NombreCliente { get; set; }
        public string CedulaCliente { get; set; }
        public DateTime? FechaAlquiler { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public double PrecioAlquilerDia { get; set; }
        public double AbonoAlquiler { get; set; }
        public double TotalAlquiler { get; set; }
        public SelectList SelectListVehiculos { get; internal set; }
    }
}