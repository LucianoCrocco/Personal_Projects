using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class EscuderiaRepetidaException : Exception
    {
        public EscuderiaRepetidaException(string message) : base(message)
        {
        }

        public EscuderiaRepetidaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
