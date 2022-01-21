using AutoMapper;
using Core.Models;
using Services.Interfaces;
using Services.DataTransferObjects.OperationDTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Interfaces;
using Services.DataTransferObjects;
using Core.Exceptions;

namespace Services.Services {
    public class OperationsService : AbstractService<Operation, OperationDTO>, IOperationsService {
        private IOperationsRepository _operationsRepository;
        private IOperationTypesRepository _operationTypesRepository;

        public OperationsService(IOperationsRepository operationsRepository, IOperationTypesRepository operationTypesRepository, IMapper mapper) 
            : base(operationsRepository, mapper) {
            _operationsRepository = operationsRepository;
            _operationTypesRepository = operationTypesRepository;
        }

        public async Task<OperationDTO> CreateOperationAsync(OperationForCreateDTO operationDTO) {
            var operationType = await getOperationType(operationDTO.OperationTypeId);
            var operation = Mapper.Map<Operation>(operationDTO);
            operation.OperationTypeId = operationType.Id;

            var modelItem = await _operationsRepository.CreateAsync(operation);
            
            return Mapper.Map<OperationDTO>(modelItem);
        }

        public async Task<OperationDTO> UpdateOperationAsync(Guid id, OperationForUpdateDTO operationDTO) {
            var operationType = await getOperationType(operationDTO.OperationTypeId);
            var item = Mapper.Map<Operation>(operationDTO);
            item.Id = id;
            item.OperationTypeId = operationType.Id;

            var modelItem = await _operationsRepository.UpdateAsync(item);
            return Mapper.Map<OperationDTO>(modelItem);
        }

        private async Task<OperationType> getOperationType(Guid operationTypeId) {
            var operationType = await _operationTypesRepository.GetByIdAsync(operationTypeId);
            if (operationType is null) {
                throw new UnknownOperationTypeException("Required operation type doesn't exist");
            }
            return operationType;
        }

        public async Task<OutcomeDTO> GetOutcomeAtDateAsync(DateTime date) {
            var operations = await _operationsRepository.GetAtDateAsync(date);
            return CreateOutcome(operations, date, date);
        }

        public async Task<OutcomeDTO> GetOutcomeAtPeriodAsync(DateTime startDate, DateTime endDate) {
            var operations = await _operationsRepository.GetAtPeriodAsync(startDate, endDate);
            return CreateOutcome(operations, startDate, endDate);
        }

        private OutcomeDTO CreateOutcome(IEnumerable<Operation> operations, DateTime startDate, DateTime endDate) {
            var operationDTOs = Mapper.Map<IEnumerable<OperationDTO>>(operations);
            double totalIncome = 0, totalExpenses = 0;

            foreach (var operation in operations) {
                if (operation.OperationType.IsIncome) {
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
