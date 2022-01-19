using Microsoft.EntityFrameworkCore;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Interfaces;
using System.Linq.Expressions;
using System.Linq;

namespace Data.Repositories {
    public abstract class AbstractRepository<T> : IRepository<T> where T : AbstractModel{
        protected readonly RepositoryContext Context;
        private bool _disposed;

        protected AbstractRepository(RepositoryContext context) {
            Context = context;
        }


        public abstract Task<IEnumerable<T>> GetAllAsync();
        public abstract Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
        public async Task<T> GetByIdAsync(int id) {
            var items = await GetByConditionAsync(x => x.Id == id);
            return items.FirstOrDefault();
        }

        public async Task CreateAsync(T item) {
            if (item is null) {
                throw new Exception("Source Item wasn't provided.");
            }
            await Context.Set<T>().AddAsync(item);
            await SaveChangesAsync();

        }
        public async Task UpdateAsync(T item) {
            if (item is null) {
                throw new Exception("Source Item wasn't provided.");
            }
            Context.Set<T>().Update(item);
            await SaveChangesAsync();

        }
        public async Task DeleteAsync(int id) {
            var item = await GetByIdAsync(id);
            Context.Set<T>().Remove(item);
            await SaveChangesAsync();
        }
        public async Task<bool> ExistsAsync(int id) {
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
