using Core.Models;
using System.Threading.Tasks;

namespace Data.Interfaces {
    public interface IOperationTypesRepository : IRepository<OperationType> {
        public Task<OperationType> GetOperationTypeByNameAsync(string name);
        public Task<OperationType> CreateOperationTypeAsync(OperationType operationType);
        public Task<OperationType> UpdateOperationTypeAsync(OperationType operationType);
    }
}
