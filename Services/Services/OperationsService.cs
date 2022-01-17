using Data.Repositories;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services {
    public class OperationsService : AbstractService<Operation>, IOperationsService {
        private IOperationsRepository _repository;
        public OperationsService(IOperationsRepository repository) : base(repository) {
            _repository = repository;
        }

        public async Task<Outcome> GetOperationsAtDateAsync(DateTime date) {
            var operations = await _repository.GetOperationsAtSpefcifiedDateAsync(date);
            return CalculateOutcome(operations, date, date);
        }

        public async Task<Outcome> GetOperationsAtPeriodAsync(DateTime startDate, DateTime endDate) {
            var operations = await _repository.GetOperationsAtSpefcifiedPeriodAsync(startDate, endDate);
            return CalculateOutcome(operations, startDate, endDate);
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
