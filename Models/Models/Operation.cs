using System;

namespace Core.Models {
    public class Operation : AbstractModel {
        public Guid OperationTypeId { get; set; }
        public OperationType OperationType { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        
    }
}
