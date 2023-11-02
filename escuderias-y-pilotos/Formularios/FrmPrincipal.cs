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
using System.IO;

namespace Formularios
{
    public partial class FrmPrincipal : Form
    {
        private FrmPiloto frmPiloto;
        private List<Piloto> pilotos;
        private List<Escuderia> escuderias;
        /// <summary>
        /// Constructor de mi form principal. Inicializo la lista de escuderias y pilotos en memoria
        /// </summary>
        public FrmPrincipal()
        {
            InitializeComponent();
            pilotos = new List<Piloto>();
            escuderias = new List<Escuderia>();
        }

        /// <summary>
        /// Genera un formulario para la lista de pilotos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPilotos_Click(object sender, EventArgs e)
        {
            frmPiloto = new FrmPiloto(pilotos);
            frmPiloto.ShowDialog();
        }

        /// <summary>
        /// Genera un formulario para la lista de escuderias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEscuderia_Click(object sender, EventArgs e)
        {
            FrmEscuderia <EscuderiaTC> frmEscuderia = new FrmEscuderia<EscuderiaTC>(escuderias, pilotos);
            frmEscuderia.ShowDialog();
        }

    }
}
