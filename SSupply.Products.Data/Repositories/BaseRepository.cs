using Microsoft.EntityFrameworkCore;
using SSupply.Products.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSupply.Products.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Insert(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAllBy(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public T GetById(Guid id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public T GetBy(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>().FirstOrDefault(predicate);
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
