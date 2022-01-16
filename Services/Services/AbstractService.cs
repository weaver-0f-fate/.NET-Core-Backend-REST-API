using Data.Repositories;
using Models;
using Services.Intrefaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services {
    public abstract class AbstractService<T> : IService<T> where T : AbstractModel {
        protected readonly IRepository<T> Repository;

        protected AbstractService(IRepository<T> repository) {
            Repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllItemsAsync() {
            return await Repository.GetEntitiesListAsync();
        }

        public async Task<T> GetAsync(int? id) {
            if (id is null) {
                throw new Exception("No such entity in database");
            }

            var item = await Repository.GetEntityAsync((int)id);
            if (item is null) {
                throw new Exception("No such entity in database");
            }
            return item;

        }
        public async Task CreateAsync(T item) {
            await Repository.CreateAsync(item);
        }
        public async Task UpdateAsync(T item) {
            await Repository.UpdateAsync(item);
        }
        public async Task DeleteAsync(int id) {
            await Repository.DeleteAsync(id);
        }
    }
}
