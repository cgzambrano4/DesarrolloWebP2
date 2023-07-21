using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlquilerVehiculoP2.Models.ViewModels
{
    public class EmpleadosViewModel
    {
        public int Id_Empleados { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten caracteres")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten caracteres")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required]
        [StringLength(10)]
        [MinLength(length: 10)]
        [MaxLength(length: 10)]
        [Range(0, Int64.MaxValue, ErrorMessage = "Solo debe ingresar valores numericos")]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(80)]
        [EmailAddress]
        [Display(Name = "Correo Electronico")]
        public string CorreoElectronico { get; set; }

        [Required]
        [Display(Name = "Fecha de Contrato")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaContrato { get; set; }
    }
}