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

namespace Formularios
{
    public partial class FrmGenerarPiloto : Form
    {
        private List<Piloto> pilotosLista;
        private PilotoBDD pilotoBDD; 

        /// <summary>
        /// Constructor del form. Recibe la referencia de la lista de pilotos en memoria.
        /// </summary>
        /// <param name="pilotos"></param>
        public FrmGenerarPiloto(List<Piloto> pilotos)
        {
            InitializeComponent();
            pilotosLista = pilotos;
            pilotoBDD = new PilotoBDD();
        }

        #region Agregar Piloto
        /// <summary>
        /// Agrega un piloto a la lista de pilotos y al historial de la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCrear_Click(object sender, EventArgs e)
        {
            bool nacionalidad = false;
            if(cmbNacionalidad.SelectedItem is not null && cmbSexo.SelectedItem is not null && txtBoxNombre.Text is not null && txtBoxApellido.Text is not null)
            {
                if(cmbNacionalidad.SelectedIndex == 0)
                {
                    nacionalidad = true;
                }

                try
                {
                    Piloto piloto = new Piloto(txtBoxNombre.Text, txtBoxApellido.Text, (int)nroEdad.Value, (ESexo)cmbSexo.SelectedIndex, (int)nroCompeticion.Value, nacionalidad);
                    pilotosLista += piloto;
                    pilotoBDD.GuardarPiloto(piloto);
                }
                catch (CaracteresInvalidoException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (PilotoRepetidoException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (BaseDeDatosException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                MessageBox.Show("Rellene todos los campos antes de continuar!");
            }
        }
        #endregion

        /// <summary>
        /// Si al cargar esta seccion se supero el cupo maximo de pilotos se mostrara un mensaje y se cerrara el form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmGenerarPiloto_Load(object sender, EventArgs e)
        {
            if(pilotosLista.Count > nroCompeticion.Maximum)
            {
                MessageBox.Show("Se alcanzo el maximo de pilotos posibles para cargar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
