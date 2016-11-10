using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto: IArchivo<string>
    {
        /// <summary>
        /// METODO QUE GUARDA UN OBJETO EN FORMATO STRING
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos">DATO A GUARDAR EN EL ARCHIVO </param>
        /// <returns></returns>
        public bool guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, true))
                {
                    sw.WriteLine(datos);
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// METODO PUBLICO QUE GUARDARA UN ARCHIVO DE TEXTO
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                }
                return true;
            }
            catch (Exception e)
            {
                datos = "";
                throw new ArchivosException(e);
            }

        }
    }
}
