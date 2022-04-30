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

    public partial class Duenos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Duenos()
        {
            this.Citas = new HashSet<Citas>();
            this.Mascotas = new HashSet<Mascotas>();
        }

        [Required(ErrorMessage = "Digite un id")]
        public int idDueno { get; set; }

        [Required(ErrorMessage = "Digite un nombre")]
        [StringLength(16, ErrorMessage = "Nombre")]
        [Display(Name = "Nombre de Due�o")]
        public string nombreDueno { get; set; }

        [Required(ErrorMessage = "Digite el primer apellido")]
        [StringLength(16, ErrorMessage = "Apellido muy largo")]
        [Display(Name = "Primer Apellido")]
        public string primerApellido { get; set; }

        [Required(ErrorMessage = "Digite el segundo apellido")]
        [StringLength(16, ErrorMessage = "Apellido muy largo")]
        [Display(Name = "Segundo Apellido")]
        public string segundoApellido { get; set; }

        [Required(ErrorMessage = "Digite la cedula")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten n�meros")]
        [Display(Name = "C�dula")]
        public string cedula { get; set; }


        [Required(ErrorMessage = "Digite el correo")]
        [EmailAddress(ErrorMessage = "Debe tener el formato axxxxxx@correo.com")]
        [Display(Name = "Correo")]
        public string correo { get; set; }

        [Required(ErrorMessage = "Digite la cedula")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten n�meros")]
        [Display(Name = "Tel�fono")]
        public Nullable<int> telefono { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mascotas> Mascotas { get; set; }
    }
}
