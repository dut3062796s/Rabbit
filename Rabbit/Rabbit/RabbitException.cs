using System;

namespace Rabbit
{
    /// <summary>
    /// Rabbit异常类。
    /// </summary>
    [Serializable]
    public class RabbitException : ApplicationException
    {
        public RabbitException(string message)
            : base(message)
        {
        }

        public RabbitException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}