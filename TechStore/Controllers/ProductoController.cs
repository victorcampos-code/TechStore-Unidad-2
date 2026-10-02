using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechStore.Models;
using TechStore.Services.Interfaces;

namespace TechStore.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;
        private readonly ICategoriaService _categoriaService;

        // Inyección de dependencias por constructor
        public ProductoController(IProductoService productoService, ICategoriaService categoriaService)
        {
            _productoService = productoService;
            _categoriaService = categoriaService;
        }

        // Listado de Productos
        public async Task<IActionResult> Index()
        {
            var productos = await _productoService.GetAllAsync();
            return View(productos);
        }

        // GET: Mostrar vista de Crear
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoriaId = new SelectList(await _categoriaService.GetAllAsync(), "ID", "Nombre");
            return View();
        }

        // POST: Guardar nuevo Producto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                await _productoService.AddAsync(producto);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoriaId = new SelectList(await _categoriaService.GetAllAsync(), "ID", "Nombre", producto.CategoriaId);
            return View(producto);
        }

        // GET: Mostrar vista de Editar
        public async Task<IActionResult> Edit(int id)
        {
            var producto = await _productoService.GetByIdAsync(id);
            if (producto == null) return NotFound();

            ViewBag.CategoriaId = new SelectList(await _categoriaService.GetAllAsync(), "ID", "Nombre", producto.CategoriaId);
            return View(producto);
        }

        // POST: Guardar edición
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                await _productoService.UpdateAsync(producto);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoriaId = new SelectList(await _categoriaService.GetAllAsync(), "ID", "Nombre", producto.CategoriaId);
            return View(producto);
        }

        // GET: Mostrar vista de Eliminar
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _productoService.GetByIdAsync(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        // POST: Confirmar Eliminación
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}