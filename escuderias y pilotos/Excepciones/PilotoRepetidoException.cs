using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class PilotoRepetidoException : Exception
    {
        public PilotoRepetidoException(string message) : base(message)
        {
        }

        public PilotoRepetidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
