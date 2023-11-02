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
using ArchivosYSerializacion;
using Excepciones;
using System.IO;
using System.Threading;

namespace Formularios
{
    public partial class FrmEscuderia<T> : Form
        where T : EscuderiaTC
    {
        #region Atributos
        private FrmGenerarEscuderiaTC frmGenerarEscuderiaTC;
        private FrmGestionarPiloto frmCargarPiloto;
        private FrmPilotoEstadistica frmEstadisticasIndividuales;
        private FrmEscuderiaEstadisticaTC frmEscuderiaEstadisticaTC;
        private FrmEditarEscuderiaTC frmEditarEscuderiaTC;
        private List<Escuderia> escuderias;
        private List<Piloto> pilotos;
        private OpenFileDialog openFileDialog;
        private List<T> auxList;
        private SerializacionJSON<List<T>> serializacion;
        private string path;
        private CancellationToken cancellationToken;
        private CancellationTokenSource cancellationTokenSource;
        private bool usarHilo;
        #endregion

        /// <summary>
        /// Constructor del form. Recibe por parametros la referencia a la lista de escuderias y pilotos cargadas en memoria.
        /// </summary>
        /// <param name="escuderias"></param>
        /// <param name="pilotos"></param>
        public FrmEscuderia(List<Escuderia> escuderias, List<Piloto> pilotos)
        {
            InitializeComponent();
            this.escuderias = escuderias;
            this.pilotos = pilotos;
            this.serializacion = new SerializacionJSON<List<T>>();
            this.auxList = new List<T>();
            this.cancellationTokenSource = new CancellationTokenSource();
            this.cancellationToken = cancellationTokenSource.Token;
            this.usarHilo = true;
        }

        private void FrmEscuderia_Load(object sender, EventArgs e)
        {
           Task.Run(ListarEscuderias, cancellationToken);
        }
        private void FrmEscuderia_Activated(object sender, EventArgs e)
        {
            this.usarHilo = false;
        }

        #region Guardar escuderia
        /// <summary>
        /// Guarda la lista de escuderias en un archivo XML. Si ya existe se le pregunta al usuario si desea reemplazar el archivo.
        /// La lista a guardar es de tipo generica, y va a guardar el tipo que se le especifico al lanzar este formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarLista_Click(object sender, EventArgs e)
        {
            if (escuderias.Count > 0)
            {
                try
                {
                    path = $"{Environment.CurrentDirectory}\\Lista{typeof(T).Name}.json";
                    if ((File.Exists(path) && MessageBox.Show("Ya se encuentra creado un archivo de escuderias, ¿desea sobreescribirlo?", "Cuidado", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) || !File.Exists(path))
                    {
                        this.auxList.Clear();
                        foreach (T escuderia in this.escuderias)
                        {
                            this.auxList.Add(escuderia);
                        }
                        ((IArchivo<List<T>>)serializacion).Guardar(this.auxList, path,false);
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
                MessageBox.Show("No hay escuderias cargadas en la lista", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Cargar escuderia
        /// <summary>
        /// Carga una lista de escuderias que el usuario tenga en un archivo JSON. Si hay en memoria cargada una lista de escuderias esta se reemplaza por la que el usuario elija.
        /// La lista a cargar es de tipo generica, y va a cargar el tipo que se le especifico al lanzar este formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarLista_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Seleccione el archivo a abrir";
            openFileDialog.Filter = "Archivos Json (.json) |*.json||*.*";

            if ((escuderias.Count > 0 && MessageBox.Show("Si no se guardo la lista con la cual se encuentra trabajando esta se borrara y se cargara la lista que usted elija.\n ¿Desea continuar?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) || escuderias.Count == 0)
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                    try
                    {
                        auxList.Clear();
                        auxList = ((IArchivo<List<T>>)serializacion).Leer(path);
                        FrmEscuderia<T>.BorrarEscuderiaActules(escuderias);
                        foreach (T item in auxList)
                        {
                            this.escuderias.Add(item);
                        }
                        this.usarHilo = true;
                        MessageBox.Show("Archivo cargado correctamente");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            this.usarHilo = false;
        }
        #endregion

        #region Generar Escuderia TC
        /// <summary>
        /// Genera un form para cargar una escuderia del TC a 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerarEscuderia_Click(object sender, EventArgs e)
        {
            this.usarHilo = true;
            frmGenerarEscuderiaTC = new FrmGenerarEscuderiaTC(escuderias);
            frmGenerarEscuderiaTC.ShowDialog();
            this.usarHilo = false;
        }
        #endregion

        #region Gestionar Pilotos
        /// <summary>
        /// Lanza el formulario para añadir o elimina pilotos de la escuderia seleccionada de la lista. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGestionarPilotos_Click(object sender, EventArgs e)
        {
            if(lstEscuderias.SelectedIndex > -1)
            {
                frmCargarPiloto = new FrmGestionarPiloto(escuderias, pilotos, lstEscuderias.SelectedIndex);
                frmCargarPiloto.ShowDialog();
            } else
            {
                MessageBox.Show("Seleccione una escuderia de la lista para cargarle un piloto");
            }
        }
        #endregion

        #region Borrar Escuderia
        /// <summary>
        /// Borra una escuderia de la lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrarEscuderia_Click(object sender, EventArgs e)
        {
            this.usarHilo = true;
            if (escuderias.Count < 1)
            {
                MessageBox.Show("La lista se encuentra vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    escuderias -= escuderias[lstEscuderias.SelectedIndex];
                }
                catch (EscuderiaNoEncontradaException ex)
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

        #region Editar Escuderia
        /// <summary>
        /// Lanza un formulario que permite editar los datos de la escuderia seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (typeof(T) == typeof(EscuderiaTC))
            {
                if (escuderias.Count < 1)
                {
                    MessageBox.Show("La lista se encuentra vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        this.usarHilo = true;
                        frmEditarEscuderiaTC = new FrmEditarEscuderiaTC(this.escuderias, this.FiltrarUnaEscuderia(lstEscuderias.SelectedIndex));
                        frmEditarEscuderiaTC.ShowDialog();
                        this.usarHilo = false;
                    }
                    catch (EscuderiaNoEncontradaException ex)
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
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Llama al metodo Refrescar Lista y paraliza el hilo 2 segundos.
        /// </summary>
        public void ListarEscuderias()
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
        /// Refresca la lista de escuderias del form
        /// </summary>
        public void Refrescar()
        {
            if (this.lstEscuderias.InvokeRequired)
            {
                RefrescarListaDelegate callback = new RefrescarListaDelegate(Refrescar);
                this.Invoke(callback);
            }
            else
            {
                this.lstEscuderias.Items.Clear();
                foreach (T item in this.escuderias)
                {
                    this.lstEscuderias.Items.Add(item.MostrarDatos());
                }
            }
        }

        /// <summary>
        /// Lo utilizo cuando cargo un archivo XML con escuderias. Borro las escuderias del tipo generico especificado cuando se lanzo el formulario.
        /// Para que no ocurra el error detallado anteriormente declaro una lista auxiliar que me va a ayudar a borrar los items del tipo lanzado de mi lista de escuerias principal
        /// </summary>
        /// <param name="escuderias"></param>
        public static void BorrarEscuderiaActules(List<Escuderia> escuderias)
        {
            /*Collection was modified; enumeration operation may not execute.
            Hago una lista paralela del tipo generico lanzado por el formulario (Es lo que me importa remover)
            Una vez copiadas todas las ocurrencias voy a poder remover los items que coincidan con el generico de mi escuderia principal donde tengo distintos tipos.*/
            List<T> auxList = new List<T>();
            foreach(T item in escuderias)
            {
                auxList.Add(item);
            }
            foreach(T item in auxList)
            {
                escuderias.Remove(item);
            }
        }


        /// <summary>
        /// Filtra una escuderia por el tipo que se le pide y devuelve una lista generica los elementos solo del tipo seleccionado.
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="escuderias"></param>
        /// <returns></returns>
        public static List<Escuderia> FiltrarEscuderias<R>(List<Escuderia> escuderias)
            where R : Escuderia
        {
            List<Escuderia> listaGenerica = new List<Escuderia>();
            if (escuderias is not null)
            {
                foreach (R item in escuderias)
                {
                    listaGenerica.Add(item);
                }
            }
            return listaGenerica;
        }

        /// <summary>
        /// Filtra una escuderia por index de la lista de escuderias actualmente cargadas en memoria.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Escuderia FiltrarUnaEscuderia(int index)
        {
            List<Escuderia> auxListEscuderias = new List<Escuderia>();
            auxListEscuderias = FiltrarEscuderias<T>(this.escuderias);
            return auxListEscuderias[index];
        }
        #endregion

        #region Simulacion
        private void BtnEvento_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Estadisticas individuales de las escuderias
        /// <summary>
        /// Lanza un formulario con las estadisticas de los pilotos que componen esa escuderia.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEstadisticasIndividuales_Click(object sender, EventArgs e)
        {
            if (lstEscuderias.SelectedIndex > -1)
            {
                if (this.escuderias[lstEscuderias.SelectedIndex].Pilotos.Count > 0)
                {
                    frmEstadisticasIndividuales = new FrmPilotoEstadistica(this.escuderias[lstEscuderias.SelectedIndex].Pilotos);
                    frmEstadisticasIndividuales.ShowDialog();
                } else
                {
                    MessageBox.Show("La escuderia seleccionada no posee pilotos cargados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una escuderia de la lista generar las estadisticas individuales");
            }
        }
        #endregion

        #region Estadisticas generales de las escuderias
        /// <summary>
        /// Lanza un formulario con la estadisticas de la lista de escuderias del tipo generico especificado al lanzar el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEstadisticasGenerales_Click(object sender, EventArgs e)
        {
            if(escuderias.Count > 0){
                if(typeof(T) == typeof(EscuderiaTC)){
                    frmEscuderiaEstadisticaTC = new FrmEscuderiaEstadisticaTC(this.escuderias);
                    frmEscuderiaEstadisticaTC.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("No hay escuderias cargadas para generar estadisticas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void FrmEscuderia_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cancellationTokenSource.Cancel();
        }

    }
}
