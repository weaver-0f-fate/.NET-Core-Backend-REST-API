using System;

namespace Core.Exceptions {
    public class AddingExistingItemException : AbstractBadRequestException {
        public AddingExistingItemException(string msg) : base(msg) { }
    }
}
