using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardApp.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(long id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(long id);
    }
}