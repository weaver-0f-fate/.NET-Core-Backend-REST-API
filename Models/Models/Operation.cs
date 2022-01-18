using System;

namespace Core.Models.Models {
    public class Operation : AbstractModel {
        public int OperationTypeId { get; set; }
        public OperationType OperationType { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        
    }
}
