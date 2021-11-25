using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassLibraryB.Data;
using ClassLibraryB.Models;

namespace BIg_News.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly ProyectoNoticiasContext _context;

        public NoticiasController(ProyectoNoticiasContext context)
        {
            _context = context;
        }

        // GET: Noticias
        public async Task<IActionResult> Index()
        {
            var proyectoNoticiasContext = _context.Noticias.Include(n => n.AutorNavigation).Include(n => n.CategoriaNavigation).Include(n => n.EstadoNavigation).Include(n => n.PaisNavigation);
            return View(await proyectoNoticiasContext.ToListAsync());
        }

        // GET: Noticias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticias
                .Include(n => n.AutorNavigation)
                .Include(n => n.CategoriaNavigation)
                .Include(n => n.EstadoNavigation)
                .Include(n => n.PaisNavigation)
                .FirstOrDefaultAsync(m => m.IdNoticia == id);
            if (noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }

        // GET: Noticias/Create
        public IActionResult Create()
        {
            ViewData["Autor"] = new SelectList(_context.Autors, "IdAutor", "Nombre");
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "Nombre");
            ViewData["Estado"] = new SelectList(_context.Estados, "IdEstado", "Nombre");
            ViewData["Pais"] = new SelectList(_context.Pais, "IdPais", "Nombre");
            return View();
        }

        // POST: Noticias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNoticia,Titulo,Autor,Contenido,FechaPublicacion,Descripcion,UrlNoticia,UrlImagen,Estado,Categoria,Pais")] Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noticia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Autor"] = new SelectList(_context.Autors, "IdAutor", "IdAutor", noticia.Autor);
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria", noticia.Categoria);
            ViewData["Estado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", noticia.Estado);
            ViewData["Pais"] = new SelectList(_context.Pais, "IdPais", "IdPais", noticia.Pais);
            return View(noticia);
        }

        // GET: Noticias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticias.FindAsync(id);
            if (noticia == null)
            {
                return NotFound();
            }
            ViewData["Autor"] = new SelectList(_context.Autors, "IdAutor", "Nombre", noticia.AutorNavigation);
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "Nombre", noticia.CategoriaNavigation);
            ViewData["Estado"] = new SelectList(_context.Estados, "IdEstado", "Nombre", noticia.EstadoNavigation);
            ViewData["Pais"] = new SelectList(_context.Pais, "IdPais", "Nombre", noticia.PaisNavigation);
            return View(noticia);
        }

        // POST: Noticias/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNoticia,Titulo,Autor,Contenido,FechaPublicacion,Descripcion,UrlNoticia,UrlImagen,Estado,Categoria,Pais")] Noticia noticia)
        {
            if (id != noticia.IdNoticia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noticia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticiaExists(noticia.IdNoticia))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Autor"] = new SelectList(_context.Autors, "IdAutor", "Nombre", noticia.AutorNavigation);
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "Nombre", noticia.CategoriaNavigation);
            ViewData["Estado"] = new SelectList(_context.Estados, "IdEstado", "Nombre", noticia.EstadoNavigation);
            ViewData["Pais"] = new SelectList(_context.Pais, "IdPais", "Nombre", noticia.PaisNavigation);
            return View(noticia);
        }

        // GET: Noticias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticias
                .Include(n => n.AutorNavigation)
                .Include(n => n.CategoriaNavigation)
                .Include(n => n.EstadoNavigation)
                .Include(n => n.PaisNavigation)
                .FirstOrDefaultAsync(m => m.IdNoticia == id);
            if (noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }

        // POST: Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noticia = await _context.Noticias.FindAsync(id);
            _context.Noticias.Remove(noticia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticiaExists(int id)
        {
            return _context.Noticias.Any(e => e.IdNoticia == id);
        }
    }
}
