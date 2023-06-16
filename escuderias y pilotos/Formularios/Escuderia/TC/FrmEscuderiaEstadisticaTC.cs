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

namespace Formularios
{
    public partial class FrmEscuderiaEstadisticaTC : Form
    {
        private EstadisticasTC promedio;
        private List<Escuderia> escuderia;
        private List<Escuderia> auxList;

        /// <summary>
        /// Constructor del form. Recibe la lista de escuderias cargadas en el sistema.
        /// </summary>
        /// <param name="escuderia"></param>
        public FrmEscuderiaEstadisticaTC(List<Escuderia> escuderia)
        {
            InitializeComponent();
            this.escuderia = escuderia;
            this.auxList = FrmEscuderia<EscuderiaTC>.FiltrarEscuderias<EscuderiaTC>(this.escuderia);
            promedio = new EstadisticasTC(this.auxList);
        }

        /// <summary>
        /// Muestra en el RichTextBox la estadistica maxima de los atributos de todas las escuderias del tipo TC cargadas en el sistema.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaximo_Click(object sender, EventArgs e)
        {
            Limpiar();
            rchEstadisticas.Text = promedio.MaximoAsientosDisponiblesPiloto() + "\n" + promedio.MaximoAsientosOcupadosPiloto() + "\n" + promedio.AutosMasUtilizado();

        }

        /// <summary>
        /// Muestra en el RichTextBox la estadistica promedio de los atributos de todas las escuderias del tipo TC cargadas en el sistema.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPromedio_Click(object sender, EventArgs e)
        {
            rchEstadisticas.Text = promedio.PromedioAsientosDisponiblesPiloto() + "\n" + promedio.PromedioAsientosOcupadosPiloto() + "\n" + promedio.PromedioAutosUtilizados();
        }
        /// <summary>
        /// Muestra en el RichTextBox la estadistica minima de los atributos de todas las escuderias del tipo TC cargadas en el sistema.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimo_Click(object sender, EventArgs e)
        {
            rchEstadisticas.Text = promedio.MinimoAsientosDisponiblesPiloto() + "\n" + promedio.MinimoAsientosOcupadosPiloto() + "\n" + promedio.AutosMenosUtilizado();
        }

        /// <summary>
        /// Guarda en un TXT las estadisticas mostradas en el RichTextBox, si el checkbox sobrescribir esta sin el tick hace un append al texto que ya se encuentra en el .txt. De lo contrario borra la informacion y carga la ultima informacion desplegada en el RichTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string path;
            string dateTime = "\tGuardado generado el " + DateTime.Now + "\n";
            string listaEscuderia = Escuderia.MostrarTodosListaEscuderia(escuderia, "escuderias del Turismo Carretera");
            bool append = !chkSobreescribir.Checked;
            ArchivoTexto archivoTexto = new ArchivoTexto();
            try
            {
                path = $"{Environment.CurrentDirectory}\\EstadisticasEscuderia.txt";
                archivoTexto.Guardar(dateTime + listaEscuderia + "\n" + rchEstadisticas.Text + "\n", path, append);

                MessageBox.Show($"Archivo correctamente guardado en: {path}", "Guardado correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Metodos
        /// <summary>
        /// Limpia el texto del RichTextBox
        /// </summary>
        public void Limpiar()
        {
            rchEstadisticas.Clear();
        }
        #endregion
    }
}
