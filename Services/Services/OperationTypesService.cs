using AutoMapper;
using Data.Interfaces;
using Core.Models;
using Services.DataTransferObjects;
using Services.Interfaces;

namespace Services.Services {
    public class OperationTypesService : AbstractService<OperationType, OperationTypeDTO>, IOperationTypesService{
        public OperationTypesService(IRepositoryWrapper repository, IMapper mapper) 
            : base(repository.OperationTypes, mapper) { }
    }
}
