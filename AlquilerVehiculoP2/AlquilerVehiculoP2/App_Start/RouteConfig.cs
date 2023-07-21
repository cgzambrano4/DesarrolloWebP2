using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AlquilerVehiculoP2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",

                //Agregado muestra la pagina inicial por defecto
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional } 
            );

            //Agregado César
            routes.MapRoute(
                name: "AccessDenied",
                url: "AccessDenied",
                defaults: new { controller = "Error", action = "AccessDenied" }
            );

            //Agregado César
            routes.MapRoute(
                name: "Dashboard",
                url: "Dashboard",
                defaults: new { controller = "Home", action = "Dashboard" }
            );

            //Agregado Raquel
            routes.MapRoute(
                name: "Auto",
                url: "Auto",
                defaults: new { controller = "Auto", action = "Index" }
            );

            //Agregado Andrick
            routes.MapRoute(
                name: "Facturas",
                url: "Facturas",
                defaults: new { controller = "Factura", action = "Index" }
            );

            //Agregado Danny
            routes.MapRoute(
                name: "Empleados",
                url: "Empleados",
                defaults: new { controller = "Empleado", action = "Index" }
            );
        }
    }
}
