using System;
using System.Linq;
using System.Threading.Tasks;
using SSupply.Products.Models;

namespace SSupply.Products.Interfaces
{
    public interface IProductManager
    {
        Task Delete(Product product);
        IQueryable<Product> GetAll();
        Product GetById(Guid id);
        Task Insert(Product product);
    }
}