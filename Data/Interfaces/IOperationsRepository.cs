using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces {
    public interface IOperationsRepository : IRepository<Operation> {
        public Task<IEnumerable<Operation>> GetAtDateAsync(DateTime date);
        public Task<IEnumerable<Operation>> GetAtPeriodAsync(DateTime startDate, DateTime endDate);
    }
}
