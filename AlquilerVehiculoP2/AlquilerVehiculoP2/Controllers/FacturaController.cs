using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AlquilerVehiculoP2.Models;
using AlquilerVehiculoP2.Models.ViewModels;

namespace AlquilerVehiculoP2.Controllers
{
    //Andrick
    public class FacturaController : Controller
    {
        // GET: Factura
        [Authorize]
        public ActionResult Index()
        {
            List<ListaFacturaViewModel> lst;
            using (alquilervehiculosEntities db = new alquilervehiculosEntities())
            {
                lst = (
                    from c in db.facturas

                    select new ListaFacturaViewModel
                    {
                        Id_Facturas = c.Id_Facturas,
                        NombreCliente = c.NombreCliente,
                        CedulaCliente = c.CedulaCliente,
                        FechaAlquiler = c.FechaAlquiler,
                        FechaDevolucion = c.FechaDevolucion,
                        PrecioAlquilerDia = (double)c.PrecioAlquilerDia,
                        AbonoAlquiler = (double)c.AbonoAlquiler,
                        TotalAlquiler = (double)c.TotalAlquiler,
                    }
                    ).ToList();
            }
            return View(lst);
        }

        [Authorize]
        public ActionResult Editar(int id)
        {
            FacturaViewModel ModeloFactura = new FacturaViewModel();
            using (alquilervehiculosEntities db = new alquilervehiculosEntities())
            {
                var oFactura = db.facturas.Find(id);
                ModeloFactura.Id_Facturas = oFactura.Id_Facturas;
                ModeloFactura.Id_Vehiculos = oFactura.Id_Vehiculos;
                ModeloFactura.Id_Empleados = oFactura.Id_Empleados;
                ModeloFactura.NombreCliente = oFactura.NombreCliente;
                ModeloFactura.CedulaCliente = oFactura.CedulaCliente;
                ModeloFactura.DireccionCliente = oFactura.DireccionCliente;
                ModeloFactura.TelefonoCliente = oFactura.TelefonoCliente;
                ModeloFactura.FechaAlquiler = oFactura.FechaAlquiler;
                ModeloFactura.FechaDevolucion = oFactura.FechaDevolucion;
                ModeloFactura.PrecioAlquilerDia = oFactura.PrecioAlquilerDia;
                ModeloFactura.AbonoAlquiler = oFactura.AbonoAlquiler;
                ModeloFactura.TotalAlquiler = (double)oFactura.TotalAlquiler;
            }
            return View(ModeloFactura);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Editar(FacturaViewModel ModeloFactura)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (alquilervehiculosEntities db = new alquilervehiculosEntities())
                    {
                        var oFactura = db.facturas.Find(ModeloFactura.Id_Facturas);
                        oFactura.Id_Facturas = ModeloFactura.Id_Facturas;
                        oFactura.Id_Vehiculos = ModeloFactura.Id_Vehiculos;
                        oFactura.Id_Empleados = ModeloFactura.Id_Empleados;
                        oFactura.NombreCliente = ModeloFactura.NombreCliente;
                        oFactura.CedulaCliente = ModeloFactura.CedulaCliente;
                        oFactura.DireccionCliente = ModeloFactura.DireccionCliente;
                        oFactura.TelefonoCliente = ModeloFactura.TelefonoCliente;
                        oFactura.FechaAlquiler = (DateTime)ModeloFactura.FechaAlquiler;
                        oFactura.FechaDevolucion = (DateTime)ModeloFactura.FechaDevolucion;
                        oFactura.PrecioAlquilerDia = ModeloFactura.PrecioAlquilerDia;
                        oFactura.AbonoAlquiler = ModeloFactura.AbonoAlquiler;
                        oFactura.TotalAlquiler = ModeloFactura.TotalAlquiler;

                        db.Entry(oFactura).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Factura/Index");
                }
                return View(ModeloFactura);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Nuevo(int idVehiculo)
        {
            using (alquilervehiculosEntities db = new alquilervehiculosEntities())
            {
                List<vehiculos> listaVehiculos = db.vehiculos.Where(v => v.Disponibilidad == "Disponible").ToList();
                List<empleados> listaClientes = db.empleados.ToList();
                // Obtener el vehículo seleccionado para mostrar su marca en la vista
                var vehiculoSeleccionado = db.vehiculos.Find(idVehiculo);
                var marcaVehiculoSeleccionado = vehiculoSeleccionado != null ? vehiculoSeleccionado.Marca : "";

                NuevaFacturaViewModel viewModel = new NuevaFacturaViewModel
                {
                    FacturaModel = new FacturaViewModel { Id_Vehiculos = idVehiculo },
                    SelectListVehiculos = new SelectList(listaVehiculos, "Id_Vehiculos", "Marca"),
                    SelectListEmpleados = new SelectList(listaClientes, "Id_Empleados", "Apellidos"),
                    MarcaVehiculoSeleccionado = marcaVehiculoSeleccionado // Asignar la marca del vehículo seleccionado al modelo
                };

                return View(viewModel);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Nuevo(NuevaFacturaViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (alquilervehiculosEntities db = new alquilervehiculosEntities())
                    {
                        // Verificar si el vehículo seleccionado está disponible
                        var vehiculo = db.vehiculos.Find(viewModel.FacturaModel.Id_Vehiculos);
                        if (vehiculo != null && vehiculo.Disponibilidad == "Disponible")
                        {
                            var nuevaFactura = new facturas
                            {
                                NombreCliente = viewModel.FacturaModel.NombreCliente,
                                CedulaCliente = viewModel.FacturaModel.CedulaCliente,
                                DireccionCliente = viewModel.FacturaModel.DireccionCliente,
                                TelefonoCliente = viewModel.FacturaModel.TelefonoCliente,
                                FechaAlquiler = (DateTime)viewModel.FacturaModel.FechaAlquiler,
                                FechaDevolucion = (DateTime)viewModel.FacturaModel.FechaDevolucion,
                                PrecioAlquilerDia = viewModel.FacturaModel.PrecioAlquilerDia,
                                AbonoAlquiler = viewModel.FacturaModel.AbonoAlquiler,
                                Id_Vehiculos = viewModel.FacturaModel.Id_Vehiculos,
                                Id_Empleados = viewModel.FacturaModel.Id_Empleados
                            };

                            db.facturas.Add(nuevaFactura);
                            vehiculo.Disponibilidad = "No disponible";
                            db.Entry(vehiculo).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        else
                        {
                            // El vehículo no está disponible, mostrar un mensaje de error y regresar a la vista
                            ModelState.AddModelError("", "El vehículo seleccionado no está disponible.");
                            return View(viewModel);
                        }
                    }
                    // Después de guardar, redirigir a la acción Index del controlador Factura
                    return RedirectToAction("Index");
                }
                // Si el modelo no es válido, volvemos a mostrar la vista con los errores de validación
                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la factura: " + ex.Message);
            }
        }

        public ActionResult Eliminar(int id)
        {
            using (alquilervehiculosEntities db = new alquilervehiculosEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var oFactura = db.facturas.Find(id);

                        if (oFactura != null)
                        {
                            var vehiculo = db.vehiculos.Find(oFactura.Id_Vehiculos);
                            if (vehiculo != null)
                            {
                                vehiculo.Disponibilidad = "Disponible";
                                db.Entry(vehiculo).State = EntityState.Modified;
                            }

                            db.facturas.Remove(oFactura);
                            db.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al eliminar la factura: " + ex.Message);
                    }
                }
            }
            return Redirect("~/Factura/Index");
        }
    }
}