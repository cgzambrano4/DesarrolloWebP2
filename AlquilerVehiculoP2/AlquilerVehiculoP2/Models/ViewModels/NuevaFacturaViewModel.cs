using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlquilerVehiculoP2.Models.ViewModels
{
    public class NuevaFacturaViewModel
    {
        public FacturaViewModel FacturaModel { get; set; }

        public SelectList SelectListVehiculos { get; set; }

        public SelectList SelectListEmpleados { get; set; }

        public string MarcaVehiculoSeleccionado { get; set; }
    }
}