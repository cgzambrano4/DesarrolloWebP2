﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlquilerVehiculoP2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class alquilervehiculosEntities : DbContext
    {
        public alquilervehiculosEntities()
            : base("name=alquilervehiculosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<empleados> empleados { get; set; }
        public virtual DbSet<facturas> facturas { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
        public virtual DbSet<vehiculos> vehiculos { get; set; }
    }
}
