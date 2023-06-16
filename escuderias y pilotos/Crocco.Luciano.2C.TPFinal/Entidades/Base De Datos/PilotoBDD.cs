using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public class PilotoBDD
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private List<Piloto> pilotos;
        private string connectionStr;

        /// <summary>
        /// Constructor por defecto para manipular la base de datos.
        /// </summary>
        public PilotoBDD()
        {
            this.pilotos = new List<Piloto>();
            this.connectionStr = $"Data Source=DESKTOP-0KPPBQN;Initial Catalog=TorneoDataBase;Integrated Security=True";
            this.sqlConnection = new SqlConnection(this.connectionStr);
            this.sqlCommand = new SqlCommand();
            this.sqlCommand.CommandType = System.Data.CommandType.Text;
            this.sqlCommand.Connection = this.sqlConnection;
        }

        #region Guardar Piloto
        /// <summary>
        /// Guarda un piloto en la base de datos
        /// </summary>
        /// <param name="piloto">Piloto a guardar</param>
        public void GuardarPiloto(Piloto piloto)
        {
            if (piloto is not null)
            {
                try
                {
                    sqlCommand.CommandText = $"INSERT INTO Pilotos (nombre, apellido, edad, sexo, numeroCompeticion, competidorNacional) VALUES (@Nombre, @Apellido, @Edad, @Sexo, @NumeroCompeticion, @CompetidorNacional)";
                    sqlCommand.Connection.Open();
                    sqlCommand.Parameters.AddWithValue("Nombre", piloto.Nombre);
                    sqlCommand.Parameters.AddWithValue("Apellido", piloto.Apellido);
                    sqlCommand.Parameters.AddWithValue("Edad", piloto.Edad);
                    sqlCommand.Parameters.AddWithValue("Sexo", piloto.Sexo);
                    sqlCommand.Parameters.AddWithValue("NumeroCompeticion", piloto.NumeroCompeticion);
                    sqlCommand.Parameters.AddWithValue("CompetidorNacional", piloto.CompetidorNacional);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new BaseDeDatosException("Error al guardar el piloto en la base de datos", ex);
                }
                finally
                {
                    sqlCommand.Connection.Close();
                    sqlCommand.Parameters.Clear();
                }
            }
        }
        #endregion

        #region Leer Pilotos
        /// <summary>
        /// Lee todos los pilotos cargados en la base de datos
        /// </summary>
        /// <returns>Lista de pilotos en la base datos</returns>
        public List<Piloto> LeerPilotos()
        {
            this.pilotos.Clear();
            try
            {
                sqlCommand.CommandText = $"SELECT nombre, apellido, edad, sexo, numeroCompeticion, competidorNacional FROM Pilotos";
                sqlCommand.Connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Piloto auxPiloto = new Piloto();
                    auxPiloto.Nombre = sqlDataReader["nombre"].ToString();
                    auxPiloto.Apellido = sqlDataReader["apellido"].ToString();
                    auxPiloto.Edad = int.Parse(sqlDataReader["edad"].ToString());
                    auxPiloto.Sexo = (ESexo)int.Parse(sqlDataReader["sexo"].ToString());
                    auxPiloto.NumeroCompeticion = int.Parse(sqlDataReader["numeroCompeticion"].ToString());
                    auxPiloto.CompetidorNacional = bool.Parse(sqlDataReader["competidorNacional"].ToString());
                    this.pilotos.Add(auxPiloto);
                }
                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                throw new BaseDeDatosException("Error al cargar los pilotos de la base de datos", ex);
            }
            finally
            {
                sqlCommand.Connection.Close();
                sqlCommand.Parameters.Clear();
            }
            return this.pilotos;
        }
        #endregion

        #region Editar Piloto
        /// <summary>
        /// Edita un piloto de la lista de la base de datos.
        /// </summary>
        /// <param name="piloto">Piloto editado.</param>
        /// <param name="nombre">Nombre del piloto sin editar.</param>
        /// <param name="apellido">Apellido del piloto sin editar.</param>
        /// <param name="numeroCompeticion">Numero de competicion del piloto sin editar.</param>
        public void EditarPiloto(Piloto piloto, string nombre, string apellido, int numeroCompeticion)
        {
            if (piloto is not null)
            {
                try
                {
                    sqlCommand.CommandText = $"UPDATE Pilotos SET nombre = @Nombre, apellido = @Apellido, edad = @Edad, sexo = @Sexo, numeroCompeticion = @NumeroCompeticion, competidorNacional = @CompetidorNacional WHERE nombre = @nombreSinEditar AND apellido = @apellidoSinEditar AND numeroCompeticion = @nroSinEditar";
                    sqlCommand.Connection.Open();
                    sqlCommand.Parameters.AddWithValue("nombreSinEditar", nombre);
                    sqlCommand.Parameters.AddWithValue("apellidoSinEditar", apellido);
                    sqlCommand.Parameters.AddWithValue("nroSinEditar", numeroCompeticion);

                    sqlCommand.Parameters.AddWithValue("Nombre", piloto.Nombre);
                    sqlCommand.Parameters.AddWithValue("Apellido", piloto.Apellido);
                    sqlCommand.Parameters.AddWithValue("Edad", piloto.Edad);
                    sqlCommand.Parameters.AddWithValue("Sexo", piloto.Sexo);
                    sqlCommand.Parameters.AddWithValue("NumeroCompeticion", piloto.NumeroCompeticion);
                    sqlCommand.Parameters.AddWithValue("CompetidorNacional", piloto.CompetidorNacional);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new BaseDeDatosException("Error al editar el piloto en la base de datos", ex);
                }
                finally
                {
                    sqlCommand.Connection.Close();
                    sqlCommand.Parameters.Clear();
                }
            }
        }
        #endregion

        #region Borrrar Piloto
        /// <summary>
        /// Borra un piloto de la base de datos, coincidiendo nombre, apellido y numero de competicion.
        /// </summary>
        /// <param name="piloto">Piloto a borrar</param>
        public void BorrarPiloto(Piloto piloto)
        {
            if (piloto is not null)
            {
                try
                {
                    sqlCommand.CommandText = $"DELETE FROM Pilotos WHERE nombre = @Nombre AND apellido = @Apellido AND numeroCompeticion = @NumeroCompeticion AND edad = @Edad";
                    sqlCommand.Connection.Open();
                    sqlCommand.Parameters.AddWithValue("Nombre", piloto.Nombre);
                    sqlCommand.Parameters.AddWithValue("Apellido", piloto.Apellido);
                    sqlCommand.Parameters.AddWithValue("Edad", piloto.Edad);
                    sqlCommand.Parameters.AddWithValue("NumeroCompeticion", piloto.NumeroCompeticion);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new BaseDeDatosException("Error al borrar el piloto en la base de datos", ex);
                }
                finally
                {
                    sqlCommand.Connection.Close();
                    sqlCommand.Parameters.Clear();
                }
            }
        }
        #endregion
    }
}
