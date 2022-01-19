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
            var x = await _repository.OperationTypes.GetOperationTypeByNameAsync(operationTypeDTO.Name);
            if(x is not null) {
                throw new Exception($"Operation type with name {operationTypeDTO.Name} already exists.");
            }

            var dto = Mapper.Map<OperationTypeDTO>(operationTypeDTO);
            var item = Mapper.Map<OperationType>(dto);
            var modelItem = await _repository.OperationTypes.CreateOperationTypeAsync(item);
            return Mapper.Map<OperationTypeDTO>(modelItem);
        }

        public async Task<OperationTypeDTO> UpdateOperationTypeAsync(int id, OperationTypeForUpdateDTO operationTypeForUpdateDTO) {
            var opType = await _repository.OperationTypes.GetOperationTypeByNameAsync(operationTypeForUpdateDTO.Name);
            if (opType is not null) {
                throw new Exception($"Operation type with name {operationTypeForUpdateDTO.Name} already exists.");
            }

            var operationTypeDTO = Mapper.Map<OperationTypeDTO>(operationTypeForUpdateDTO);
            operationTypeDTO.Id = id;
            var item = Mapper.Map<OperationType>(operationTypeDTO);

            var modelItem = await _repository.OperationTypes.UpdateOperationTypeAsync(item);
            return Mapper.Map<OperationTypeDTO>(modelItem);
        }
    }
}
