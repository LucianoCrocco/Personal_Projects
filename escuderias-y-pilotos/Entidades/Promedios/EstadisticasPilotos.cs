using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EstadisticasPilotos
    {
        private List<Piloto> lista;
        /// <summary>
        /// Constructor por defecto para realizar el promedio de pilotos
        /// </summary>
        /// <param name="listaPilotos">Lista de pilotos a la cual se debe promediar</param>
        public EstadisticasPilotos(List<Piloto> listaPilotos)
        {
            this.lista = listaPilotos;
        }

        #region Metodos

            #region Maximos
        /// <summary>
        /// Busca la edad maxima dentro de la lista de pilotos
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string MaximoEdad()
        {
            int maximo = int.MinValue;
            foreach (Piloto item in lista)
            {
                if (item.Edad > maximo)
                {
                    maximo = item.Edad;
                }
            }
            return $"La edad maxima registrada en la lista de pilotos es de {maximo} años";
        }
        /// <summary>
        /// Busca la edad maxima dentro de la lista de pilotos
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string MaximoNroCompeticion()
        {
            int maximo = int.MinValue;
            foreach (Piloto item in lista)
            {
                if (item.NumeroCompeticion > maximo)
                {
                    maximo = item.NumeroCompeticion;
                }
            }
            return $"El numero de competicion mas grande elegido fue el {maximo}";
        }

        /// <summary>
        /// Busca el sexo predominante en la lista de pilotos
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string MaximoSexo()
        {
            string retorno = String.Empty;
            int contadorMasc = 0;
            int contadorFem = 0;
            int contadorOtro = 0;
            Dictionary<ESexo, int> keyValues = new Dictionary<ESexo, int>();
            int maximo = int.MinValue;
            ESexo eSexo = ESexo.Otro;

            foreach (Piloto item in lista)
            {
                switch (item.Sexo)
                {
                    case ESexo.Masculino:
                        contadorMasc++;
                        break;
                    case ESexo.Femenino:
                        contadorFem++;
                        break;
                    default:
                        contadorOtro++;
                        break;
                }
            }
            keyValues.Add(ESexo.Masculino, contadorMasc);
            keyValues.Add(ESexo.Femenino, contadorFem);
            keyValues.Add(ESexo.Otro, contadorOtro);

            foreach (KeyValuePair<ESexo, int> keyValue in keyValues)
            {
                if (maximo < keyValue.Value)
                {
                    eSexo = keyValue.Key;
                    maximo = keyValue.Value;
                }
            }

            return $"El genero predominante entre los pilotos es {eSexo} con un total de {maximo} coincidencias";
        }

        /// <summary>
        /// Busca la nacionalidad predominante en la lista de pilotos
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string MaximoNacionalidad()
        {
            string retorno = String.Empty;
            int contadorNac = 0;
            int contadorNoNac = 0;


            foreach (Piloto item in lista)
            {
                switch (item.CompetidorNacional)
                {
                    case true:
                        contadorNac++;
                        break;
                    default:
                        contadorNoNac++;
                        break;
                }
            }

            if (contadorNac >= contadorNoNac)
            {
                retorno = $"La mayor parte de los pilotos son pilotos nacionales con un total de {contadorNac} coincidencias";
            }
            else
            {
                retorno = $"La mayor parte de los pilotos son pilotos internacionales con un total de {contadorNoNac} coincidencias";
            }
            return retorno;
        }

        /// <summary>
        /// Busca el maximo de caracteres de nombre y apellido entre los pilotos de la lista.
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string MaximoNombreYApellido()
        {
            int maximo = 0;
            int aux; 
            foreach (Piloto item in lista)
            {
                aux = item.Nombre.ContadorDeCaracteres();
                aux += item.Apellido.ContadorDeCaracteres();
                if (aux > maximo)
                {
                    maximo = aux;
                }
                aux = 0;
            }
            return $"El nombre y apellido mas largo registrado consta de {maximo} caracteres";
        }
        #endregion

            #region Minimos

        /// <summary>
        /// Busca la edad minima dentro de la lista de pilotos
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string MinimoEdad()
        {
            int minimo = int.MaxValue;
            foreach (Piloto item in lista)
            {
                if (item.Edad < minimo)
                {
                    minimo = item.Edad;
                }
            }
            return $"La edad minima registrada en la lista de pilotos es de {minimo} años";
        }

        /// <summary>
        /// Busca el numero de competicion mas chico dentro de la lista de pilotos
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string MinimoNroCompeticion()
        {
            int minimo = int.MaxValue;
            foreach (Piloto item in lista)
            {
                if (item.NumeroCompeticion < minimo)
                {
                    minimo = item.NumeroCompeticion;
                }
            }
            return $"El numero de competicion mas chico elegido fue el {minimo}";
        }

        /// <summary>
        /// Busca el sexo menos predominante en la lista de pilotos
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string MinimoSexo()
        {
            string retorno = String.Empty;
            int contadorMasc = 0;
            int contadorFem = 0;
            int contadorOtro = 0;
            Dictionary<ESexo, int> keyValues = new Dictionary<ESexo, int>();
            int minimo = int.MaxValue;
            ESexo eSexo = ESexo.Otro;

            foreach (Piloto item in lista)
            {
                switch (item.Sexo)
                {
                    case ESexo.Masculino:
                        contadorMasc++;
                        break;
                    case ESexo.Femenino:
                        contadorFem++;
                        break;
                    default:
                        contadorOtro++;
                        break;
                }
            }

            keyValues.Add(ESexo.Masculino, contadorMasc);
            keyValues.Add(ESexo.Femenino, contadorFem);
            keyValues.Add(ESexo.Otro, contadorOtro);

            foreach (KeyValuePair<ESexo, int> keyValue in keyValues)
            {
                if (minimo > keyValue.Value)
                {
                    eSexo = keyValue.Key;
                    minimo = keyValue.Value;
                }
            }
            return $"El genero menos predominante entre los pilotos es {eSexo} con un total de {minimo} coincidencias";
        }


        /// <summary>
        /// Busca la nacionliadad menos predominante en la lista de pilotos
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string MinimoNacionalidad()
        {
            string retorno = String.Empty;
            int contadorNac = 0;
            int contadorNoNac = 0;


            foreach (Piloto item in lista)
            {
                switch (item.CompetidorNacional)
                {
                    case true:
                        contadorNac++;
                        break;
                    default:
                        contadorNoNac++;
                        break;
                }
            }

            if (contadorNac <= contadorNoNac)
            {
                retorno = $"La menor parte de los pilotos son pilotos nacionales con un total de {contadorNac} coincidencias";
            }
            else
            {
                retorno = $"La menor parte de los pilotos son pilotos internacionales con un total de {contadorNoNac} coincidencias";
            }

            return retorno;
        }

        /// <summary>
        /// Busca el minimo de caracteres de nombre y apellido entre los pilotos de la lista.
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string MinimoNombreYApellido()
        {
            int minimo = int.MaxValue;
            int aux;
            foreach (Piloto item in lista)
            {
                aux = item.Nombre.ContadorDeCaracteres();
                aux += item.Apellido.ContadorDeCaracteres();
                if (aux < minimo)
                {
                    minimo = aux;
                }
                aux = 0;
            }
            return $"El nombre y apellido mas corto registrado consta de {minimo} caracteres";
        }
            #endregion

            #region Promedio

        /// <summary>
        /// Busca el promedio de edad entre los pilotos de la lista.
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string PromedioEdad()
        {
            if(lista.Count > 0)
            {
                int acumulador = 0;
                float resultado = 0;
                foreach (Piloto item in lista)
                {
                    acumulador += item.Edad;
                }
                resultado = (float)acumulador / this.lista.Count;
                return $"El promedio de edad entre los pilotos de la lista es de {resultado} años";
            }
            return $"La lista se encuentra vacia, no se puede realizar el promedio de edad entre los pilotos.";
        }

        /// <summary>
        /// Busca el sexo promedio elegido entre los pilotos de la lista.
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string PromedioSexo()
        {
            if(lista.Count > 0)
            {
                int contadorMasc = 0;
                int contadorFem = 0;
                int contadorOtro = 0;

                foreach (Piloto item in lista)
                {
                    switch (item.Sexo)
                    {
                        case ESexo.Masculino:
                            contadorMasc++;
                            break;
                        case ESexo.Femenino:
                            contadorFem++;
                            break;
                        default:
                            contadorOtro++;
                            break;
                    }
                }
                return $"El {contadorMasc * 100 / this.lista.Count}% es de sexo masculino, con un total de {contadorMasc} ocurrencias. El {contadorFem * 100 / this.lista.Count}% es de sexo femenino, con un total de {contadorFem} ocurrencias. El {contadorOtro * 100 / this.lista.Count}% es de otro sexo, con un total de {contadorOtro} ocurrencias.";
            }
            return $"La lista se encuentra vacia, no se puede realizar el promedio del sexo elegido entre los pilotos.";
        }

        /// <summary>
        /// Busca la nacionalidad promedio elegida entre los pilotos de la lista.
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string PromedioNacionalidad()
        {
            if(lista.Count > 0)
            {
                int contadorNac = 0;
                int contadorOtro = 0;

                foreach (Piloto item in lista)
                {
                    switch (item.CompetidorNacional)
                    {
                        case true:
                            contadorNac++;
                            break;
                        default:
                            contadorOtro++;
                            break;
                    }
                }
                return $"El {contadorNac * 100 / this.lista.Count}% son pilotos nacionales, con un total de {contadorNac} ocurrencias. El {contadorOtro * 100 / this.lista.Count}% son pilotos extranjeros, con un total de {contadorOtro} ocurrencias.";
            }
            return $"La lista se encuentra vacia, no se puede realizar el promedio de la nacionalidad elegida entre los pilotos.";
        }

        /// <summary>
        /// Busca el promedio del numero de competicion elegido entre los pilotos de la lista.
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string PromedioNumeroElegido()
        {
            if(lista.Count > 0)
            {
                int acumulador = 0;
                float resultado = 0;
                foreach (Piloto item in lista)
                {
                    acumulador += item.NumeroCompeticion;
                }
                resultado = (float)acumulador / this.lista.Count;
                return $"El numero de competicion promedio elegido por los pilotos es el numero {resultado}";

            }
            return $"La lista se encuentra vacia, no se puede realizar el promedio del numero de competicion elegido entre los pilotos.";
        }

        /// <summary>
        /// Busca el promedio de caracteres de nombre y apellido entre los pilotos de la lista.
        /// </summary>
        /// <returns>Mensaje con el resultado.</returns>
        public string PromedioNombreYApellido()
        {
            int acumulador = 0;
            int contador = 0;
            foreach (Piloto item in lista)
            {
                acumulador += item.Nombre.ContadorDeCaracteres();
                acumulador += item.Apellido.ContadorDeCaracteres();
                contador++;
            }
            return $"El promedio de caracteres utilizados para el nombre y apellido es de {acumulador/contador} caracteres";
        }
        #endregion

        #endregion
    }
}
