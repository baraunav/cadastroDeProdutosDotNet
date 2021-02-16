using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Infrastructure.Interface
{
    public interface IProdutoRepository: IGenericRepository<Produto>
    {
         Task<List<Produto>> GetAllProdutosWithTipoAsync();
         Task<Produto> GetProdutoByIdAsync(int id);
    }
}