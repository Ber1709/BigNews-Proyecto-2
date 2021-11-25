using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ClassLibraryB.Models
{
    public partial class Noticia
    {
        [Key]
        public int IdNoticia { get; set; }
        [StringLength(50)]
        public string Titulo { get; set; }
        public int? Autor { get; set; }
        [StringLength(250)]
        public string Contenido { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaPublicacion { get; set; }
        [StringLength(150)]
        public string Descripcion { get; set; }
        [StringLength(150)]
        public string UrlNoticia { get; set; }
        [StringLength(150)]
        [Display(Name = "URL de Imagen")]
        public string UrlImagen { get; set; }
        public int? Estado { get; set; }
        public int? Categoria { get; set; }
        [StringLength(10)]
        public string Pais { get; set; }

        [ForeignKey(nameof(Autor))]
        [InverseProperty("Noticia")]
        public virtual Autor AutorNavigation { get; set; }
        [ForeignKey(nameof(Categoria))]
        [InverseProperty(nameof(Categorium.Noticia))]
        public virtual Categorium CategoriaNavigation { get; set; }
        [ForeignKey(nameof(Estado))]
        [InverseProperty("Noticia")]
        public virtual Estado EstadoNavigation { get; set; }
        [ForeignKey(nameof(Pais))]
        [InverseProperty(nameof(Pai.Noticia))]
        public virtual Pai PaisNavigation { get; set; }

        
    }
}
