/*
 * Como primera parte se agrega un controlador que será el encargado de agreagr las vistas para el
 * inicio de sesión y esta será la primera pagina en cargarse
 */

using AlquilerVehiculoP2.Filters; //Agregado César se llama al filtro
using AlquilerVehiculoP2.Models;  //Agregado César se llama al modelo

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
        [RedirectToHomeIfAuthenticated] //Agregado César control de inicio de sesión
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

                //Agregado César - Redirige al usuario a la página de inicio después de iniciar sesión
                return RedirectToAction("Dashboard", "Home"); 
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

            //Agregado César - Cierra la sesión y redirige nuevamente al login
            return RedirectToAction("Login", "Account");
        }

        //Agregado César - Metodo que compara las credenciales ingresadas con las que existe en la DB
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