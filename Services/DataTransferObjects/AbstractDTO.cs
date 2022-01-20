using System;

namespace Services.DataTransferObjects {
    public abstract class AbstractDTO {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
