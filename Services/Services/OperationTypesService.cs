using Data.Repositories;
using Models;

namespace Services.Services {
    public class OperationTypesService : AbstractService<OperationType> {
        public OperationTypesService(IRepository<OperationType> repository) : base(repository) { }
    }
}
