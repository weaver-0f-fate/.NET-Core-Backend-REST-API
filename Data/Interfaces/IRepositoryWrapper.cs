using System.Threading.Tasks;

namespace Data.Interfaces {
    public interface IRepositoryWrapper {
        public IOperationsRepository Operations { get; }
        public IOperationTypesRepository OperationTypes { get; }
        public Task Save();
    }
}
