using System;
using System.Collections.Generic;

namespace ArchivosYSerializacion
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Guardar un dato generico.
        /// </summary>
        /// <param name="dato">Dato a guardar</param>
        /// <param name="path">Ruta de guardado</param>
        /// <param name="append">Genera los datos del archivo de 0 o agrega la informacion al final del ya existente.</param>
        void Guardar(T dato, string path, bool append);

        /// <summary>
        /// Leer un dato generico
        /// </summary>
        /// <param name="path">Ruta donde se encuentra el archivo a leer.</param>
        /// <returns></returns>
        T Leer(string path);
    }
}
