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
    public partial class FrmEditarPiloto : Form
    {
        #region Atributos
        private PilotoBDD pilotoBDD;
        private Piloto piloto;
        private List<Piloto> pilotos;
        #endregion

        /// <summary>
        /// Constructor del form. Recibe por parametros la referencia a la lista de pilotos y el pilto a editar cargado en memoria.
        /// </summary>
        /// <param name="pilotos">Lista de pilotos actual</param>
        /// <param name="piloto">Piloto a editar</param>
       
        public FrmEditarPiloto(List<Piloto> pilotos, Piloto piloto)
        {
            InitializeComponent();
            this.piloto = piloto;
            this.pilotos = pilotos;
            this.pilotoBDD = new PilotoBDD();
        }

        #region Carga de datos
        /// <summary>
        /// Carga los datos del piloto que se paso por argumentos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEditarPiloto_Load(object sender, EventArgs e)
        {
            this.txtBoxNombre.Text = this.piloto.Nombre;
            this.txtBoxApellido.Text = this.piloto.Apellido;
            this.nroEdad.Value = this.piloto.Edad;
            this.cmbSexo.SelectedIndex = (int)this.piloto.Sexo;
            this.nroCompeticion.Value = this.piloto.NumeroCompeticion;
            if (this.piloto.CompetidorNacional)
            {
                this.cmbNacionalidad.SelectedIndex = 0;
            }
            else
            {
                this.cmbNacionalidad.SelectedIndex = 1;
            }
        }
        #endregion

        #region Editar Piloto
        /// <summary>
        /// Renueva los datos del actual piloto con los ingresados en el form y del mismo piloto en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cmbNacionalidad.SelectedItem is not null && cmbSexo.SelectedItem is not null && txtBoxNombre.Text is not null && txtBoxApellido.Text is not null)
            {
                bool nacionalidad = false;
                if (cmbNacionalidad.SelectedIndex == 0)
                {
                    nacionalidad = true;
                }
                try
                {
                    Piloto aux = new Piloto(txtBoxNombre.Text, txtBoxApellido.Text, (int)nroEdad.Value, (ESexo)cmbSexo.SelectedIndex, (int)nroCompeticion.Value, nacionalidad);

                    if (this.pilotos == aux && aux != this.piloto)
                    {
                        MessageBox.Show("El numero de piloto seleccionado ya se encuentra en uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string nombre = String.Empty;
                        string apellido = String.Empty;
                        int nroCompeticion = -1;

                        nombre = this.piloto.Nombre;
                        apellido = this.piloto.Apellido;
                        nroCompeticion = this.piloto.NumeroCompeticion;
                        this.piloto.Nombre = this.txtBoxNombre.Text;
                        this.piloto.Apellido = this.txtBoxApellido.Text;
                        this.piloto.Edad = (int)this.nroEdad.Value;
                        this.piloto.Sexo = (ESexo)cmbSexo.SelectedIndex;
                        this.piloto.NumeroCompeticion = (int)this.nroCompeticion.Value;
                        this.piloto.CompetidorNacional = nacionalidad;
                        this.pilotoBDD.EditarPiloto(piloto, nombre, apellido, nroCompeticion);
                    }
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
            }
        }
        #endregion
    }
}
