using Core.Models;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repositories {
    public class OperationTypesRepository : AbstractRepository<OperationType>, IOperationTypesRepository{
        public OperationTypesRepository(RepositoryContext context) : base(context) { }

        public async Task CreateOperationTypeAsync(OperationType operationType) {
            var type = GetByConditionAsync(x => x.Name == operationType.Name);
            if(type is not null) {
                throw new Exception("Operation Type with this name already exists.");
            }
            await CreateAsync(operationType);
        }
        public async Task UpdateOperationTypeAsync(OperationType operationType) {
            var type = GetByConditionAsync(x => x.Name == operationType.Name);
            if (type is not null) {
                throw new Exception("Operation Type with this name already exists.");
            }
            await UpdateAsync(operationType);
        }

        public override async Task<IEnumerable<OperationType>> GetAllAsync() {
            return await Context.Set<OperationType>()
                    .AsNoTracking()
                    .ToListAsync();
        }
        public override async Task<IEnumerable<OperationType>> GetByConditionAsync(Expression<Func<OperationType, bool>> expression) {
            return await Context.Set<OperationType>()
                    .Where(expression)
                    .AsNoTracking()
                    .ToListAsync();
        }

        
    }
}
