using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ClassLibraryB.Models
{
    public partial class Pai
    {
        public Pai()
        {
            Noticia = new HashSet<Noticia>();
        }

        [Key]
        [StringLength(10)]
        public string IdPais { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty("PaisNavigation")]
        public virtual ICollection<Noticia> Noticia { get; set; }
    }
}
