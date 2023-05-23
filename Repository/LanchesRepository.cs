using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repository
{
    public class LanchesRepository : ILanchesRepository
    {
        private readonly MySQLContext _context;

        public LanchesRepository(MySQLContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(x => x.Categoria);

        public IEnumerable<Lanche> LanchesPreferido => _context.Lanches.Where(x => x.IsLanchePreferido)
                                                        .Include(c => c.Categoria);

        public Lanche LancheById(int id)
        {
            return _context.Lanches.FirstOrDefault(x => x.LancheId == id);
        }
    }
}
