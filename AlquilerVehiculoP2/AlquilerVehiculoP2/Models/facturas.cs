//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlquilerVehiculoP2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class facturas
    {
        public int Id_Facturas { get; set; }
        public int Id_Empleados { get; set; }
        public int Id_Vehiculos { get; set; }
        public string NombreCliente { get; set; }
        public string CedulaCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public System.DateTime FechaAlquiler { get; set; }
        public System.DateTime FechaDevolucion { get; set; }
        public double PrecioAlquilerDia { get; set; }
        public double AbonoAlquiler { get; set; }
        public Nullable<double> TotalAlquiler { get; set; }
    
        public virtual empleados empleados { get; set; }
        public virtual vehiculos vehiculos { get; set; }
    }
}
