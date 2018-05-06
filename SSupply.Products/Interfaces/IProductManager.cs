using SSupply.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSupply.Products.Interfaces
{
    public interface IProductManager
    {
        Task Delete(Guid id);
        IEnumerable<Product> GetAll();
        Product GetById(Guid id);
        Task<Guid> Insert(Product product);
        Task Update(Product product);
    }
}
