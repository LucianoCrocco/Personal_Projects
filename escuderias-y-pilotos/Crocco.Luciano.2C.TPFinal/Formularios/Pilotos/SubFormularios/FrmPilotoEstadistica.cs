using ArchivosYSerializacion;
using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmPilotoEstadistica : Form
    {
        private EstadisticasPilotos promedio;
        private List<Piloto> pilotos;
        /// <summary>
        /// Constructor del form. Recibe la referencia de la lista de pilotos en memoria.
        /// </summary>
        /// <param name="pilotos"></param>
        public FrmPilotoEstadistica(List<Piloto> pilotos)
        {
            InitializeComponent();
            promedio = new EstadisticasPilotos(pilotos);
            this.pilotos = pilotos;
        }
        /// <summary>
        /// Genera el promedio de los atributos de pilotos cargados en memoeria y los muestra en el RichTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPromedio_Click(object sender, EventArgs e)
        {
            Limpiar();
            rchEstadisticas.Text = promedio.PromedioEdad() + "\n" + promedio.PromedioSexo() + "\n" + promedio.PromedioNacionalidad() + "\n" + promedio.PromedioNumeroElegido() + "\n" + promedio.PromedioNombreYApellido();

        }
        /// <summary>
        /// Busca el maximo de los atributos de pilotos cargados en memoeria y los muestra en el RichTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaximo_Click(object sender, EventArgs e)
        {
            Limpiar();
            rchEstadisticas.Text = promedio.MaximoEdad() + "\n" + promedio.MaximoNacionalidad() + "\n" + promedio.MaximoSexo() + "\n" + promedio.MaximoNroCompeticion() + "\n" + promedio.MaximoNombreYApellido();
        }

        /// <summary>
        /// Busca el minimo de los atributos de pilotos cargados en memoeria y los muestra en el RichTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimo_Click(object sender, EventArgs e)
        {
            Limpiar();
            rchEstadisticas.Text = promedio.MinimoEdad() + "\n" + promedio.MinimoNacionalidad() + "\n" + promedio.MinimoSexo() + "\n" + promedio.MinimoNroCompeticion() + "\n" + promedio.MinimoNombreYApellido();
        }

        /// <summary>
        /// Limpia mi RichTextBox
        /// </summary>
        public void Limpiar()
        {
            rchEstadisticas.Clear();
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
            string listaPilotos = Piloto.MostrarTodosListaPilotos(pilotos);
            bool append = !chkSobreescribir.Checked;
            ArchivoTexto archivoTexto = new ArchivoTexto();
            try
            {
                path = $"{Environment.CurrentDirectory}\\EstadisticasPilotos.txt";
                archivoTexto.Guardar(dateTime + rchEstadisticas.Text + "\n" + listaPilotos, path, append);
                
                MessageBox.Show($"Archivo correctamente guardado en: {path}", "Guardado correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
