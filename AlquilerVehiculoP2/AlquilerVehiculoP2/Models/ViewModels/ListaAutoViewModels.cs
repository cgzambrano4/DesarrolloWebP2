using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;


namespace AlquilerVehiculoP2.Models.ViewModels
{
    //Raquel
    public class ListaAutoViewModel
    {
        public int Id_Vehiculos { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Tipo { get; set; }
        public string Disponibilidad { get; set; }
        public string img_cli { get; set; }
    }
}