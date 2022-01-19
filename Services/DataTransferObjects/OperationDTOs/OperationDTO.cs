using System;

namespace Services.DataTransferObjects.OperationDTOs {
    public class OperationDTO : AbstractDTO {
        public string OperationTypeName { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
