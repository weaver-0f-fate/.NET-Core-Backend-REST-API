using Microsoft.EntityFrameworkCore;
using Core.Models;
using System;
using System.Threading.Tasks;
using Data.Interfaces;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;
using Core.Exceptions;

namespace Data.Repositories {
    public abstract class AbstractRepository<T> : IRepository<T> where T : AbstractModel{
        protected readonly RepositoryContext Context;
        private bool _disposed;

        protected AbstractRepository(RepositoryContext context) {
            Context = context;
        }


        public abstract Task<IEnumerable<T>> GetAllAsync();
        public abstract Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
        public async Task<T> GetByIdAsync(Guid id) {
            var items = await GetByConditionAsync(x => x.Id == id);
            if (!items.Any()) {
                throw new EntityNotFoundException($"There is no entity with id: {id}");
            }
            return items.FirstOrDefault();
        }

        public async Task<T> CreateAsync(T item) {
            if (item is null) {
                throw new SourceEntityNullException("Source Item wasn't provided.");
            }
            var newItem = await Context.Set<T>().AddAsync(item);
            await SaveChangesAsync();
            return await GetByIdAsync(newItem.Entity.Id);

        }
        public async Task<T> UpdateAsync(T item) {
            if (item is null) {
                throw new SourceEntityNullException("Source Item wasn't provided.");
            }
            var updatedItem = Context.Set<T>().Update(item);
            await SaveChangesAsync();
            return await GetByIdAsync(updatedItem.Entity.Id);

        }
        public async Task DeleteAsync(Guid id) {
            var item = await GetByIdAsync(id);
            Context.Set<T>().Remove(item);
            await SaveChangesAsync();
        }
        public async Task<bool> ExistsAsync(Guid id) {
            return await Context.Set<T>().AnyAsync(x => x.Id == id);
        }
        public async Task SaveChangesAsync() {
            await Context.SaveChangesAsync();
        }

        public async void Dispose() {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }
        private async Task DisposeAsync(bool disposing) {
            if (!_disposed) {
                if (disposing) {
                    await Context.DisposeAsync();
                }
            }
            _disposed = true;
        }
    }
}
