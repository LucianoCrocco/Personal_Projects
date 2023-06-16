using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EstadisticasTC : EstadisticasEscuderias
    {
        public EstadisticasTC(List<Escuderia> listaEscuderias) : base(listaEscuderias)
        {
        }

        #region Maximo
        /// <summary>
        /// Busca el auto de Turismo Carretera mas utilizado dentro de una lista del Turismo Carretera.
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string AutosMasUtilizado()
        {
            int contadorFord = 0;
            int contadorChevrolet = 0;
            int contadorTorino = 0;
            int contadorDodge = 0;
            int contadorToyota = 0;
            Dictionary<EMarcaVehiculoTC, int> keyValues = new Dictionary<EMarcaVehiculoTC, int>();
            int maximo = int.MinValue;
            EMarcaVehiculoTC marca = EMarcaVehiculoTC.Ford;

            foreach (EscuderiaTC item in Lista)
            {
                switch (item.MarcaVehiculoTC)
                {
                    case EMarcaVehiculoTC.Ford:
                        contadorFord++;
                        break;
                    case EMarcaVehiculoTC.Chevrolet:
                        contadorChevrolet++;
                        break;
                    case EMarcaVehiculoTC.Torino:
                        contadorTorino++;
                        break;
                    case EMarcaVehiculoTC.Dodge:
                        contadorDodge++;
                        break;
                    default:
                        contadorToyota++;
                        break;
                }
            }

            foreach (EscuderiaTC item in Lista)
            {
                switch (item.MarcaVehiculoTC)
                {
                    case EMarcaVehiculoTC.Ford:
                        contadorFord++;
                        break;
                    case EMarcaVehiculoTC.Chevrolet:
                        contadorChevrolet++;
                        break;
                    case EMarcaVehiculoTC.Torino:
                        contadorTorino++;
                        break;
                    case EMarcaVehiculoTC.Dodge:
                        contadorDodge++;
                        break;
                    default:
                        contadorToyota++;
                        break;
                }
            }
            keyValues.Add(EMarcaVehiculoTC.Ford, contadorFord);
            keyValues.Add(EMarcaVehiculoTC.Chevrolet, contadorChevrolet);
            keyValues.Add(EMarcaVehiculoTC.Torino, contadorTorino);
            keyValues.Add(EMarcaVehiculoTC.Dodge, contadorDodge);
            keyValues.Add(EMarcaVehiculoTC.Toyota, contadorToyota);

            foreach (KeyValuePair<EMarcaVehiculoTC, int> keyValue in keyValues)
            {
                if (maximo < keyValue.Value)
                {
                    maximo = keyValue.Value;
                    marca = keyValue.Key;
                }
            }

            return $"La marca predominante entre las escuderias es {marca} con un total de {maximo} coincidencias.";
        }
        #endregion

        #region Minimo
        /// <summary>
        /// Busca el auto de Turismo Carretera menos utilizado dentro de una lista del Turismo Carretera.
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string AutosMenosUtilizado()
        {
            int contadorFord = 0;
            int contadorChevrolet = 0;
            int contadorTorino = 0;
            int contadorDodge = 0;
            int contadorToyota = 0;
            Dictionary<EMarcaVehiculoTC, int> keyValues = new Dictionary<EMarcaVehiculoTC, int>();
            int minimo = int.MaxValue;
            EMarcaVehiculoTC marca = EMarcaVehiculoTC.Ford;

            foreach (EscuderiaTC item in Lista)
            {
                switch (item.MarcaVehiculoTC)
                {
                    case EMarcaVehiculoTC.Ford:
                        contadorFord++;
                        break;
                    case EMarcaVehiculoTC.Chevrolet:
                        contadorChevrolet++;
                        break;
                    case EMarcaVehiculoTC.Torino:
                        contadorTorino++;
                        break;
                    case EMarcaVehiculoTC.Dodge:
                        contadorDodge++;
                        break;
                    default:
                        contadorToyota++;
                        break;
                }
            }
            keyValues.Add(EMarcaVehiculoTC.Ford, contadorFord);
            keyValues.Add(EMarcaVehiculoTC.Chevrolet, contadorChevrolet);
            keyValues.Add(EMarcaVehiculoTC.Torino, contadorTorino);
            keyValues.Add(EMarcaVehiculoTC.Dodge, contadorDodge);
            keyValues.Add(EMarcaVehiculoTC.Toyota, contadorToyota);

            foreach (KeyValuePair<EMarcaVehiculoTC, int> keyValue in keyValues)
            {
                if (minimo > keyValue.Value)
                {
                    minimo = keyValue.Value;
                    marca = keyValue.Key;
                }
            }
            return $"La marca menos predominante entre las escuderias es {marca} con un total de {minimo} coincidencias";
        }
        #endregion

        #region Promedio
        /// <summary>
        /// Genera un promedio porcentual entre todos los autos utilizados dentro de la lista del Turismo Carretera.
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string PromedioAutosUtilizados()
        {
            StringBuilder sb = new StringBuilder();
            int contadorFord = 0;
            int contadorChevrolet = 0;
            int contadorTorino = 0;
            int contadorDodge = 0;
            int contadorToyota = 0;

            foreach (EscuderiaTC item in Lista)
            {
                switch (item.MarcaVehiculoTC)
                {
                    case EMarcaVehiculoTC.Ford:
                        contadorFord++;
                        break;
                    case EMarcaVehiculoTC.Chevrolet:
                        contadorChevrolet++;
                        break;
                    case EMarcaVehiculoTC.Torino:
                        contadorTorino++;
                        break;
                    case EMarcaVehiculoTC.Dodge:
                        contadorDodge++;
                        break;
                    default:
                        contadorToyota++;
                        break;
                }
            }
            sb.AppendLine($"El {contadorFord * 100 / this.Lista.Count}% utiliza Ford, con un total de {contadorFord} ocurrencias.");
            sb.AppendLine($"El {contadorChevrolet * 100 / this.Lista.Count}% utiliza Chevrolet, con un total de {contadorChevrolet} ocurrencias.");
            sb.AppendLine($"El {contadorTorino * 100 / this.Lista.Count}% utiliza Torino, con un total de {contadorTorino} ocurrencias.");
            sb.AppendLine($"El {contadorDodge * 100 / this.Lista.Count}% utiliza Dodge, con un total de {contadorDodge} ocurrencias.");
            sb.AppendLine($"El {contadorToyota * 100 / this.Lista.Count}% utiliza Toyota, con un total de {contadorToyota} ocurrencias.");
            return sb.ToString();
        }
        #endregion
    }
}
