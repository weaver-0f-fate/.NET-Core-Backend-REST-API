using Data.Repositories;
using Models;
using Services.Intrefaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services {
    public abstract class AbstractService<T> : ICrudService<T> where T : AbstractModel {
        protected readonly IRepository<T> Repository;

        protected AbstractService(IRepository<T> repository) {
            Repository = repository;
        }

        public Task<T> CreateAsync(T item) {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllItemsAsync() {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(int? id) {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T item) {
            throw new NotImplementedException();
        }
    }
}
