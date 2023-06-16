using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Entidades;
using Excepciones;


namespace ArchivosYSerializacion
{
    public class SerializacionXML<T> : IArchivo<T>
    {
        XmlTextWriter escribirObjeto;
        XmlSerializer serializarObjeto;
        XmlTextReader leerObjeto;

        /// <summary>
        /// Serializa un dato y guarda un archivo de tipo XML.
        /// </summary>
        /// <param name="dato">Dato a serializar</param>
        /// <param name="path">Ruta de guardado</param>
        /// <param name="append">Guarda el dato desde la ultima linea del path, si el archivo exieste.</param>
        public void Guardar(T dato, string path, bool append)
        {
            try
            {
                escribirObjeto = new XmlTextWriter(path, System.Text.Encoding.UTF8);
                serializarObjeto = new XmlSerializer(typeof(T));
                serializarObjeto.Serialize(escribirObjeto, dato);
                escribirObjeto.Close();
            }
            catch (Exception ex)
            {
                throw new GuardarSerializacionException("Error al querer guardar el archivo XML", ex);
            }
        }

        /// <summary>
        /// Deserializa un archivo XML.
        /// </summary>
        /// <param name="path">Ruta donde se encuentra el archivo a leer.</param>
        /// <returns></returns>
        public T Leer(string path)
        {
            T generico;
           
            try
            {
                leerObjeto = new XmlTextReader(path);
                serializarObjeto = new XmlSerializer(typeof(T));
                generico = (T)serializarObjeto.Deserialize(leerObjeto);
                leerObjeto.Close();
            }
            catch (Exception ex)
            {
                throw new CargarSerializacionException("Error al querer cargar el archivo XML",ex);
            }
            return generico;
        }
    }
}
