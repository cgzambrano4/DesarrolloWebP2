using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AlquilerVehiculoP2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //Agreagdo César - si no esta autenticado e intenta acceder a una pagina, no podra acceder
        protected void Application_EndRequest()
        {
            if (Response.StatusCode == 401)
            {
                Response.ClearContent();
                Response.RedirectToRoute("AccessDenied");
            }
        }

    }
}
