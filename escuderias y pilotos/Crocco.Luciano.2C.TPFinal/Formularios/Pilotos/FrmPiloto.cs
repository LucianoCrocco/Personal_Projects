using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Excepciones;
using ArchivosYSerializacion;
using System.IO;
using System.Threading;

namespace Formularios
{
    public partial class FrmPiloto : Form
    {
        #region Atributos
        private List<Piloto> pilotosCargados;
        private FrmHistorialPilotos frmHistorialPilotos;
        private FrmEditarPiloto frmEditarPiloto;
        private FrmGenerarPiloto frmGenerarPiloto;
        private FrmPilotoEstadistica frmEstadisticaPiloto;
        private SerializacionXML<List<Piloto>> serializacion;
        private OpenFileDialog openFileDialog;
        private CancellationToken cancellationToken;
        private CancellationTokenSource cancellationTokenSource;
        private bool usarHiloListarPilotos;
        private string path;
        private ContadorLista contadorListaPilotos;
        #endregion

        /// <summary>
        /// Constructor del form. Recibe la referencia de la lista de pilotos en memoria.
        /// </summary>
        /// <param name="listaPilotos"></param>
        public FrmPiloto(List<Piloto> listaPilotos)
        {
            InitializeComponent();
            this.pilotosCargados = listaPilotos;
            this.serializacion = new SerializacionXML<List<Piloto>>();
            this.cancellationTokenSource = new CancellationTokenSource();
            this.cancellationToken = cancellationTokenSource.Token;
            this.usarHiloListarPilotos = true;
            this.contadorListaPilotos = new ContadorLista(this.cancellationToken);
        }

        private void FrmPiloto_Load(object sender, EventArgs e)
        { 
            Task.Run(ListarPilotos, cancellationToken);
            this.contadorListaPilotos.EventoContadorLista += ContadorPilotos;
            this.contadorListaPilotos.Activar = true;
        }
        private void FrmPiloto_Activated(object sender, EventArgs e)
        {
            this.usarHiloListarPilotos = false;
        }

        #region Generar Piloto
        /// <summary>
        /// Genera un formulario para crear un piloto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerarPiloto_Click(object sender, EventArgs e)
        {
            frmGenerarPiloto = new FrmGenerarPiloto(pilotosCargados);
            this.usarHiloListarPilotos = true;
            frmGenerarPiloto.ShowDialog();
            this.usarHiloListarPilotos = false;
        }
        #endregion

        #region Estadisticas
        /// <summary>
        /// Genera un formulario para realizar trabajos estadisticos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            if(pilotosCargados.Count > 0)
            {
                frmEstadisticaPiloto = new FrmPilotoEstadistica(pilotosCargados);
                frmEstadisticaPiloto.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay pilotos cargados en la lista", "Aleta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Guardar pilotos
        /// <summary>
        /// Guarda la lista de pilotos que se encuentra actualmente cargada en memoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarLista_Click(object sender, EventArgs e)
        {
            if (pilotosCargados.Count > 0)
            {
                try
                {
                    path = $"{Environment.CurrentDirectory}\\ListaPilotos.xml";
                    if((File.Exists(path) && MessageBox.Show("Ya se encuentra creado un archivo de pilotos, ¿desea sobreescribirlo?", "Cuidado", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) || !File.Exists(path))
                    {
                        serializacion.Guardar(pilotosCargados, path, false);
                        MessageBox.Show($"Archivo correctamente guardado en: {path}", "Guardado correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (GuardarSerializacionException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No hay pilotos cargados en la lista", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        #endregion

        #region Cargar Pilotos
        /// <summary>
        /// Carga una lista de pilotos que el usuario seleccione. Si la lista actual tiene pilotos en memoria se borra al cargar la nueva lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarLista_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Seleccione el archivo a abrir";
            openFileDialog.Filter = "Archivos XML (.xml) |*.xml||*.*";
            List<Piloto> auxList;

            if ((pilotosCargados.Count > 0 && MessageBox.Show("Si no se guardo la lista con la cual se encuentra trabajando esta se borrara y se cargara la lista que usted elija.\n ¿Desea continuar?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) || pilotosCargados.Count == 0) 
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                    try
                    {
                        auxList = serializacion.Leer(path);
                        this.pilotosCargados.Clear();
                        //Si no hago esto se pierde la referencia en memoria cuando CLR borra los objetos que se utilizaron para serializar.
                        foreach(Piloto item in auxList)
                        {
                            this.pilotosCargados.Add(item);
                        }
                        this.usarHiloListarPilotos = true;
                        MessageBox.Show("Archivo cargado correctamente");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            this.usarHiloListarPilotos = false;
        }
        #endregion

        #region Borrar Piloto
        /// <summary>
        /// Borra de la memoria el piloto seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrarPiloto_Click(object sender, EventArgs e)
        {
            if (pilotosCargados.Count < 1)
            {
                MessageBox.Show("La lista se encuentra vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                this.usarHiloListarPilotos = true;
                try
                {
                    pilotosCargados -= pilotosCargados[lstPilotos.SelectedIndex];
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
                this.usarHiloListarPilotos = false;
            }
        }
        #endregion

        #region Editar Piloto
        /// <summary>
        /// Lanza un formulario para editar el piloto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (pilotosCargados.Count < 1)
            {
                MessageBox.Show("La lista se encuentra vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                this.usarHiloListarPilotos = true;
                try
                {
                    frmEditarPiloto = new FrmEditarPiloto(this.pilotosCargados, this.pilotosCargados[lstPilotos.SelectedIndex]);
                    frmEditarPiloto.ShowDialog();
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
                this.usarHiloListarPilotos = false;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Refresca el mensaje de contar pilotos. Se utiliza a traves de un evento en un hilo secundario.
        /// </summary>
        public void ContadorPilotos()
        {
            
            if (lblPilotosCargados.InvokeRequired)
            {
                ContadorListaDelegate callback = new ContadorListaDelegate(ContadorPilotos);
                this.Invoke(callback);
            }
            else
            {
                this.lblPilotosCargados.Text = $"Pilotos cargados actualmente {this.pilotosCargados.Count}";
            }
            
        }
        /// <summary>
        /// Llama al metodo Refrescar Lista y paraliza el hilo 2 segundos.
        /// </summary>
        public void ListarPilotos()
        {
            while (!this.cancellationToken.IsCancellationRequested)
            {
                if (this.usarHiloListarPilotos) {
                    this.Refrescar();
                    Thread.Sleep(300);
                }
            }
        }

        /// <summary>
        /// Refresca la lista de pilotos del form
        /// </summary>
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
                foreach (Piloto item in this.pilotosCargados)
                {
                    this.lstPilotos.Items.Add(item.MostrarDatos());
                }
            }
        }
        #endregion

        #region Historial Pilotos
        /// <summary>
        /// Lanza un formulario que muestra el historial de los pilotos cargados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistorial_Click(object sender, EventArgs e)
        {
            this.usarHiloListarPilotos = true;
            frmHistorialPilotos = new FrmHistorialPilotos(this.pilotosCargados);
            frmHistorialPilotos.ShowDialog();
            this.usarHiloListarPilotos = false;
        }
        #endregion

        private void FrmPiloto_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cancellationTokenSource.Cancel();
        }


    }
}
