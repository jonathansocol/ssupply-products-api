﻿using Microsoft.EntityFrameworkCore;
using SSupply.Products.Data.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SSupply.Products.Data.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        protected BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Insert(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public T GetById(Guid id)
        {
            return _dbContext.Set<T>().Find(id);
        }
    }
}