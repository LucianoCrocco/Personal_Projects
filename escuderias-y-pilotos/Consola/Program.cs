using System;
using System.Collections.Generic;
using Entidades;
using ArchivosYSerializacion;
using Excepciones;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "Test de consola - TP realizado por Luciano Agustin Crocco 2C";

            #region Instancias
            List<Escuderia> escuderia = new List<Escuderia>()
            {
                new EscuderiaTC("Toyota Gazoo Racing", 5, EMarcaVehiculoTC.Toyota),
                new EscuderiaTC("Ford Racing", 5, EMarcaVehiculoTC.Ford)
            };
            List<Piloto> pilotos = new List<Piloto>()
            {
                new Piloto("Juan", "Perez", 15, ESexo.Masculino, 1, true),
                new Piloto("Jorge", "Perez", 19, ESexo.Masculino, 2, true),
                new Piloto("Ignacio", "Perez", 24, ESexo.Masculino, 3, true),
                new Piloto("Rigoberto", "Perez", 29, ESexo.Masculino, 4, true)
            };

            Escuderia escuderiaRepetida = new EscuderiaTC("Ford Racing", 2, EMarcaVehiculoTC.Ford);
            Piloto pilotoRepetido = new Piloto("Lewis", "Hamilton", 29, ESexo.Masculino, 1, true);

            SerializacionXML<Piloto> serializacionXML = new SerializacionXML<Piloto>();
            SerializacionJSON<Piloto> serializacionJSON = new SerializacionJSON<Piloto>();
            Piloto pilotoDeserializado;

            EstadisticasTC estadisticasTC = new EstadisticasTC(escuderia);
            EstadisticasPilotos estadisticasPilotos = new EstadisticasPilotos(pilotos);
            #endregion

            #region Agregar piloto a Escuderia
            if (escuderia[0] + pilotos[0])
            {
                Console.WriteLine("Piloto añadido correctamente a la escuderia");
            }
            #endregion

            #region Borrar piloto de una escuderia
            if (escuderia[0] - pilotos[0])
            {
                Console.WriteLine("Piloto borrado correctamente a la escuderia");
            }
            #endregion

            #region Comparar misma Escuderia
            if(escuderia == escuderiaRepetida)
            {
                Console.WriteLine("Son la misma escuderia");
            }
            #endregion

            #region Comparar mismo Piloto
            if (pilotoRepetido == pilotos[0])
            {
                Console.WriteLine("Son el mismo piloto");
            }
            #endregion

            #region Serializar XML Piloto
            try
            {
                serializacionXML.Guardar(pilotoRepetido, $"{Environment.CurrentDirectory}\\Serializacion.xml", false);
                Console.WriteLine($"\nPiloto serializado XML correctamente en {Environment.CurrentDirectory}\\Serializacion.xml");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            #region Deserializar XML Piloto
            try
            {
                pilotoDeserializado = serializacionXML.Leer($"{Environment.CurrentDirectory}\\Serializacion.xml");
                Console.WriteLine("\tPiloto deserializado XML correctamente");
                Console.WriteLine(pilotoDeserializado.MostrarDatos());
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion

            #region Serializar JSON
            try
            {
                ((IArchivo<Piloto>)serializacionJSON).Guardar(pilotoRepetido, $"{Environment.CurrentDirectory}\\SerializacionJSON.json", false);
                Console.WriteLine($"\nPiloto serializado correctamente en {Environment.CurrentDirectory}\\SerializacionJSON.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
            #endregion

            #region Deserializar JSON
            try
            {
                pilotoDeserializado = ((IArchivo<Piloto>)serializacionJSON).Leer($"{Environment.CurrentDirectory}\\SerializacionJSON.json");
                Console.WriteLine("\tPiloto deserializado JSON correctamente");
                Console.WriteLine(pilotoDeserializado.MostrarDatos());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            #region Excepcion Piloto Repetido
            try
            {
                pilotos += pilotoRepetido;
                Console.WriteLine("Piloto agregado correctamente");
            }
            catch (PilotoRepetidoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            #region Estadisticas Generales Escuderias
            Console.WriteLine(estadisticasTC.PromedioAutosUtilizados());
            Console.WriteLine(estadisticasTC.MaximoAsientosDisponiblesPiloto());
            #endregion

            #region Estadisticas Pilotos
            Console.WriteLine(estadisticasPilotos.PromedioNacionalidad());
            Console.WriteLine(estadisticasPilotos.PromedioSexo());
            #endregion

            Console.ReadKey();
        }
    }
}
