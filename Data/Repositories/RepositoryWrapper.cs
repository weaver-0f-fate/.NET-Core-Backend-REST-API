using Data.Interfaces;
using System.Threading.Tasks;

namespace Data.Repositories {
    public class RepositoryWrapper : IRepositoryWrapper {
        private RepositoryContext _context;
        private IOperationsRepository _operations;
        private IOperationTypesRepository _operationTypes;
        public IOperationsRepository Operations {
            get {
                if (_operations == null) {
                    _operations = new OperationsRepository(_context);
                }
                return _operations;
            }
        }
        public IOperationTypesRepository OperationTypes {
            get {
                if (_operationTypes == null) {
                    _operationTypes = new OperationTypesRepository(_context);
                }
                return _operationTypes;
            }
        }
        public RepositoryWrapper(RepositoryContext repositoryContext) {
            _context = repositoryContext;
        }

        public async Task Save() {
            await _context.SaveChangesAsync();
        }
    }
}
