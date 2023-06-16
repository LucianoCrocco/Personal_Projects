using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public class Piloto
    {
        #region Atributos
        protected string nombre;
        protected string apellido;
        protected int edad;
        protected ESexo sexo;
        protected int numeroCompeticion;
        protected bool competidorNacional;
        private static int maximoCaracteres;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor estatico que inicializa el maximo de caracteres disponibles para asignar a un nombre.
        /// </summary>
        static Piloto()
        {
            maximoCaracteres = 65;
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Piloto() { }
        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="nombre">Nombre del piloto</param>
        /// <param name="apellido">Apellido del piloto</param>
        /// <param name="edad">Edad del piloto</param>
        /// <param name="sexo">Sexo del piloto</param>
        /// <param name="numeroDeCompeticion">Numero de competicion elegido por el piloto</param>
        /// <param name="competidorNacional">Argentino o Extranjero</param>
        public Piloto (string nombre, string apellido, int edad, ESexo sexo, int numeroDeCompeticion, bool competidorNacional)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
            this.Sexo = sexo;
            this.NumeroCompeticion = numeroDeCompeticion;
            this.CompetidorNacional = competidorNacional;
        }
        #endregion

        #region Propiedades

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                try 
                {
                    if (Piloto.ValidarNombre(value) && value.Length < 60)
                    {
                        this.nombre = value;
                    }
                }
                catch (CaracteresInvalidoException ex)
                {
                    throw new CaracteresInvalidoException("El nombre ingresado es invalido", ex);
                } 
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                try
                {
                    if (Piloto.ValidarNombre(value) && value.Length < 60) 
                    {
                        this.apellido = value;
                    }
                }
                catch (CaracteresInvalidoException ex)
                {
                    throw new CaracteresInvalidoException("El apellido ingresado es invalido", ex);
                }
            }
        }

        public int Edad
        {
            get
            {
                return this.edad;
            }
            set
            {
                this.edad = value;
            }
        }

        public int NumeroCompeticion
        {
            get
            {
                return this.numeroCompeticion;
            }
            set
            {
                this.numeroCompeticion = value;
            }
        }

        public ESexo Sexo
        {
            get
            {
                return this.sexo;
            }
            set
            {
                this.sexo = value;
            }
        }

        public bool CompetidorNacional
        {
            get
            {
                return this.competidorNacional;
            }
            set
            {
                this.competidorNacional = value;
            }
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Compara dos pilotos. Dos pilotos son iguales si comparten el mismo numero de competicion o el mismo numero, nombre y apellido.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>True si son iguales, false si no lo son.</returns>
        public static bool operator == (Piloto p1, Piloto p2)
        {
            if(p1 is not null && p2 is not null)
            {
                if(p1.NumeroCompeticion == p2.NumeroCompeticion || (p1.Nombre == p2.Nombre && p1.Apellido == p2.Apellido && p1.NumeroCompeticion == p2.NumeroCompeticion))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Compara dos pilotos. Dos pilotos son distintos si no comparten el mismo numero de competicion.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>False si son iguales, true si no lo son.</returns>
        public static bool operator !=(Piloto p1, Piloto p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Suma a la lista de pilotos un piloto
        /// </summary>
        /// <param name="pilotos"></param>
        /// <param name="p1"></param>
        /// <returns>La lista con los cambios realizados</returns>
        public static List<Piloto> operator +(List<Piloto> pilotos, Piloto p1)
        {
            if(pilotos is not null && p1 is not null)
            {
                if(pilotos == p1)
                {
                    throw new PilotoRepetidoException("El numero del piloto ya se encuentra en la lista");
                }
                pilotos.Add(p1);
            }

            return pilotos;
        }
        /// <summary>
        /// Borra de la lista de pilotos un piloto
        /// </summary>
        /// <param name="pilotos"></param>
        /// <param name="p1"></param>
        /// <returns>La lista con los cambios realizados.</returns>
        public static List<Piloto> operator -(List<Piloto> pilotos, Piloto p1)
        {
            if (pilotos is not null && p1 is not null)
            {
                if(pilotos == p1)
                {
                    pilotos.Remove(p1);
                    return pilotos;
                }
                throw new PilotoNoEncontradoException("El piloto no se encuentra en la lista");
            }

            return pilotos;
        }

        /// <summary>
        /// Compara una lista de pilotos con un piloto. Busca si el piloto esta contenido dentro de la lista.
        /// </summary>
        /// <param name="pilotos">Lista de pilotos.</param>
        /// <param name="p1">Piloto a buscar.</param>
        /// <returns>True si esta contenido, false si no lo esta.</returns>
        public static bool operator ==(List<Piloto> pilotos, Piloto p1)
        {
            if (pilotos is not null && p1 is not null)
            {
                foreach (Piloto item in pilotos)
                {
                    if (item == p1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Compara una lista de pilotos con un piloto. Busca si NO el piloto esta contenido dentro de la lista.
        /// </summary>
        /// <param name="pilotos">Lista de pilotos.</param>
        /// <param name="p1">Piloto a buscar.</param>
        /// <returns>False si esta contenido, True si no lo esta.</returns>
        public static bool operator !=(List<Piloto> pilotos, Piloto p1)
        {
            return !(pilotos == p1);
        }

        /// <summary>
        /// Compara dos pilotos. Dos pilotos son iguales si comparten el mismo numero de competicion, nombre y apellido.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>True si son iguales, false si no lo son.</returns>
        public static bool operator ^(Piloto p1, Piloto p2)
        {
            if (p1 is not null && p2 is not null)
            {
                if (p1.Nombre == p2.Nombre && p1.Apellido == p2.Apellido && p1.NumeroCompeticion == p2.NumeroCompeticion)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de un piloto.
        /// </summary>
        /// <returns>Mensaje con los datos del piloto.</returns>
        public string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Nombre} {this.Apellido}, {this.Edad} años, sexo: {this.Sexo}, numero de competicion: {this.NumeroCompeticion}, ¿es argentino?: {(this.CompetidorNacional ? "Si":"No")}");
            return sb.ToString();
        }

        /// <summary>
        /// Valida que el nombre ingresado contenga los caracteres correctos.
        /// </summary>
        /// <param name="value">Valor a comparar</param>
        /// <returns>True si los caracteres se encuentran en el rango correcto.</returns>
        public static bool ValidarNombre(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new CaracteresInvalidoException("Los cadena de caracteres ingresados se encuentra vacia");
            } 
            else if(value.Length > maximoCaracteres)
            {
                throw new CaracteresInvalidoException($"Los cadena de caracteres ingresados excede el maximo permitido de {maximoCaracteres} caracteres");
            }
            else
            {
                foreach(char caracter in value)
                {
                    if((caracter < 65 || caracter > 90) && (caracter < 97 || caracter > 122))
                    {
                        throw new CaracteresInvalidoException("Los cadena de caracteres ingresados contiene caracteres invalidos");
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Muestra todos los pilotos contenidas en una lista.
        /// </summary>
        /// <param name="pilotos"></param>
        /// <returns>Mensaje con la lista de las escuderias.</returns>
        public static string MostrarTodosListaPilotos(List<Piloto> pilotos)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n\tLista de pilotos cargados en el sistema");
            foreach(Piloto item in pilotos)
            {
                sb.Append(item.MostrarDatos());
            }
            return sb.ToString();
        }

        #endregion
    }
}
