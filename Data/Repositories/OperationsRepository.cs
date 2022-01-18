using Core.Models.Models;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repositories {
    public class OperationsRepository : AbstractRepository<Operation>, IOperationsRepository {

        public OperationsRepository(RepositoryContext context) : base(context) { }

        public async Task<IEnumerable<Operation>> GetOperationsAtDateAsync(DateTime date) {
            Expression<Func<Operation, bool>> expression = x => x.Date.Date == date.Date;
            return await GetByConditionAsync(expression);
        }

        public async Task<IEnumerable<Operation>> GetOperationsAtPeriodAsync(DateTime startDate, DateTime endDate) {
            Expression<Func<Operation, bool>> expression = x =>
                x.Date.Date >= startDate.Date && x.Date <= endDate.Date;
            return await GetByConditionAsync(expression);
        }
    }
}
