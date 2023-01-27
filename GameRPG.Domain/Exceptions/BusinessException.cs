using System;
using System.Collections.Generic;
using System.Text;

namespace GameRPG.Domain.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string message, Exception innerException)
         : base(message, innerException)
        {
        }

        public BusinessException(IEnumerable<BusinessValidationMessage> messages) : base()
        {
            this.ValidationError = messages;
        }

        public IEnumerable<BusinessValidationMessage> ValidationError { get; }

    }
    public class BusinessValidationMessage
    {
        public string Property { get; set; }
        public string Message { get; set; }

        public BusinessValidationMessage(string property, string message, params object[] messageParams)
        {
            if (messageParams.Length > 0)
                message = string.Format(message, messageParams);

            this.Message = message;
            this.Property = property;
        }

    }
}
