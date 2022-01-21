using Services.DataTransferObjects.OperationDTOs;
using System;
using System.Collections.Generic;

namespace Services.DataTransferObjects {
    public class OutcomeDTO {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalIncome { get; set; }
        public double TotalExpenses { get; set; }
        public List<OperationDTO> Operations { get; set; }
   
    }
}
