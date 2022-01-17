using Models;
using Services.Intrefaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IOperationsService : IService<Operation>{
        public Task<IEnumerable<Operation>> GetOperationsAtDateAsync(DateTime date);
        public Task<IEnumerable<Operation>> GetOperationsAtPeriodAsync(DateTime startDate, DateTime endDate);
    }
}
