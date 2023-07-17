/*
 * Como primera parte se agrega un controlador que será el encargado de agreagr las vistas para el
 * inicio de sesión y esta será la primera pagina en cargarse
 */

using AlquilerVehiculoP2.Filters;
using AlquilerVehiculoP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AlquilerVehiculoP2.Controllers
{
    public class AccountController : Controller
    {
        [RedirectToHomeIfAuthenticated] //Agregado
        // GET: /Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Home");
            }

            if (IsValidUser(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return RedirectToAction("Dashboard", "Home"); // Redirige al usuario a la página de inicio después de iniciar sesión
            }
            else
            {
                ModelState.AddModelError("", "El nombre de usuario o la contraseña son incorrectos.");
                return View();
            }
        }

        // GET: /Account/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }


        private bool IsValidUser(string username, string password)
        {
            using (var db = new alquilervehiculosEntities())
            {
                var user = db.usuarios.FirstOrDefault(u => u.username == username);

                if (user != null)
                {
                    // Aquí puedes comparar la contraseña proporcionada con la contraseña almacenada en la base de datos
                    // Asegúrate de aplicar la lógica de encriptación/hashing adecuada en tu aplicación
                    if (user.password == password)
                    {
                        return true; // Las credenciales son válidas
                    }
                }

                return false; // Las credenciales son inválidas o el usuario no existe
            }
        }

    }
}