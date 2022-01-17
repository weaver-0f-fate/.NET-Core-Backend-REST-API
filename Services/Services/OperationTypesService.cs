using AutoMapper;
using Data.Repositories;
using Core.Models;
using Services.ModelsDTO;

namespace Services.Services {
    public class OperationTypesService : AbstractService<OperationType, OperationTypeDTO> {
        public OperationTypesService(IRepository<OperationType> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
