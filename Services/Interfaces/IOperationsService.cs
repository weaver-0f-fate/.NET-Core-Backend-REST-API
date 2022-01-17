using Core.Models;
using Services.Intrefaces;
using Services.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IOperationsService : IService<Operation, OperationDTO>{
        public Task<OutcomeDTO> GetOperationsAtDateAsync(DateTime date);
        public Task<OutcomeDTO> GetOperationsAtPeriodAsync(DateTime startDate, DateTime endDate);
    }
}
