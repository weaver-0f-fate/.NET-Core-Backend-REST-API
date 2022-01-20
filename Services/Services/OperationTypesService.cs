using AutoMapper;
using Data.Interfaces;
using Core.Models;
using Services.DataTransferObjects.OperationTypesDTOs;
using Services.Interfaces;
using System.Threading.Tasks;
using System;

namespace Services.Services {
    public class OperationTypesService : AbstractService<OperationType, OperationTypeDTO>, IOperationTypesService{
        IRepositoryWrapper _repository;
        public OperationTypesService(IRepositoryWrapper repository, IMapper mapper) 
            : base(repository.OperationTypes, mapper) {
            _repository = repository;
        }

        public async Task<OperationTypeDTO> CreateOperationTypeAsync(OperationTypeForCreateDTO operationTypeDTO) {
            //var operationType = await getOperationType(operationTypeDTO.Name);

            var item = Mapper.Map<OperationType>(operationTypeDTO);
            var modelItem = await _repository.OperationTypes.CreateAsync(item);
            return Mapper.Map<OperationTypeDTO>(modelItem);
        }

        public async Task<OperationTypeDTO> UpdateOperationTypeAsync(Guid id, OperationTypeForUpdateDTO operationTypeDTO) {
            var operationType = await getOperationType(operationTypeDTO.Name);

            var item = Mapper.Map<OperationType>(operationTypeDTO);
            item.Id = id;

            var modelItem = await _repository.OperationTypes.UpdateAsync(item);
            return Mapper.Map<OperationTypeDTO>(modelItem);
        }

        private async Task<OperationType> getOperationType(string operationTypeName) {
            var operationType = await _repository.OperationTypes.GetOperationTypeByNameAsync(operationTypeName);
            if (operationType is not null) {
                throw new Exception($"Operation type with name {operationTypeName} already exists.");
            }
            return operationType;
        }
    }
}
