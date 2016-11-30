using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;


namespace Archivos
{
    public class Xml<T>: IArchivo<T>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string archivo, T datos)
        {
            bool flag = false;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, datos);
                    flag = true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return flag;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(string archivo, out T datos)
        {
            bool flag = false;
            datos = default(T);
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    datos =  (T)serializer.Deserialize(reader);
                    flag = true;
                }
            
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return flag;
        }

    }
}
