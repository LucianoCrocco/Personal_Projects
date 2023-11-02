using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class CargarSerializacionException : Exception
    {
        public CargarSerializacionException(string message) : base(message)
        {
        }

        public CargarSerializacionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
