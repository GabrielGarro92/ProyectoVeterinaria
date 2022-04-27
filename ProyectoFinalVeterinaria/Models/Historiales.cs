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
    
    public partial class Historiales
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Historiales()
        {
            this.Mascotas = new HashSet<Mascotas>();
        }
    
        public int idHistorial { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string motivoConsulta { get; set; }
        public string dignostico { get; set; }
        public Nullable<int> idEnfermedad { get; set; }
        public Nullable<int> idVeterinario { get; set; }
    
        public virtual Enfermedades Enfermedades { get; set; }
        public virtual Veterinarios Veterinarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mascotas> Mascotas { get; set; }
    }
}
