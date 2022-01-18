using AutoMapper;
using Core.Models.Models;
using Services.Interfaces;
using Services.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Data.Interfaces;

namespace Services.Services {
    public class OperationsService : AbstractService<Operation, OperationDTO>, IOperationsService {
        private IRepository<Operation> _repository;
        public OperationsService(IRepository<Operation> repository, IMapper mapper) : base(repository, mapper) {
            _repository = repository;
        }

        public async Task<OutcomeDTO> GetOperationsAtDateAsync(DateTime date) {
            Expression<Func<Operation, bool>> expression = x => x.Date.Date == date.Date;
            var operations = await _repository.GetByConditionAsync(expression);
            var outcome = CalculateOutcome(operations, date, date);
            return Mapper.Map<OutcomeDTO>(outcome);
        }

        public async Task<OutcomeDTO> GetOperationsAtPeriodAsync(DateTime startDate, DateTime endDate) {
            Expression<Func<Operation, bool>> expression = x => 
                x.Date.Date >= startDate.Date && x.Date <= endDate.Date;
            var operations = await _repository.GetByConditionAsync(expression);
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
