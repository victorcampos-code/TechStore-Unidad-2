using TechStore.Models;

namespace TechStore.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAllAsync();
    }
}
