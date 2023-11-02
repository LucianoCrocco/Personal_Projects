using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class ContadorLista
    {
        private Task task;
        public event ContadorListaDelegate EventoContadorLista;
        private CancellationToken tokenCancelar;
        private bool activar;
        /// <summary>
        /// Constructor por defecto del contador, asocia un token para cancelar el hilo.
        /// </summary>
        /// <param name="token"></param>
        public ContadorLista(CancellationToken token)
        {
            this.tokenCancelar = token;
            this.activar = false;
        }
        /// <summary>
        /// Activa el hilo, si este se encuentra inactivo.
        /// </summary>
        public bool Activar
        {
            get
            {
                return this.activar;
            }
            set
            {
                if(value is true && this.activar is false)
                {
                    task = new Task(Corriendo, tokenCancelar);
                    task.Start();
                }
            }
        }
        /// <summary>
        /// Lanzo los eventos vincualdos, si tiene alguno
        /// </summary>
        public void Corriendo()
        {
            while (!this.tokenCancelar.IsCancellationRequested)
            {
                if (this.EventoContadorLista is not null)
                {
                    this.EventoContadorLista.Invoke();
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
