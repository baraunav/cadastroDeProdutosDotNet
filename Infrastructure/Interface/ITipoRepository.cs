using System.Threading.Tasks;
using Domain;

namespace Infrastructure.Interface
{
    public interface ITipoRepository: IGenericRepository<TipoProduto>
    {
         Task<TipoProduto> GetTipoById(int id);
    }
}