/**
 * Agregado los filtros para controlar que no ingrese al login despues de iniciar sesion
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlquilerVehiculoP2.Filters
{
    public class RedirectToHomeIfAuthenticatedAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary {
                        { "controller", "Home" },
                        { "action", "Dashboard" }
                    });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}