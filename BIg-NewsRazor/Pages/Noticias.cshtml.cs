using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClassLibraryB.Data;
using ClassLibraryB.Models;

namespace BIg_NewsRazor.Pages
{
    public class NoticiasModel : PageModel
    {
        private readonly ClassLibraryB.Data.ProyectoNoticiasContext _context;

        public NoticiasModel(ClassLibraryB.Data.ProyectoNoticiasContext context)
        {
            _context = context;
        }

        public IList<Noticia> Noticia { get;set; }

        public async Task OnGetAsync()
        {
            Noticia = await _context.Noticias
                .Include(n => n.AutorNavigation)
                .Include(n => n.CategoriaNavigation)
                .Include(n => n.EstadoNavigation)
                .Include(n => n.PaisNavigation).ToListAsync();
        }
    }
}
