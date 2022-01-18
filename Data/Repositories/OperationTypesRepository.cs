using Core.Models.Models;
using Data.Interfaces;

namespace Data.Repositories {
    public class OperationTypesRepository : AbstractRepository<OperationType>, IOperationTypesRepository{
        public OperationTypesRepository(RepositoryContext context) : base(context) { }
    }
}
