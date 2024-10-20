﻿using jjournal.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace jjournal.Infrastructure.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(AppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public async Task<EntityEntry<T>> CreateAsync(T entity) => await dbSet.AddAsync(entity);
        public void Delete(T entity) => dbSet.Remove(entity);
        public void Update(T entity) => dbSet.Update(entity);

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, int pageSize = 0, int pageNumber = 1)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (pageSize > 0)
                query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);

            return await query.ToListAsync();
        }

        /*
         Tipo T? para lidar com possível referência nula
         */
        public async Task<T?> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;

            if (tracked)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            return await query.FirstOrDefaultAsync();
        }
    }
}
