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
            var opType = await _repository.OperationTypes.GetOperationTypeByNameAsync(operationDTO.OperationType);
            if (opType is null) {
                throw new Exception("Required operation type doesn't exist");
            }

            var operation = Mapper.Map<OperationDTO>(operationDTO);
            var item = Mapper.Map<Operation>(operation);
            item.OperationTypeId = opType.Id;

            var modelItem = await _repository.Operations.CreateOperationAsync(item);
            return Mapper.Map<OperationDTO>(modelItem);
        }

        public async Task<OperationDTO> UpdateOperationAsync(int id, OperationForUpdateDTO operationForUpdateDTO) {
            var opType = await _repository.OperationTypes.GetOperationTypeByNameAsync(operationForUpdateDTO.OperationType);
            if (opType is null) {
                throw new Exception("Required operation type doesn't exist");
            }
            

            var operationDTO = Mapper.Map<OperationDTO>(operationForUpdateDTO);
            operationDTO.Id = id;
            var item = Mapper.Map<Operation>(operationDTO);
            item.OperationTypeId = opType.Id;

            var modelItem = await _repository.Operations.UpdateOperationAsync(item);
            return Mapper.Map<OperationDTO>(modelItem);
        }

        public async Task<OutcomeDTO> GetAtDateAsync(DateTime date) {
            var operations = await _repository.Operations.GetAtDateAsync(date);
            return CalculateOutcome(operations, date, date);
        }

        public async Task<OutcomeDTO> GetAtPeriodAsync(DateTime startDate, DateTime endDate) {
            var operations = await _repository.Operations.GetAtPeriodAsync(startDate, endDate);
            return CalculateOutcome(operations, startDate, endDate);
        }

       
        private OutcomeDTO CalculateOutcome(IEnumerable<Operation> operations, DateTime startDate, DateTime endDate) {
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
