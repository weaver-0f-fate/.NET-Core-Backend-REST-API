using System;

namespace Core.Exceptions {
    public class EntityNotFoundException : Exception{
        public EntityNotFoundException(string msg) : base(msg) { }
    }
}
