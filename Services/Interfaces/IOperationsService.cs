using Core.Models;
using Services.Intrefaces;
using Services.DataTransferObjects.OperationDTOs;
using System;
using System.Threading.Tasks;
using Services.DataTransferObjects;

namespace Services.Interfaces {
    public interface IOperationsService : IService<Operation, OperationDTO>{
        public Task<OperationDTO> CreateOperationAsync(OperationForCreateDTO operationDTO);
        public Task<OperationDTO> UpdateOperationAsync(int id, OperationForUpdateDTO operationDTO);
        public Task<OutcomeDTO> GetAtDateAsync(DateTime date);
        public Task<OutcomeDTO> GetAtPeriodAsync(DateTime startDate, DateTime endDate);
        
    }
}
