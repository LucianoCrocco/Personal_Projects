using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;
using Excepciones;

namespace Formularios
{
    public partial class FrmHistorialPilotos : Form
    {

        #region Atributos
        private Piloto auxPiloto;
        private FrmPilotoEstadistica frmEstadisticaPiloto;
        private FrmEditarPiloto frmEditarPiloto;
        private List<Piloto> pilotosHistorial;
        private List<Piloto> pilotosActuales;
        private PilotoBDD baseDeDatosPiloto;
        private CancellationToken cancellationToken;
        private CancellationTokenSource cancellationTokenSource;
        private bool usarHilo;
        #endregion

        /// <summary>
        /// Constructor del form. Recibe por referencia la lista de pilotos actualmente cargada en memoria.
        /// </summary>
        /// <param name="pilotosActuales"></param>
        public FrmHistorialPilotos(List<Piloto> pilotosActuales)
        {
            InitializeComponent();
            this.pilotosHistorial = new List<Piloto>();
            this.baseDeDatosPiloto = new PilotoBDD();
            this.pilotosActuales = pilotosActuales;
            this.cancellationTokenSource = new CancellationTokenSource();
            this.cancellationToken = cancellationTokenSource.Token;
            this.usarHilo = true;
        }
        private void FrmHistorialPilotos_Activated(object sender, EventArgs e)
        {
            this.usarHilo = false;
        }

        #region Cargar historial
        /// <summary>
        /// Carga el historial de pilotos conectandose a la base de datos a través de la clase Piloto BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmHistorialPilotos_Load(object sender, EventArgs e)
        {
            try
            {
                this.pilotosHistorial = this.baseDeDatosPiloto.LeerPilotos();
                Task.Run(ListarPilotos, cancellationToken);
            }
            catch(BaseDeDatosException ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Llama al metodo Refrescar Lista y paraliza el hilo 2 segundos.
        /// </summary>
        public void ListarPilotos()
        {
            while (!this.cancellationToken.IsCancellationRequested)
            {
                if (this.usarHilo)
                {
                    this.Refrescar();
                    Thread.Sleep(300);
                }
            }
        }

        /// <summary>
        /// Refresca la lista de pilotos del form
        /// </summary>
        /// <param name="pilotos">Lista de pilotos que queremos mostrar ene l form</param>
        public void Refrescar()
        {
            if (this.lstPilotos.InvokeRequired)
            {
                RefrescarListaDelegate callback = new RefrescarListaDelegate(Refrescar);
                this.Invoke(callback);
            }
            else
            {
                this.lstPilotos.Items.Clear();
                foreach (Piloto item in this.pilotosHistorial)
                {
                    this.lstPilotos.Items.Add(item.MostrarDatos());
                }
            }
        }
        #endregion

        #region Estadisticas
        /// <summary>
        /// Genera estadisticas del historial de pilotos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            if (this.pilotosHistorial.Count > 0)
            {
                frmEstadisticaPiloto = new FrmPilotoEstadistica(this.pilotosHistorial);
                frmEstadisticaPiloto.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay pilotos cargados en la lista", "Aleta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Agregar Piloto
        /// <summary>
        /// Agrega un piloto a la lista actual de pilotos desde el historial.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarPiloto_Click(object sender, EventArgs e)
        {
            if (pilotosHistorial.Count < 1)
            {
                MessageBox.Show("La lista se encuentra vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else
            {
                try
                {
                    this.pilotosActuales += this.pilotosHistorial[lstPilotos.SelectedIndex];
                }
                catch (PilotoRepetidoException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("El index seleccionado se encuentra fuera del rango de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region Editar Piloto
        /// <summary>
        /// Edito un piloto del el historial lanzado un formulario para ello.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.usarHilo = true;
            if (this.pilotosHistorial.Count < 1)
            {
                MessageBox.Show("La lista se encuentra vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    //Genero este piloto para que si edito la DB y el piloto este en memoria pueda editarlo tambien al de la lista.
                    int index = lstPilotos.SelectedIndex;
                    auxPiloto = new Piloto(this.pilotosHistorial[index].Nombre, this.pilotosHistorial[index].Apellido, this.pilotosHistorial[index].Edad, this.pilotosHistorial[index].Sexo, this.pilotosHistorial[index].NumeroCompeticion, this.pilotosHistorial[index].CompetidorNacional);
                    frmEditarPiloto = new FrmEditarPiloto(pilotosHistorial, this.pilotosHistorial[lstPilotos.SelectedIndex]);
                    frmEditarPiloto.ShowDialog();
                    this.EditarListaPrincipal(auxPiloto, index);
                }
                catch (PilotoNoEncontradoException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("El index seleccionado se encuentra fuera del rango de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.usarHilo = false;
        }

        #endregion

        #region Borrar Piloto
        /// <summary>
        /// Borra del historial un piloto conectandose a la base de datos a través de la clase Piloto BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            this.usarHilo = true;
            if (this.pilotosHistorial.Count < 1)
            {
                MessageBox.Show("La lista se encuentra vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    this.baseDeDatosPiloto.BorrarPiloto(this.pilotosHistorial[lstPilotos.SelectedIndex]);
                    this.pilotosHistorial -= this.pilotosHistorial[lstPilotos.SelectedIndex];
                }
                catch (PilotoNoEncontradoException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("El index seleccionado se encuentra fuera del rango de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.usarHilo = false;
        }

        #endregion

        #region Metodos
        //No encontre una mejor manera de hacerlo sin tener que generar otro hilo que haga lo mismo que hace el hilo que refresca el lst.
        /// <summary>
        /// Si el piloto recien agregado a la BD es editado, edita ese piloto en particular. Corrige el error que permite editarlo de la DB pero no de la lista principal.
        /// </summary>
        /// <param name="piloto"></param>
        /// <param name="index"></param>
        public void EditarListaPrincipal(Piloto piloto, int index)
        {
            if(piloto is not null)
            {
                foreach(Piloto item in this.pilotosActuales)
                {
                    if(item ^ piloto)
                    {
                        item.Nombre = this.pilotosHistorial[index].Nombre;
                        item.Apellido = this.pilotosHistorial[index].Apellido;
                        item.Edad = this.pilotosHistorial[index].Edad;
                        item.NumeroCompeticion = this.pilotosHistorial[index].NumeroCompeticion;
                        item.Sexo = this.pilotosHistorial[index].Sexo;
                        item.CompetidorNacional = this.pilotosHistorial[index].CompetidorNacional;
                    }
                }
            }
        }
        #endregion

        private void FrmHistorialPilotos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cancellationTokenSource.Cancel();
        }
    }
}
