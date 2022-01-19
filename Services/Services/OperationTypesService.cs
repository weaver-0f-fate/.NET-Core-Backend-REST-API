using AutoMapper;
using Data.Interfaces;
using Core.Models;
using Services.DataTransferObjects.OperationTypesDTOs;
using Services.Interfaces;
using System.Threading.Tasks;

namespace Services.Services {
    public class OperationTypesService : AbstractService<OperationType, OperationTypeDTO>, IOperationTypesService{
        IRepositoryWrapper _repository;
        public OperationTypesService(IRepositoryWrapper repository, IMapper mapper) 
            : base(repository.OperationTypes, mapper) {
            _repository = repository;
        }

        public async Task CreateOperationTypeAsync(OperationTypeForCreateDTO operationTypeDTO) {
            var dto = Mapper.Map<OperationTypeDTO>(operationTypeDTO);
            var item = Mapper.Map<OperationType>(dto);
            await _repository.OperationTypes.CreateOperationTypeAsync(item);
        }

        public async Task UpdateOperationTypeAsync(int id, OperationTypeForUpdateDTO operationTypeForUpdateDTO) {
            var operationTypeDTO = Mapper.Map<OperationTypeDTO>(operationTypeForUpdateDTO);
            operationTypeDTO.Id = id;
            var item = Mapper.Map<OperationType>(operationTypeDTO);

            await _repository.OperationTypes.UpdateOperationTypeAsync(item);
        }
    }
}
