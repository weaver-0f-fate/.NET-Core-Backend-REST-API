using Core.Models.Models;
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
