using AutoMapper;
using Data.Interfaces;
using Services.Interfaces;

namespace Services.Services {
    public class ServiceWrapper : IServiceWrapper {
        private IRepositoryWrapper _repositoryWrapper;
        private IMapper _mapper;
        private IOperationsService _operationsService;
        private IOperationTypesService _operationTypesService;
        public IOperationsService OperationsService {
            get {
                if (_operationsService == null) {
                    _operationsService = new OperationsService(_repositoryWrapper, _mapper);
                }
                return _operationsService;
            }
        }
        public IOperationTypesService OperationTypesService {
            get {
                if (_operationTypesService == null) {
                    _operationTypesService = new OperationTypesService(_repositoryWrapper, _mapper);
                }
                return _operationTypesService;
            }
        }
        public ServiceWrapper(IRepositoryWrapper repositoryWrapper, IMapper mapper) {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }
    }
}
