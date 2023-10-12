using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
   public interface IGenericRepository<T> where T : class
    {
        //read
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T,bool>> expression);
        
        //create
        Task<bool> AnyAsync(Expression<Func<T,bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        
        //update
        void Update(T entity);

        //delete
        void Delete(T entity);
        void RemoveRange(IEnumerable<T> entities);



    }
}
