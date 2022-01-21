using System;

namespace Core.Exceptions {
    public class UnknownOperationTypeException : AbstractBadRequestException {
        public UnknownOperationTypeException(string msg) : base(msg) { }
    }
}
