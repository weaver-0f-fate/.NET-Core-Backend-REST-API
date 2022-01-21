using System;

namespace Core.Models {
    public abstract class AbstractModel {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
