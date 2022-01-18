using Core.Models.Models;
using Services.Intrefaces;
using Services.DataTransferObjects;
using System;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IOperationsService : IService<Operation, OperationDTO>{
        public Task<OutcomeDTO> GetAtDateAsync(DateTime date);
        public Task<OutcomeDTO> GetAtPeriodAsync(DateTime startDate, DateTime endDate);
    }
}
