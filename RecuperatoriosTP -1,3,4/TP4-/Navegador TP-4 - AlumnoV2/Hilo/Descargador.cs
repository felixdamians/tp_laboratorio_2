using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        //Atributos privados
        private string _html;
        private Uri _direccion;

        public delegate void EventProgress(int status);
        public event EventProgress eventProgress;
        public delegate void EventCompleted(string web);
        public event EventCompleted eventCompleted;

        //Atributo del evento, lo instancio a public
        //public event EventProgress eventProgress;
        //public event EventCompleted eventCompleted;


        /// <summary>
        /// Constructor, a traves de el instancio sus atributos
        /// </summary>
        /// <param name="direccion"></param>
        public Descargador(Uri direccion)
        {
            this._html = "";
            this._direccion = direccion;
        }

        /// <summary>
        /// Inicia la descarga de la web, 
        /// </summary>
        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this._direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.eventProgress(e.ProgressPercentage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try 
            {
                this._html = e.Result;
            
            }
            catch(Exception ex)
            {
                this._html = ex.InnerException.Message;
            }
            finally
            {
                // paso el contenido de la página/error para que lance el evento y actualice el richTextBox.
                this.eventCompleted(this._html);
            }

        }
    }
}
