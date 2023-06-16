using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class EstadisticasEscuderias
    {
        private List<Escuderia> lista;
        /// <summary>
        /// Constructor por defecto para el promedio de las escuderias
        /// </summary>
        /// <param name="listaEscuderias">Lista de Escuderia</param>
        public EstadisticasEscuderias(List<Escuderia> listaEscuderias)
        {
            this.Lista = listaEscuderias;
        }

        public List<Escuderia> Lista
        {
            set
            {
                this.lista = value;
            }
            get
            {
                return this.lista;
            }
        }

        #region Metodos
        /// <summary>
        /// Buscar el maximo de asientos disponibles dentro de la lista de escuderias 
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string MaximoAsientosDisponiblesPiloto()
        {
            int maximo = int.MinValue;
            foreach (Escuderia item in lista)
            {
                if (item.CantidadPilotos > maximo)
                {
                    maximo = item.CantidadPilotos;
                }
            }
            return $"El maximo de asientos disponibles registrado en la lista de escuderias es de {maximo} asientos.";
        }

        /// <summary>
        /// Buscar el minimo de asientos disponibles dentro de la lista de escuderias 
        /// </summary>
        /// <returns>Mensaje con el resultado</returns>
        public string MinimoAsientosDisponiblesPiloto()
        {
            int minimo = int.MaxValue;
            foreach (Escuderia item in lista)
            {
                if (item.CantidadPilotos < minimo)
                {
                    minimo = item.CantidadPilotos;
                }
            }
            return $"El minimo de asientos disponibles registrado en la lista de escuderias es de {minimo} asientos.";
        }

        /// <summary>
        /// Buscar el promedio de asientos disponibles dentro de la lista de escuderias 
        /// </summary>
        /// <returns>Mensaje con el resultado</returns>
        public string PromedioAsientosDisponiblesPiloto()
        {
            if(lista.Count > 0)
            {
                float promedio = 0;
                int acumulador = 0;
                foreach (Escuderia item in lista)
                {
                    acumulador += item.CantidadPilotos;
                }
                promedio = (float)acumulador / this.lista.Count;
                return $"El promedio de asientos disponibles registrado en la lista de escuderias es de {promedio} asientos.";
            }
            return $"La lista se encuentra vacia, no se puede realizar el promedio de asientos disponibles.";
        }

        /// <summary>
        /// Buscar el maximo de asientos ocupados por pilotos dentro de la lista de escuderias
        /// </summary>
        /// <returns>Mensaje con el resultado</returns>
        public string MaximoAsientosOcupadosPiloto()
        {
            int maximo = int.MinValue;
            foreach (Escuderia item in lista)
            {
                if (item.Pilotos.Count > maximo)
                {
                    maximo = item.Pilotos.Count;
                }
            }
            return $"El maximo de asientos ocupados registrado en la lista de escuderias es de {maximo} asientos.";
           
        }

        /// <summary>
        /// Buscar el minimo de asientos ocupados por pilotos dentro de la lista de escuderias
        /// </summary>
        /// <returns>Mensaje con el resultado</returns>
        public string MinimoAsientosOcupadosPiloto()
        {
            int minimo = int.MaxValue;
            foreach (Escuderia item in lista)
            {
                if (item.Pilotos.Count < minimo)
                {
                    minimo = item.CantidadPilotos;
                }
            }
            return $"El minimo de asientos ocupados registrado en la lista de escuderias es de {minimo} asientos.";
            
        }

        /// <summary>
        /// Buscar el promedio de asientos ocupados por pilotos dentro de la lista de escuderias
        /// </summary>
        /// <returns>Mensaje con el resultado</returns>
        public string PromedioAsientosOcupadosPiloto()
        {
            if(lista.Count > 0)
            {
                float promedio = 0;
                int acumuladorOcupado = 0;
                int acumuladorDisponible = 0;
                foreach (Escuderia item in lista)
                {
                    acumuladorOcupado += item.Pilotos.Count;
                    acumuladorDisponible += item.CantidadPilotos;
                }
                promedio = (float)acumuladorOcupado / acumuladorDisponible;
                return $"El promedio de asientos ocupados registrado en la lista de escuderias es de {promedio} asientos.";
            }
            return $"La lista se encuentra vacia, no se puede realizar el promedio de asientos ocupados.";
        }

        #endregion
    }
}
