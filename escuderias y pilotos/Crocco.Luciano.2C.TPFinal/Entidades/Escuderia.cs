using System;
using System.Collections.Generic;
using System.Text;
using Excepciones;

namespace Entidades
{
    public abstract class Escuderia
    {
        #region Atributos
        protected string nombreEscuderia;
        protected int cantidadPilotos;
        protected List<Piloto> pilotosEnEscuderia;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Escuderia
        /// </summary>
        public Escuderia() { }

        /// <summary>
        /// Constructor con parametros de una Escuderia
        /// </summary>
        /// <param name="nombre">Nombre de la escuderia</param>
        /// <param name="cantidadPilotos">Cantidad de pilotos que pueden ocupar asientos en la escuderia.</param>
        public Escuderia(string nombre, int cantidadPilotos)
            :this()
        {
            this.pilotosEnEscuderia = new List<Piloto>();
            this.NombreEscuderia = nombre;
            this.CantidadPilotos = cantidadPilotos;
        }
        #endregion

        #region Propiedades
        public string NombreEscuderia
        {
            get
            {
                return this.nombreEscuderia;
            }
            set
            {
                if(value.Length > 95)
                {
                    throw new CaracteresInvalidoException("El maximo de caracteres para ingresar es de 100 caracteres.");
                }
                else if (String.IsNullOrWhiteSpace(value))
                {
                    throw new CaracteresInvalidoException("Ingrese un nombre valido.");
                } 
                else
                {
                    this.nombreEscuderia = value;
                }
            }
        }
        public int CantidadPilotos
        {
            get
            {
                return this.cantidadPilotos;
            }
            set
            {
                this.cantidadPilotos = value;
            }
        }

        public List<Piloto> Pilotos
        {
            get
            {
                return this.pilotosEnEscuderia;
            }
            set
            {
                this.pilotosEnEscuderia = value;
            }
        }
        #endregion

        #region Sobrecarga operadores
        /// <summary>
        /// Busca con la lista de pilotos de la escuderia el piloto pasado por parametros
        /// </summary>
        /// <param name="escuderia"></param>
        /// <param name="piloto"></param>
        /// <returns>True si el piloto se encuentra en la lista, false si no se encuentra</returns>
        public static bool operator ==(Escuderia escuderia, Piloto piloto)
        {
            if(escuderia is not null && piloto is not null)
            {
                foreach(Piloto item in escuderia.Pilotos)
                {
                    if(item == piloto)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Busca con la lista de pilotos de la escuderia el piloto pasado por parametros
        /// </summary>
        /// <param name="escuderia"></param>
        /// <param name="piloto"></param>
        /// <returns>False si el piloto se encuentra en la lista, true si no se encuentra</returns>
        public static bool operator !=(Escuderia escuderia, Piloto piloto)
        {
            return !(escuderia == piloto);
        }
        /// <summary>
        /// Compara una lista de escuderias con la escuderia recibida por parametros. Dos escuderias son iguales si comparten el mismo nombre.
        /// </summary>
        /// <param name="escuderias"></param>
        /// <param name="e1"></param>
        /// <returns>True si la escuderia se encuentra en la lista, false si no se encuentra</returns>
        public static bool operator ==(List<Escuderia> escuderias, Escuderia e1)
        {
            if (escuderias is not null && e1 is not null)
            {
                foreach (Escuderia item in escuderias)
                {
                    if (item.NombreEscuderia == e1.NombreEscuderia)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Compara una lista de escuderias con la escuderia recibida por parametros. Dos escuderias son distintas si no comparten el mismo nombre.
        /// </summary>
        /// <param name="escuderias"></param>
        /// <param name="e1"></param>
        /// <returns>False si la escuderia se encuentra en la lista, true si no se encuentra</returns>
        public static bool operator !=(List<Escuderia> escuderias, Escuderia e1)
        {
            return !(escuderias == e1);
        }

        /// <summary>
        /// Añade una escuderia a una lista de escuderias
        /// </summary>
        /// <param name="escuderias"></param>
        /// <param name="e1"></param>
        /// <returns>La lista con los cambios realizados.</returns>
        public static List<Escuderia> operator +(List<Escuderia> escuderias, Escuderia e1)
        {
            if (escuderias is not null && e1 is not null)
            {
                if (escuderias == e1)
                {
                    throw new EscuderiaRepetidaException("La escuderia ya se encuentra en la lista");
                }
                escuderias.Add(e1);
            }

            return escuderias;
        }
        /// <summary>
        /// Borra una escuderia a una lista de escuderias
        /// </summary>
        /// <param name="escuderias">Lista de escuderias</param>
        /// <param name="e1">Escuderia a borrar</param>
        /// <returns>La lista con los cambios realizados.</returns>
        public static List<Escuderia> operator -(List<Escuderia> escuderias, Escuderia e1)
        {
            if (escuderias is not null && e1 is not null)
            {
                if (escuderias == e1)
                {
                    escuderias.Remove(e1);
                    return escuderias;
                }
                throw new EscuderiaNoEncontradaException("La escuderia no se encuentra en la lista");
            }
            return escuderias;
        }

        /// <summary>
        /// Suma a la lista de pilotos de una escuderia un piloto
        /// </summary>
        /// <param name="escuderia"></param>
        /// <param name="piloto"></param>
        /// <returns>True si pudo añadir a la lista el piloto, exception si el piloto ya de encuentra en la lista</returns>
        public static bool operator +(Escuderia escuderia, Piloto piloto)
        {
            if(escuderia is not null && piloto is not null)
            {
                foreach(Piloto item in escuderia.Pilotos)
                {
                    if(item == piloto)
                    {
                        throw new PilotoRepetidoException("El piloto ya se encuentra en la lista de la escuderia");
                    }
                }
                escuderia.Pilotos.Add(piloto);
            }

            return true;
        }

        /// <summary>
        /// Borra de la lista de pilotos de una escuderia un piloto
        /// </summary>
        /// <param name="escuderia"></param>
        /// <param name="piloto"></param>
        /// <returns>True si pudo borrar de la lista el piloto, exception si el piloto no se encuentra en la lista</returns>
        public static bool operator -(Escuderia escuderia, Piloto piloto)
        {
            if (escuderia is not null && piloto is not null)
            {
                foreach (Piloto item in escuderia.Pilotos)
                {
                    if (item == piloto)
                    {
                        escuderia.Pilotos.Remove(item);
                        return true;
                    }
                }
                throw new PilotoNoEncontradoException("El piloto no se encuentra en la lista de la escuderia");
            }

            return true;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de la escuderia
        /// </summary>
        /// <returns>Mensaje con los datos de la escuderia</returns>
        public virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Escuderia {this.NombreEscuderia}, con asientos disponibles para {this.CantidadPilotos} pilotos.");
            return sb.ToString();
        }

        /// <summary>
        /// Muestra todos las escuderias contenidas en una lista
        /// </summary>
        /// <param name="escuderia">Lista de Escuderias con mis escuderias</param>
        /// <param name="tipo">Tipo de escuderia</param>
        /// <returns>Mensaje con la lista de las escuderias.</returns>
        public static string MostrarTodosListaEscuderia(List<Escuderia> escuderia, string tipo)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\n\tLista de {tipo} cargados en el sistema");
            foreach (Escuderia item in escuderia)
            {
                sb.Append(item.MostrarDatos());
            }
            return sb.ToString();
        }
        #endregion
    }
}
