using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EscuderiaTC : Escuderia
    {
        #region Atributos
        protected EMarcaVehiculoTC marcaVehiculo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public EscuderiaTC() { }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="nombre">Nombre de la escuderia</param>
        /// <param name="cantidadPilotos">Cantidad de pilotos</param>
        /// <param name="fabricanteVehiculo">Marca que motoriza la escuderia</param>
        public EscuderiaTC(string nombre, int cantidadPilotos, EMarcaVehiculoTC fabricanteVehiculo)
            :base(nombre, cantidadPilotos)
        {
            this.marcaVehiculo = fabricanteVehiculo;
        }
        #endregion

        #region Propiedades
        public EMarcaVehiculoTC MarcaVehiculoTC
        {
            get
            {
                return this.marcaVehiculo;
            }
            set
            {
                this.marcaVehiculo = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de una escuderia del TC
        /// </summary>
        /// <returns>Mensaje con los datos de la escuderia del TC</returns>
        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine($" La marca elegida por la escuderia es {this.MarcaVehiculoTC}");
            return sb.ToString();
        }
        #endregion
    }
}
