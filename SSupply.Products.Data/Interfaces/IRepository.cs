using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSupply.Products.Data.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> Insert(T entity);
        Task Delete(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllBy(Func<T, bool> predicate);
        T GetById(Guid id);
        T GetBy(Func<T, bool> predicate);
        Task Commit();
    }
}
