using System;

namespace Services.DataTransferObjects.OperationDTOs {
    public class OperationForCreateDTO {
        public string Name { get; set; }
        public string OperationType { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
