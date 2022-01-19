using Core.Models;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repositories {
    public class OperationsRepository : AbstractRepository<Operation>, IOperationsRepository {

        public OperationsRepository(RepositoryContext context) : base(context) { }


        public override async Task<IEnumerable<Operation>> GetAllAsync() {
            return await Context.Set<Operation>()
                    .AsNoTracking()
                    .Include(x => x.OperationType)
                    .ToListAsync();
        }
        public override async Task<IEnumerable<Operation>> GetByConditionAsync(Expression<Func<Operation, bool>> expression) {
            return await Context.Set<Operation>()
                    .Where(expression)
                    .AsNoTracking()
                    .Include(x => x.OperationType)
                    .ToListAsync();
        }

        public async Task<IEnumerable<Operation>> GetAtDateAsync(DateTime date) {
            return await GetByConditionAsync(x => x.Date.Date == date.Date);
        }

        public async Task<IEnumerable<Operation>> GetAtPeriodAsync(DateTime startDate, DateTime endDate) {
            return await GetByConditionAsync(x => x.Date.Date >= startDate.Date && x.Date <= endDate.Date);
        }

        public async Task CreateOperationAsync(Operation operation) {
            var operationType = Context.Set<OperationType>().Where(x => x.Name == operation.OperationTypeName).FirstOrDefault();
            if(operationType is null) {
                throw new Exception("Required operation type doesn't exist");
            }
            operation.OperationType = operationType;
            await CreateAsync(operation);
        }

        public async Task UpdateOperationAsync(Operation operation) {
            var operationType = Context.Set<OperationType>().Where(x => x.Name == operation.OperationTypeName).FirstOrDefault();
            if (operationType is null) {
                throw new Exception("Required operation type doesn't exist");
            }
            operation.OperationType = operationType;
            await UpdateAsync(operation);
        }
    }
}
