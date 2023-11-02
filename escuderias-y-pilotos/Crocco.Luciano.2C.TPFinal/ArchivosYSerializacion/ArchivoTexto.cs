using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;

namespace ArchivosYSerializacion
{
    public class ArchivoTexto : IArchivo<string>
    {
        /// <summary>
        /// Guarda un archivo de texto
        /// </summary>
        /// <param name="dato">Dato a guardar</param>
        /// <param name="path">Ruta de guardado</param>
        /// <param name="append">Genera los datos del archivo de 0 o agrega la informacion al final del ya existente.</param>
        public void Guardar(string dato, string path, bool append)
        {
            if (!String.IsNullOrWhiteSpace(path)){
                try
                {
                    StreamWriter sw = new StreamWriter(path, append);
                    sw.WriteLine(dato);
                    sw.Close();
                }
                catch (PathTooLongException ex)
                {
                    throw new PathTooLongException("El path ingresado supera la longitud maxima", ex);
                }
                catch (SecurityException ex)
                {
                    throw new SecurityException("El path ingresado requiere permisos de administrador", ex);
                }
                catch (NotSupportedException ex)
                {
                    throw new NotSupportedException("La extension ingresada no puede ser guardada en el sistema", ex);
                }
                catch (Exception)
                {
                    throw;
                }
            } else
            {
                throw new Exception("El PATH ingresado esta vacio!");
            }
        }

        /// <summary>
        /// Lee un archivo de texto
        /// </summary>
        /// <param name="path">Ruta de lectura</param>
        /// <returns>Devuelve un string con los datos leidos hasta el final del archivo seleccionado</returns>
        public string Leer(string path)
        {
            string retorno = String.Empty;
            if (!String.IsNullOrWhiteSpace(path))
            {
                try
                {
                    StreamReader sw = new StreamReader(path);
                    retorno = sw.ReadToEnd();
                    sw.Close();
                }
                catch (FileNotFoundException)
                {
                    throw new FileNotFoundException("No se encontro el archivo");
                }
                catch (DirectoryNotFoundException)
                {
                    throw new DirectoryNotFoundException("No se encontro la ruta del archivo");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                throw new Exception("El PATH ingresado esta vacio!");
            }
            return retorno;
        }
    }
}
