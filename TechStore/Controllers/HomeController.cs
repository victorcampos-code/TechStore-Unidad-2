using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechStore.Services.Interfaces;

namespace TechStore.Controllers
{
    public class HomeController : Controller
    {
        // Inyectamos el servicio en lugar de usar listas en memoria
        private readonly IProductoService _productoService;

        public HomeController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        public async Task<IActionResult> Index()
        {
            // Opcional: Puedes enviar productos desde la BD a la vista de inicio si los necesitas
            var productos = await _productoService.GetAllAsync();
            return View(productos);
        }

        public IActionResult Contactenos()
        {
            return View();
        }

        public IActionResult AcercaDe()
        {
            return View();
        }

        // NOTA: Los métodos antiguos de "Productos" y "Categorias" ya se manejan 
        // en su propio ProductoController con operaciones CRUD reales a la base de datos.
    }
}