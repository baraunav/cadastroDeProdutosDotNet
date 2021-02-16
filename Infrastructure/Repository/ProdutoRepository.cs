using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProdutoRepository: GenericRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Produto>> GetAllProdutosWithTipoAsync()
        {
            return await _context.Produtos.Include(x => x.TipoProduto)
                .ToListAsync();
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            return await _context.Produtos.Include(x => x.TipoProduto)
                .FirstOrDefaultAsync(x => x.id == id);
        }
    }

}