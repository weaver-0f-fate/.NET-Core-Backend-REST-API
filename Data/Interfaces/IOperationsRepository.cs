using Core.Models.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces {
    public interface IOperationsRepository : IRepository<Operation> {
        public Task<IEnumerable<Operation>> GetOperationsAtDateAsync(DateTime date);
        public Task<IEnumerable<Operation>> GetOperationsAtPeriodAsync(DateTime startDate, DateTime endDate);
    }
}
