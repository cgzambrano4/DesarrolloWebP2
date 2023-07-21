using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AlquilerVehiculoP2.Models;
using AlquilerVehiculoP2.Models.ViewModels;

namespace AlquilerVehiculoP2.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Cliente
        [Authorize]
        public ActionResult Index()
        {
            List<ListEmpleadoViewModel> lst;
            using (alquilervehiculosEntities db = new alquilervehiculosEntities())
            {
                lst = (from c in db.empleados
                       select new ListEmpleadoViewModel
                       {
                           Id_Empleados = c.Id_Empleados,
                           Nombres = c.Nombres,
                           Apellidos = c.Apellidos,
                           Direccion = c.Direccion,
                           Telefono = c.Telefono,
                           CorreoElectronico = c.CorreoElectronico,
                           FechaContrato = c.FechaContrato
                       }).ToList();
                return View(lst);
            }
        }

        [Authorize]
        public ActionResult Nuevo()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Nuevo(EmpleadosViewModel empleadoModel)
        {
            try
            {
                //validar los data Annotations
                if (ModelState.IsValid)
                {
                    //Si todo es valido guardamos los datos en la base
                    using (alquilervehiculosEntities db = new alquilervehiculosEntities())
                    {
                        var oEmpleado = new empleados();
                        oEmpleado.Nombres = empleadoModel.Nombres;
                        oEmpleado.Apellidos = empleadoModel.Apellidos;
                        oEmpleado.Direccion = empleadoModel.Direccion;
                        oEmpleado.Telefono = empleadoModel.Telefono;
                        oEmpleado.CorreoElectronico = empleadoModel.CorreoElectronico;
                        oEmpleado.FechaContrato = (DateTime)empleadoModel.FechaContrato;

                        //db.Entry(oEmpleado).State = System.Data.Entity.EntityState.Modified;
                        db.empleados.Add(oEmpleado);
                        db.SaveChanges();
                    }
                    return Redirect("~/Empleado/Index");
                }
                return View(empleadoModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            EmpleadosViewModel empleado = new EmpleadosViewModel();
            using (alquilervehiculosEntities db = new alquilervehiculosEntities())
            {
                var oEmpleado = db.empleados.Find(id);

                empleado.Id_Empleados = oEmpleado.Id_Empleados;
                empleado.Nombres = oEmpleado.Nombres;
                empleado.Apellidos = oEmpleado.Apellidos;
                empleado.Direccion = oEmpleado.Direccion;
                empleado.Telefono = oEmpleado.Telefono;
                empleado.CorreoElectronico = oEmpleado.CorreoElectronico;
                empleado.FechaContrato = oEmpleado.FechaContrato;

                return View(empleado);
            }
        }

        [HttpPost]
        public ActionResult Editar(EmpleadosViewModel empleadoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (alquilervehiculosEntities db = new alquilervehiculosEntities())
                    {
                        var oEmpleado = db.empleados.Find(empleadoModel.Id_Empleados);


                        oEmpleado.Nombres = empleadoModel.Nombres;
                        oEmpleado.Apellidos = empleadoModel.Apellidos;
                        oEmpleado.Direccion = empleadoModel.Direccion;
                        oEmpleado.Telefono = empleadoModel.Telefono;
                        oEmpleado.CorreoElectronico = empleadoModel.CorreoElectronico;
                        oEmpleado.FechaContrato = (DateTime)empleadoModel.FechaContrato;

                        db.Entry(oEmpleado).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index", "Empleado");
                }
                return View(empleadoModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                using (alquilervehiculosEntities db = new alquilervehiculosEntities())
                {
                    var oEmpleado = db.empleados.Find(id);
                    //Eliminar
                    db.empleados.Remove(oEmpleado);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return RedirectToAction("Index", "Empleado");
        }
    }
}