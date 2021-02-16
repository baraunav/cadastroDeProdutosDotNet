using System.Threading.Tasks;
using Domain;
using Infrastructure.Interface;

namespace Infrastructure.Repository
{
    public class TipoRepository: GenericRepository<TipoProduto>, ITipoRepository
    {
        public TipoRepository(DataContext context) : base(context)
        {
        }

        public async Task<TipoProduto> GetTipoById(int id)
        {
            return await _context.TipoProdutos.FindAsync(id);
        }

        
    }
}