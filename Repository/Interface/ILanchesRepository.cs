using LanchesMac.Models;

namespace LanchesMac.Repository.Interface
{
    public interface ILanchesRepository
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferido { get; }
        Lanche LancheById (int id);

    }
}
