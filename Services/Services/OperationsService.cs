using AutoMapper;
using Core.Models;
using Services.Interfaces;
using Services.DataTransferObjects.OperationDTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Interfaces;
using Services.DataTransferObjects;

namespace Services.Services {
    public class OperationsService : AbstractService<Operation, OperationDTO>, IOperationsService {
        private IRepositoryWrapper _repository;
        public OperationsService(IRepositoryWrapper repository, IMapper mapper) 
            : base(repository.Operations, mapper) {
            _repository = repository;
        }

        public async Task<OperationDTO> CreateOperationAsync(OperationForCreateDTO operationDTO) {
            var operationType = await getOperationType(operationDTO.OperationTypeName);
            var operation = Mapper.Map<Operation>(operationDTO);
            operation.OperationTypeId = operationType.Id;

            var modelItem = await _repository.Operations.CreateAsync(operation);
            
            return Mapper.Map<OperationDTO>(modelItem);
        }

        public async Task<OperationDTO> UpdateOperationAsync(Guid id, OperationForUpdateDTO operationDTO) {
            var operationType = await getOperationType(operationDTO.OperationTypeName);
            var item = Mapper.Map<Operation>(operationDTO);
            item.Id = id;
            item.OperationTypeId = operationType.Id;

            var modelItem = await _repository.Operations.UpdateAsync(item);
            return Mapper.Map<OperationDTO>(modelItem);
        }

        private async Task<OperationType> getOperationType(string operationTypeName) {
            var operationType = await _repository.OperationTypes.GetOperationTypeByNameAsync(operationTypeName);
            if (operationType is null) {
                throw new Exception("Required operation type doesn't exist");
            }
            return operationType;
        }

        public async Task<OutcomeDTO> GetOutcomeAtDateAsync(DateTime date) {
            var operations = await _repository.Operations.GetAtDateAsync(date);
            return CreateOutcome(operations, date, date);
        }

        public async Task<OutcomeDTO> GetOutcomeAtPeriodAsync(DateTime startDate, DateTime endDate) {
            var operations = await _repository.Operations.GetAtPeriodAsync(startDate, endDate);
            return CreateOutcome(operations, startDate, endDate);
        }

        private OutcomeDTO CreateOutcome(IEnumerable<Operation> operations, DateTime startDate, DateTime endDate) {
            var operationDTOs = Mapper.Map<IEnumerable<OperationDTO>>(operations);
            double totalIncome = 0, totalExpenses = 0;

            foreach (var operation in operationDTOs) {
                if (operation.Amount >= 0) {
                    totalIncome += operation.Amount;
                }
                else {
                    totalExpenses += operation.Amount;
                }
            }

            return new OutcomeDTO {
                StartDate = startDate,
                EndDate = endDate,
                Operations = new List<OperationDTO>(operationDTOs),
                TotalExpenses = totalExpenses,
                TotalIncome = totalIncome
            };
        }
    }
}
