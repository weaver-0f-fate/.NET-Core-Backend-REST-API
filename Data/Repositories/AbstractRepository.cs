using Microsoft.EntityFrameworkCore;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories {
    public abstract class AbstractRepository<T> : IRepository<T> where T : AbstractModel{
        protected readonly OperationsContext Context;
        private readonly DbSet<T> _repository;
        private bool _disposed;

        protected AbstractRepository(OperationsContext context, DbSet<T> repo) {
            Context = context;
            _repository = repo;
        }


        public abstract Task<IEnumerable<T>> GetEntitiesListAsync();


        public async Task<T> GetEntityAsync(int id) {
            if (id < 0) {
                return null;
            }
            var item = await GetItemAsync(id);
            if (item is null) {
                throw new Exception("No such entity in Database");
            }
            return item;
        }
        protected abstract Task<T> GetItemAsync(int id);


        public async Task CreateAsync(T item) {
            if (item is null) {
                return;
            }
            await Context.AddAsync(item);
            await SaveAsync();

        }
        public async Task UpdateAsync(T item) {
            if (item is null) {
                return;
            }
            Context.Update(item);
            await SaveAsync();

        }
        public async Task DeleteAsync(int id) {
            var item = await GetEntityAsync(id);
            _repository.Remove(item);
            await SaveAsync();

        }
        public async Task<bool> ExistsAsync(int id) {
            return await _repository.AnyAsync(e => e.Id == id);
        }
        public async  Task SaveAsync() {
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
