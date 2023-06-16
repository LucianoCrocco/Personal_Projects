using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class GuardarSerializacionException : Exception
    {
        public GuardarSerializacionException(string message) : base(message)
        {
        }

        public GuardarSerializacionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
