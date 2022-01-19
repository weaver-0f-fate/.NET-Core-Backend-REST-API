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

        public async Task<OperationType> CreateOperationTypeAsync(OperationType operationType) {
            return await CreateAsync(operationType);
        }
        public async Task<OperationType> UpdateOperationTypeAsync(OperationType operationType) {
            return await UpdateAsync(operationType);
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

        public async Task<OperationType> GetOperationTypeByNameAsync(string name) {
            return await Context.Set<OperationType>()
                .Where(x => x.Name == name)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
