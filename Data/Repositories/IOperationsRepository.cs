using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories {
    public interface IOperationsRepository : IRepository<Operation>{
        public Task<IEnumerable<Operation>> GetOperationsAtSpefcifiedDateAsync(DateTime date);
        public Task<IEnumerable<Operation>> GetOperationsAtSpefcifiedPeriodAsync(DateTime startDate, DateTime endDate);
    }
}
