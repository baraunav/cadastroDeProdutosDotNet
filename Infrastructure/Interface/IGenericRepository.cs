using System.Threading.Tasks;
using System.Collections.Generic;

namespace Infrastructure.Interface

{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<List<TEntity>> ListAll();
    }
}