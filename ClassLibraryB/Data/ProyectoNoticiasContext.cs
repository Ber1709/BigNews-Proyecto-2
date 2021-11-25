using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ClassLibraryB.Models;

#nullable disable

namespace ClassLibraryB.Data
{
    public partial class ProyectoNoticiasContext : DbContext
    {
        public ProyectoNoticiasContext()
        {
        }

        public ProyectoNoticiasContext(DbContextOptions<ProyectoNoticiasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Noticia> Noticias { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-8LHVGF7\\SQLEXPRESS;Initial Catalog=ProyectoNoticias;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PK__Autor__DD33B03106AEE9F5");

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A10F8FC85F5");

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estado__FBB0EDC1BFA02A00");

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Noticia>(entity =>
            {
                entity.HasKey(e => e.IdNoticia)
                    .HasName("PK__Noticias__A6C949A8BDDBE886");

                entity.Property(e => e.Contenido).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Pais).IsUnicode(false);

                entity.Property(e => e.Titulo).IsUnicode(false);

                entity.Property(e => e.UrlImagen).IsUnicode(false);

                entity.Property(e => e.UrlNoticia).IsUnicode(false);

                entity.HasOne(d => d.AutorNavigation)
                    .WithMany(p => p.Noticia)
                    .HasForeignKey(d => d.Autor)
                    .HasConstraintName("Fk_Autor");

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.Noticia)
                    .HasForeignKey(d => d.Categoria)
                    .HasConstraintName("Fk_Categoria");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Noticia)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("Fk_Estado");

                entity.HasOne(d => d.PaisNavigation)
                    .WithMany(p => p.Noticia)
                    .HasForeignKey(d => d.Pais)
                    .HasConstraintName("Fk_Pais");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.HasKey(e => e.IdPais)
                    .HasName("PK__Pais__FC850A7B9CDF27C8");

                entity.Property(e => e.IdPais).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
