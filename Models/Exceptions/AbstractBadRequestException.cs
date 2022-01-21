using System;

namespace Core.Exceptions {
    public abstract class AbstractBadRequestException : Exception{
        public AbstractBadRequestException(string msg) : base(msg) { }
    }
}
