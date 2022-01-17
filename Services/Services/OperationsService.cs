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

        public async Task<IEnumerable<Operation>> GetOperationsAtDateAsync(DateTime date) {
            return await _repository.GetOperationsAtSpefcifiedDateAsync(date);
        }

        public async Task<IEnumerable<Operation>> GetOperationsAtPeriodAsync(DateTime startDate, DateTime endDate) {
            return await _repository.GetOperationsAtSpefcifiedPeriodAsync(startDate, endDate);
        }
    }
}
