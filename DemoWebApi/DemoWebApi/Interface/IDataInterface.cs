using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Interface
{
   public interface IDataInterface<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(long id);
        Task<int> Add(TEntity entity);
        Task Update(TEntity dbEntity, TEntity entity);
        Task<int> Delete(TEntity entity);
    }
}
