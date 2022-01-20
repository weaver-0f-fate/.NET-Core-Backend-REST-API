using System;

namespace Services.DataTransferObjects.OperationDTOs {
    public class OperationForCreateDTO {
        public string Name { get; set; }
        public string OperationTypeName { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
