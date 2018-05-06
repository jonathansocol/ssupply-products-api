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
        IQueryable<T> GetAll();
        T GetById(Guid id);
        Task Commit();
    }
}
