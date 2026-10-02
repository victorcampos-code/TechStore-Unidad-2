using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechStore.Services.Interfaces;

namespace TechStore.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.GetAllAsync();
            return View(categorias);
        }
    }
}
