using LanchesMac.Models;

namespace LanchesMac.Repository.Interface
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> categorias { get; }
    }
}
