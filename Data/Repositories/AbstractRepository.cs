using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories {
    public class AbstractRepository<T> : IRepository<T> where T : AbstractModel{
        public Task CreateAsync(T item) {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetEntitiesListAsync() {
            throw new NotImplementedException();
        }

        public Task<T> GetEntityAsync(int id) {
            throw new NotImplementedException();
        }

        public Task SaveAsync() {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T item) {
            throw new NotImplementedException();
        }
    }
}
