using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ClassLibraryB.Models
{
    [Table("Autor")]
    public partial class Autor
    {
        public Autor()
        {
            Noticia = new HashSet<Noticia>();
        }

        [Key]
        public int IdAutor { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty("AutorNavigation")]
        public virtual ICollection<Noticia> Noticia { get; set; }
    }
}
