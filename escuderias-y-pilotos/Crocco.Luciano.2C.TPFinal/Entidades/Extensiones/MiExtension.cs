using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class MiExtension
    {
        /// <summary>
        /// Cuenta los caracteres del string.
        /// </summary>
        /// <param name="str">String a contar caracteres.</param>
        /// <returns>El total de caracteres que contiene el string.</returns>
        public static int ContadorDeCaracteres(this String str)
        {
            int contador = 0;
            foreach(char caracter in str)
            {
                contador++;
            }
            return contador;
        }
    }
}
