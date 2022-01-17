using Microsoft.EntityFrameworkCore;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories {
    public class OperationTypesRepository : AbstractRepository<OperationType>{
        public OperationTypesRepository(OperationsContext context) : base(context, context.OperationTypes) { }

        public override async Task<IEnumerable<OperationType>> GetEntitiesListAsync() {
            return await Context.OperationTypes.AsNoTracking().ToListAsync();
        }

        protected override async Task<OperationType> GetItemAsync(int id) {
            return await Context.OperationTypes.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
