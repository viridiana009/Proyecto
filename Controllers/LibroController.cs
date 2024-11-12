using Microsoft.AspNetCore.Mvc;



using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.IdentityModel.Tokens;


namespace Biblioteca.Controllers
{
  
    public class LibroController : Controller
    {

        private readonly AppDBContext _appDBContext;

        public LibroController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [HttpGet]
        public async Task<IActionResult>ListaLibros()
        {
            List<Libro>ListaLibros = await _appDBContext.Libros.ToListAsync();
            return View(ListaLibros);
        }

        [HttpPost]
        public async Task<IActionResult>ListaLibros(String buscar)
        {

           
            if (!String.IsNullOrEmpty(buscar))
            {

                List<Libro> ListaLibros = await _appDBContext.Libros.Where(e => e.Autor!.Contains(buscar) || e.Titulo!.Contains(buscar)).ToListAsync();
                return View(ListaLibros);
            }
            else
            {
                return RedirectToAction(nameof(ListaLibros));
            }
           

        }

        [HttpGet]
        public IActionResult Nuevo()
        {
       
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Nuevo(Libro libro)
        {
            
            if (!ModelState.IsValid)
            {
                return View(libro);
            }
            else
            {
                await _appDBContext.Libros.AddAsync(libro);
                await _appDBContext.SaveChangesAsync();
                return RedirectToAction(nameof(ListaLibros));

            }
              
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            
            Libro li = await _appDBContext.Libros.FirstAsync(e => e.IdLibro == id);
            return View(li);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return View(libro);
            }
            else
            {
                _appDBContext.Libros.Update(libro);
                await _appDBContext.SaveChangesAsync();
                return RedirectToAction(nameof(ListaLibros));
            }
           
        }
        [HttpGet]
        public async Task<IActionResult>Eliminar(int id)
        {

            Libro li = await _appDBContext.Libros.FirstAsync(e => e.IdLibro == id);
            _appDBContext.Libros.Remove(li);
             await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(ListaLibros));
        }
    }
}
