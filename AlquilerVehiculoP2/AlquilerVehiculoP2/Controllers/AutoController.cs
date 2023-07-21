using AlquilerVehiculoP2.Models;
using AlquilerVehiculoP2.Models.ViewModels;
using AlquilerVehiculoP2.Filters;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace AlquilerVehiculoP2.Controllers
{
    //Raquel
    [Authorize]
    public class AutoController : Controller
    {
        // GET: Auto
        [Authorize]
        public ActionResult Index()
        {
            List<ListaAutoViewModel> lst;
            using (alquilervehiculosEntities db = new alquilervehiculosEntities()) // usamos el entity de slqcreado
            {
                lst = (from v in db.vehiculos
                       select new ListaAutoViewModel
                       {
                           Id_Vehiculos = v.Id_Vehiculos,
                           Marca = v.Marca,
                           Modelo = v.Modelo,
                           Anio = v.Anio,
                           Tipo = v.Tipo,
                           Disponibilidad = v.Disponibilidad,
                           img_cli = v.img_cli
                       }).ToList();
                return View(lst);
            }
        }

        [Authorize]
        public ActionResult Nuevo()

        {
            return View();
        }

        //para eniavr los datos actualizados 
        [Authorize]
        [HttpPost]
        public ActionResult Nuevo(AutoViewModel autoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string filename = Path.GetFileName(autoModel.img_cli.FileName);
                    string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                    string to_path = "~/imgs/" + _filename;

                    autoModel.img_cli.SaveAs(Server.MapPath(to_path));

                    using (alquilervehiculosEntities db = new alquilervehiculosEntities())
                    {
                        var oNuevo = new vehiculos();
                        oNuevo.Marca = autoModel.Marca;
                        oNuevo.Modelo = autoModel.Modelo;
                        oNuevo.Anio = autoModel.Anio;
                        oNuevo.Tipo = autoModel.Tipo;
                        oNuevo.Disponibilidad = autoModel.Disponibilidad;
                        oNuevo.img_cli = to_path;

                        //oNuevo.id_auto = oNuevo.id_auto;

                        db.vehiculos.Add(oNuevo);
                        db.SaveChanges();
                    }
                    return Redirect("~/Auto/Index");
                }
                return View(autoModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Editar
        [Authorize]
        public ActionResult Editar(int Id_Vehiculos)
        {
            AutoViewModel auto = new AutoViewModel();
            using (alquilervehiculosEntities db = new alquilervehiculosEntities())
            {
                var oEditar = db.vehiculos.Find(Id_Vehiculos);
                auto.Marca = oEditar.Marca;
                auto.Modelo = oEditar.Modelo;
                auto.Anio = oEditar.Anio;
                auto.Tipo = oEditar.Tipo;
                auto.Disponibilidad = oEditar.Disponibilidad;
                auto.Id_Vehiculos = oEditar.Id_Vehiculos;
            }
            return View(auto);
        }

        //para eniavr los datos actualizados 
        [Authorize]
        [HttpPost]
        public ActionResult Editar(AutoViewModel autoModel, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                    string to_path = "~/imgs/" + _filename;
                    file.SaveAs(Server.MapPath(to_path));

                    using (alquilervehiculosEntities db = new alquilervehiculosEntities())
                    {
                        var oEditar = new vehiculos();

                        oEditar.Id_Vehiculos = autoModel.Id_Vehiculos;
                        oEditar.Marca = autoModel.Marca;
                        oEditar.Modelo = autoModel.Modelo;
                        oEditar.Anio = autoModel.Anio;
                        oEditar.Tipo = autoModel.Tipo;
                        oEditar.Disponibilidad = autoModel.Disponibilidad;
                        oEditar.img_cli = to_path;

                        db.Entry(oEditar).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Auto/Index");
                }
                return View(autoModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Eliminar
        //metodo para eliminar
        public ActionResult Eliminar(int Id_Vehiculos)
        {
            try
            {
                using (alquilervehiculosEntities db = new alquilervehiculosEntities())
                {
                    var oAutos = db.vehiculos.Find(Id_Vehiculos);
                    if (oAutos != null)
                    {
                        db.vehiculos.Remove(oAutos);
                        db.SaveChanges();
                    }
                }
                return Redirect("~/Auto/Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        public ActionResult VehiculosDisponibles()
        {
            List<ListaAutoViewModel> lst;
            using (alquilervehiculosEntities db = new alquilervehiculosEntities())
            {
                lst = (from v in db.vehiculos
                       where v.Disponibilidad == "Disponible"
                       select new ListaAutoViewModel
                       {
                           Id_Vehiculos = v.Id_Vehiculos,
                           Marca = v.Marca,
                           Modelo = v.Modelo,
                           Anio = v.Anio,
                           Tipo = v.Tipo,
                           Disponibilidad = v.Disponibilidad,
                           img_cli = v.img_cli
                       }).ToList();
            }
            return View(lst);
        }
    }
}

