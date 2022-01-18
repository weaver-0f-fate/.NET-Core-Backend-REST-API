using AutoMapper;
using Data.Interfaces;
using Core.Models.Models;
using Services.ModelsDTO;

namespace Services.Services {
    public class OperationTypesService : AbstractService<OperationType, OperationTypeDTO> {
        public OperationTypesService(IRepository<OperationType> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
