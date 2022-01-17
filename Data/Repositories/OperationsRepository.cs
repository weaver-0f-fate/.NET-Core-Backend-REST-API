using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories {
    public class OperationsRepository : AbstractRepository<Operation>, IOperationsRepository {

        public OperationsRepository(OperationsContext context) : base(context, context.Operations) { }

        public override async Task<IEnumerable<Operation>> GetEntitiesListAsync() {
            return await Context.Operations
                .Include(x => x.OperationType)
                .AsNoTracking()
                .ToListAsync();
        }

        protected override async Task<Operation> GetItemAsync(int id) {
            return await Context.Operations
                .Include(x => x.OperationType)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Operation>> GetOperationsAtSpefcifiedDateAsync(DateTime date) {
            return await Context.Operations
                .Where(x => x.Date.Date == date.Date)
                .Include(x => x.OperationType)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Operation>> GetOperationsAtSpefcifiedPeriodAsync(DateTime startDate, DateTime endDate) {
            return await Context.Operations
                .Where(x => 
                    x.Date.Date >= startDate.Date && 
                    x.Date.Date <= endDate.Date)
                .Include(x => x.OperationType)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
