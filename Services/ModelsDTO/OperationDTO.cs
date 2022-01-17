using System;

namespace Services.ModelsDTO {
    public class OperationDTO : AbstractDTO {
        public string OperationType { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
