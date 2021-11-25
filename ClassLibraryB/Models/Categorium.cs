using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ClassLibraryB.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Noticia = new HashSet<Noticia>();
        }

        [Key]
        public int IdCategoria { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty("CategoriaNavigation")]
        public virtual ICollection<Noticia> Noticia { get; set; }
    }
}
