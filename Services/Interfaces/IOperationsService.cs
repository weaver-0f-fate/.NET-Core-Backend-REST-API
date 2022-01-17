using Models;
using Services.Intrefaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IOperationsService : IService<Operation>{
        public Task<Outcome> GetOperationsAtDateAsync(DateTime date);
        public Task<Outcome> GetOperationsAtPeriodAsync(DateTime startDate, DateTime endDate);
    }
}
