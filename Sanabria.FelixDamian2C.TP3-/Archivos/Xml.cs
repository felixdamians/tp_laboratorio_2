using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        ///  METODO PUBLICO QUE GUARDA UN OBJETO GENERICO EN UN ARCHIVO XML 
        ///  
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos">OBJETO GENERICO A GUARDAR</param>
        /// <returns></returns>
        public bool guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter(archivo, UTF8Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(escritor, datos);
                    escritor.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        ///  METODO PUBLICO QUE LEERA UN ARCHIVO XML 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader lector = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(lector);
                    lector.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                datos = default(T);
                throw new ArchivosException(e);
            }
        }
    }
}
