using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories {
    public class OperationsRepository : AbstractRepository<Operation>{

        public OperationsRepository(OperationsContext context) : base(context, context.Operations) { }

        public override async Task<IEnumerable<Operation>> GetEntitiesListAsync() {
            return await Context.Operations.AsNoTracking().ToListAsync();
        }

        protected override async Task<Operation> GetItemAsync(int id) {
            return await Context.Operations.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
