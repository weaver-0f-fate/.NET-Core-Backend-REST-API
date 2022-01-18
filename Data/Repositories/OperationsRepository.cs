using Core.Models.Models;
using Data.Interfaces;

namespace Data.Repositories {
    public class OperationsRepository : AbstractRepository<Operation>, IOperationsRepository {

        public OperationsRepository(RepositoryContext context) : base(context) { }
    }
}
