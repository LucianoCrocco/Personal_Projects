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
    public partial class FrmGestionarPiloto : Form
    {
        private List<Escuderia> escuderias;
        private List<Piloto> pilotos;
        private int index;

        /// <summary>
        /// Constructor del form. Recibe por parametros una lista de escuderias, el index de la lista de escuderias y todos los pilotos cargados en memoria.
        /// </summary>
        /// <param name="escuderias"></param>
        /// <param name="pilotos"></param>
        /// <param name="index"></param>
        public FrmGestionarPiloto(List<Escuderia> escuderias, List<Piloto> pilotos, int index)
        {
            InitializeComponent();
            this.escuderias = escuderias;
            this.pilotos = pilotos;
            this.index = index;
        }

        private void FrmCargarPiloto_Load(object sender, EventArgs e)
        {
            this.ListaPilotosDisponibles();
            this.ListaPilotosEscuderia();
        }

        /// <summary>
        /// Carga todos los pilotos de la escuderia seleccionada.
        /// </summary>
        public void ListaPilotosEscuderia()
        {
            lstPilotosDeLaEscuderia.Items.Clear();
            foreach(Piloto item in escuderias[index].Pilotos)
            {
                lstPilotosDeLaEscuderia.Items.Add(item.MostrarDatos());
            }
            
        }
        /// <summary>
        /// Carga todos los pilotos en memoeria.
        /// </summary>
        public void ListaPilotosDisponibles()
        {
            lstPilotosDisponibles.Items.Clear();
            foreach (Piloto item in pilotos)
            {
                lstPilotosDisponibles.Items.Add(item.MostrarDatos());
            }
        }
        /// <summary>
        /// Añade un piloto de mi lista de pilotos a la lista de pilotos de la escuderia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstPilotosDisponibles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(this.escuderias[index].CantidadPilotos > this.escuderias[index].Pilotos.Count)
            {
                try
                {
                    bool ocupado = false;
                    foreach (Escuderia item in escuderias)
                    {
                        foreach (Piloto piloto in item.Pilotos)
                        {
                            if (item == this.pilotos[lstPilotosDisponibles.SelectedIndex])
                            {
                                ocupado = true;
                                MessageBox.Show("El numero de competicion del piloto seleccionado ya se encuentra compitiendo en una escudera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                    if (!ocupado)
                    {
                        this.escuderias[index].Pilotos.Add(this.pilotos[lstPilotosDisponibles.SelectedIndex]);
                        this.ListaPilotosDisponibles();
                        this.ListaPilotosEscuderia();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("El index seleccionado se encuentra fuera del rango de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                MessageBox.Show($"Se alcanzo el maximo de asientos disponibles de la escuderia ({this.escuderias[index].CantidadPilotos})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           

        }

        /// <summary>
        /// Borra el piloto seleccionado de la lista de pilotos de la escuderia seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstPilotosDeLaEscuderia_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.escuderias[index].Pilotos.Remove(this.escuderias[index].Pilotos[lstPilotosDeLaEscuderia.SelectedIndex]);
                this.ListaPilotosDisponibles();
                this.ListaPilotosEscuderia();
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
