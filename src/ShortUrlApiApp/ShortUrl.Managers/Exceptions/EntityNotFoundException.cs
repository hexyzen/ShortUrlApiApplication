using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrl.Managers.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        private const string DefaultMessage = "{0} entity not found.";
        public new string Message { get; private set; }
        public new Exception InnerException { get; private set; }

        public EntityNotFoundException(Type entityType)
            : this(entityType, string.Format(DefaultMessage, entityType.Name), null)
        { }

        public EntityNotFoundException(Type entityType, string message)
            : this(entityType, message, null)
        { }

        public EntityNotFoundException(Type entityType, string message, Exception exception)
        {
            InnerException = exception;
            Message = message;
        }
    }
}
