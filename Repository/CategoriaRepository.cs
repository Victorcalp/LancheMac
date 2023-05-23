using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repository.Interface;

namespace LanchesMac.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly MySQLContext _context;

        public CategoriaRepository(MySQLContext context)
        {
            _context = context;
        }
        public IEnumerable<Categoria> categorias => _context.Categorias;
    }
}
