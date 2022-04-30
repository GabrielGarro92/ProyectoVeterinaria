//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinalVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Citas
    {
        [Required(ErrorMessage = "Digite un id")]
        public int idCita { get; set; }

        [Required(ErrorMessage = "Seleccione la fecha")]
        [DataType(DataType.Date)]

        [Display(Name = "Fecha")]
        public Nullable<System.DateTime> fecha { get; set; }

        [Required(ErrorMessage = "Seleccione una clinica")]
        public Nullable<int> idClinica { get; set; }

        [Required(ErrorMessage = "Seleccione un due�o")]
        public Nullable<int> idDueno { get; set; }

        [Required(ErrorMessage = "Seleccione un tipo")]
        public Nullable<int> idTipo { get; set; }


        [Required(ErrorMessage = "Seleccione un id de veterinario")]
        [Display(Name = "Id Veterinario")]
        public Nullable<int> idVeterinario { get; set; }

        public virtual Clinicas Clinicas { get; set; }

        public virtual Duenos Duenos { get; set; }


        public virtual TipoCitas TipoCitas { get; set; }


        public virtual Veterinarios Veterinarios { get; set; }
    }
}
