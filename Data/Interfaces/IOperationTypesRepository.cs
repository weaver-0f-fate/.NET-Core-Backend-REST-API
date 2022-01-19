using Core.Models;
using System.Threading.Tasks;

namespace Data.Interfaces {
    public interface IOperationTypesRepository : IRepository<OperationType> {
        public Task CreateOperationTypeAsync(OperationType operationType);
        public Task UpdateOperationTypeAsync(OperationType operationType);
    }
}
