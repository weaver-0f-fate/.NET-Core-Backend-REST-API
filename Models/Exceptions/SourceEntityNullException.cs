using System;

namespace Core.Exceptions {
    public class SourceEntityNullException : AbstractBadRequestException {
        public SourceEntityNullException(string msg) : base(msg) { }
    }
}
