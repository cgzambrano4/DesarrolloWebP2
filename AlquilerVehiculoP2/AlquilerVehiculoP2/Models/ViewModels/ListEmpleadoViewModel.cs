using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVehiculoP2.Models.ViewModels
{
    public class ListEmpleadoViewModel
    {
        public int Id_Empleados { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime? FechaContrato { get; set; }
    }
}