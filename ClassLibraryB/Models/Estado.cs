using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ClassLibraryB.Models
{
    [Table("Estado")]
    public partial class Estado
    {
        public Estado()
        {
            Noticia = new HashSet<Noticia>();
        }

        [Key]
        public int IdEstado { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty("EstadoNavigation")]
        public virtual ICollection<Noticia> Noticia { get; set; }
    }
}
