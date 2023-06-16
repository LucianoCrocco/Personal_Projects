using System;

namespace Excepciones
{
    public class CaracteresInvalidoException : Exception
    {
        public CaracteresInvalidoException(string message) : base(message)
        {
        }

        public CaracteresInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
