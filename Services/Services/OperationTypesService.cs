using AutoMapper;
using Data.Interfaces;
using Core.Models.Models;
using Services.DataTransferObjects;

namespace Services.Services {
    public class OperationTypesService : AbstractService<OperationType, OperationTypeDTO> {
        public OperationTypesService(IRepositoryWrapper repository, IMapper mapper) 
            : base(repository.OperationTypes, mapper) { }
    }
}
