using AutoMapper;
using Data.Interfaces;
using Core.Models;
using Services.DataTransferObjects.OperationTypesDTOs;
using Services.Interfaces;
using System.Threading.Tasks;
using System;
using Core.Exceptions;

namespace Services.Services {
    public class OperationTypesService : AbstractService<OperationType, OperationTypeDTO>, IOperationTypesService{
        IOperationTypesRepository _operationTypesRepository;
        public OperationTypesService(IOperationTypesRepository operationTypesRepository, IMapper mapper) 
            : base(operationTypesRepository, mapper) {
            _operationTypesRepository = operationTypesRepository;
        }

        public async Task<OperationTypeDTO> CreateOperationTypeAsync(OperationTypeForCreateDTO operationTypeDTO) {
            await CheckForUniqueName(operationTypeDTO.Name);
            
            var operationType = Mapper.Map<OperationType>(operationTypeDTO);
            var createdOperationType = await _operationTypesRepository.CreateAsync(operationType);
            return Mapper.Map<OperationTypeDTO>(createdOperationType);
        }

        public async Task<OperationTypeDTO> UpdateOperationTypeAsync(Guid id, OperationTypeForUpdateDTO operationTypeDTO) {
            await CheckForUniqueName(operationTypeDTO.Name);

            var operationType = Mapper.Map<OperationType>(operationTypeDTO);
            operationType.Id = id;

            var updatedOperationType = await _operationTypesRepository.UpdateAsync(operationType);
            return Mapper.Map<OperationTypeDTO>(updatedOperationType);
        }

        private async Task CheckForUniqueName(string operationTypeName) {
            var operationType = await _operationTypesRepository.GetOperationTypeByNameAsync(operationTypeName);
            if (operationType is not null) {
                throw new AddingExistingItemException($"Operation type with name {operationTypeName} already exists.");
            }
        }
    }
}
