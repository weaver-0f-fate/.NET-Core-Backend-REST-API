using AutoMapper;
using Core.Models.Models;
using Services.Interfaces;
using Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Data.Interfaces;

namespace Services.Services {
    public class OperationsService : AbstractService<Operation, OperationDTO>, IOperationsService {
        private IRepositoryWrapper _repository;
        public OperationsService(IRepositoryWrapper repository, IMapper mapper) 
            : base(repository.Operations, mapper) {
            _repository = repository;
        }

        public async Task<OutcomeDTO> GetOperationsAtDateAsync(DateTime date) {
            var operations = await _repository.Operations.GetOperationsAtDateAsync(date);
            var outcome = CalculateOutcome(operations, date, date);
            return Mapper.Map<OutcomeDTO>(outcome);
        }

        public async Task<OutcomeDTO> GetOperationsAtPeriodAsync(DateTime startDate, DateTime endDate) {
            var operations = await _repository.Operations.GetOperationsAtPeriodAsync(startDate, endDate);
            var outcome = CalculateOutcome(operations, startDate, endDate);
            return Mapper.Map<OutcomeDTO>(outcome);
        }

        private Outcome CalculateOutcome(IEnumerable<Operation> operations, DateTime startDate, DateTime endDate) {
            double totalIncome = 0, totalExpenses = 0;

            foreach (var operation in operations) {
                if (operation.Amount >= 0) {
                    totalIncome += operation.Amount;
                }
                else {
                    totalExpenses += operation.Amount;
                }
            }

            return new Outcome {
                StartDate = startDate,
                EndDate = endDate,
                Operations = new List<Operation>(operations),
                TotalExpenses = totalExpenses,
                TotalIncome = totalIncome
            };
        }
    }
}
