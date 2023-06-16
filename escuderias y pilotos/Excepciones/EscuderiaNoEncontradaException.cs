using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class EscuderiaNoEncontradaException : Exception
    {
        public EscuderiaNoEncontradaException(string message) : base(message)
        {
        }

        public EscuderiaNoEncontradaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
