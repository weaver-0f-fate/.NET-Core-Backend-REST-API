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
            await CheckForUniqueName(operationTypeDTO.Name);
            
            var operationType = Mapper.Map<OperationType>(operationTypeDTO);
            var createdOperationType = await _repository.OperationTypes.CreateAsync(operationType);
            return Mapper.Map<OperationTypeDTO>(createdOperationType);
        }

        public async Task<OperationTypeDTO> UpdateOperationTypeAsync(Guid id, OperationTypeForUpdateDTO operationTypeDTO) {
            await CheckForUniqueName(operationTypeDTO.Name);

            var operationType = Mapper.Map<OperationType>(operationTypeDTO);
            operationType.Id = id;

            var updatedOperationType = await _repository.OperationTypes.UpdateAsync(operationType);
            return Mapper.Map<OperationTypeDTO>(updatedOperationType);
        }

        private async Task CheckForUniqueName(string operationTypeName) {
            var operationType = await _repository.OperationTypes.GetOperationTypeByNameAsync(operationTypeName);
            if (operationType is not null) {
                throw new Exception($"Operation type with name {operationTypeName} already exists.");
            }
        }
    }
}
