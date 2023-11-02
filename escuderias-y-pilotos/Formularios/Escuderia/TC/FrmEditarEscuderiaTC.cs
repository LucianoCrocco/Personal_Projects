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
    public partial class FrmEditarEscuderiaTC : Form
    {

        private EscuderiaTC escuderiaTC;
        private List<Escuderia> escuderias;
        /// <summary>
        /// Constructor del form. Recibe por parametros la referencia a la lista de escuderias y la escuderia a editar cargada en memoria.
        /// </summary>
        /// <param name="escuderias">Lista de escuderias actual.</param>
        /// <param name="escuderia">Escuderia a editar.</param>
        public FrmEditarEscuderiaTC(List<Escuderia> escuderias, Escuderia escuderia)
        {
            InitializeComponent();
            this.escuderiaTC = (EscuderiaTC) escuderia;
            this.escuderias = escuderias;
        }

        #region Carga de Datos
        /// <summary>
        /// Precarga la informacion 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEditarEscuderiaTC_Load(object sender, EventArgs e)
        {
            txtBoxNombre.Text = this.escuderiaTC.NombreEscuderia;
            nroAsientos.Value = this.escuderiaTC.CantidadPilotos;
            cmbFabricante.SelectedIndex = (int)this.escuderiaTC.MarcaVehiculoTC;
        }
        #endregion

        #region Editar Datos
        /// <summary>
        /// Cambia los datos de la escuderia por los ingresados en el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtBoxNombre.Text is not null && nroAsientos is not null && cmbFabricante.SelectedIndex is not -1)
            {
                try
                {
                    Escuderia aux = new EscuderiaTC(txtBoxNombre.Text, (int)nroAsientos.Value, (EMarcaVehiculoTC)cmbFabricante.SelectedIndex);
                    if (this.escuderias == aux && aux.NombreEscuderia != this.escuderiaTC.NombreEscuderia)
                    {
                        MessageBox.Show("El nombre de la escuderia seleccionada ya se encuentra en uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else {
                        this.escuderiaTC.NombreEscuderia = txtBoxNombre.Text;
                        this.escuderiaTC.MarcaVehiculoTC = (EMarcaVehiculoTC)cmbFabricante.SelectedIndex;
                        this.escuderiaTC.CantidadPilotos = (int)nroAsientos.Value;
                    }
                }
                catch (EscuderiaRepetidaException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (CaracteresInvalidoException ex)
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
                MessageBox.Show("Rellene todos los campos antes de continuar!");
            }
        }
        #endregion
    }
}
