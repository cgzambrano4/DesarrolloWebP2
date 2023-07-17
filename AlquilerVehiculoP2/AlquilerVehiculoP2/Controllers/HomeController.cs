using AlquilerVehiculoP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlquilerVehiculoP2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Agregado
        [Authorize] // Asegura que solo los usuarios autenticados puedan acceder al dashboard
        public ActionResult Dashboard()
        {
            // Aquí puedes obtener los datos necesarios para el dashboard, como las facturas
            // y pasarlos a la vista para su visualización
            var facturas = ObtenerFacturas();

            return View(facturas);
        }

        private List<facturas> ObtenerFacturas()
        {
            // Aquí debes implementar la lógica para obtener las facturas de tu base de datos
            // Puedes utilizar tu modelo de entidad de datos para consultar la tabla "Facturas"

            using (var db = new alquilervehiculosEntities())
            {
                return db.facturas.ToList();
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}