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
    
    public partial class Mascotas
    {
        public int idMascotas { get; set; }
        public string nombreMascota { get; set; }
        public Nullable<int> idRaza { get; set; }
        public Nullable<int> edad { get; set; }
        public Nullable<int> idHistorial { get; set; }
        public Nullable<int> idDueno { get; set; }
    
        public virtual Duenos Duenos { get; set; }
        public virtual Historiales Historiales { get; set; }
        public virtual Razas Razas { get; set; }
    }
}
