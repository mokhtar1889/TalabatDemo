using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistanceLayer.Repositories
{
    public class GenericRepositories<TEntity, TKey>(StoreDbContext _storeDbContext) : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public async Task<TEntity?> GetByIdAsync(TKey id) => await _storeDbContext.Set<TEntity>().FindAsync(id);


        public void Remove(TEntity entity)
        {
            _storeDbContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _storeDbContext.Set<TEntity>().Update(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _storeDbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _storeDbContext.Set<TEntity>().ToListAsync();

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, TKey> secifications)
        {
            return await SpecifictionsEvaluator.CreateQuery(_storeDbContext.Set<TEntity>(),secifications).ToListAsync();
        }
        public async Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, TKey> secifications)
        {
            return await SpecifictionsEvaluator.CreateQuery(_storeDbContext.Set<TEntity>(), secifications).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecifications<TEntity, TKey> specifications)
        {
            return await SpecifictionsEvaluator.CreateQuery(_storeDbContext.Set<TEntity>(), specifications).CountAsync();
        }
    }
    }

