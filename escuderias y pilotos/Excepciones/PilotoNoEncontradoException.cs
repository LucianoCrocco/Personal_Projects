using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class PilotoNoEncontradoException : Exception
    {
        public PilotoNoEncontradoException(string message) : base(message)
        {
        }

        public PilotoNoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
