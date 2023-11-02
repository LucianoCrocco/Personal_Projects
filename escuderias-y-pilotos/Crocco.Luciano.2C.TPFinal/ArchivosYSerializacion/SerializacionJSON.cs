using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Entidades;
using Excepciones;

namespace ArchivosYSerializacion
{
    public class SerializacionJSON<T> : IArchivo<T>
    {
        ArchivoTexto archivoTexto;
        public SerializacionJSON()
        {
            this.archivoTexto = new ArchivoTexto();
        }
        /// <summary>
        /// Serializa un archivo JSON.
        /// </summary>
        /// <param name="dato">Dato a serializar</param>
        /// <param name="path">Ruta de guardado</param>
        /// <param name="append">Guarda el dato desde la ultima linea del path, si el archivo exieste.</param>
        void IArchivo<T>.Guardar(T dato, string path, bool append)
        {
            string aux;
            try
            {
                aux = JsonSerializer.Serialize(dato);
                archivoTexto.Guardar(aux, path, append);

            } catch(Exception ex)
            {
                throw new GuardarSerializacionException("Error al querer guardar el archivo Json", ex);
            }
        }

        /// <summary>
        /// Deserializa un archivo JSON.
        /// </summary>
        /// <param name="path">Ruta donde se encuentra el archivo a leer.</param>
        /// <returns>Retorna un string con los datos deserializados.</returns>
        T IArchivo<T>.Leer(string path)
        {
            T generico;
            string aux;
            try
            {
                aux = archivoTexto.Leer(path);
                generico = JsonSerializer.Deserialize<T>(aux);
            }
            catch (Exception ex)
            {
                throw new CargarSerializacionException("Error al querer cargar el archivo Json", ex);
            }
            return generico;
        }
    }
}
