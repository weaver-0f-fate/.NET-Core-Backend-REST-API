using Core.Models;
using Services.Intrefaces;
using Services.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IOperationsService : IService<Operation, OperationDTO>{
        public Task<Outcome> GetOperationsAtDateAsync(DateTime date);
        public Task<Outcome> GetOperationsAtPeriodAsync(DateTime startDate, DateTime endDate);
    }
}
