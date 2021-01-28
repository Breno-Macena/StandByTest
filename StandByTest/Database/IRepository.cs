using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StandByTest.Database {
    public interface IRepository<TEntity> where TEntity : class {
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> FindAsync(int key);
        Task InsertAsync(params TEntity[] obj);
        Task UpdateAsync(params TEntity[] obj);
        Task DeleteAsync(params TEntity[] obj);
    }
}
