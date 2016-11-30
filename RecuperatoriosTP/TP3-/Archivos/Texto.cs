using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto:IArchivo<string>
    {

        public bool guardar(string archivo, string dato)
        {
            bool flag = false;
            

            if (archivo != null && dato != null)
            { 
                try
                {

                   using( StreamWriter writer = new StreamWriter(archivo,false))
                    {
                        writer.Write(dato);
                        flag = true;
                    }               
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }
            return flag;

        }



        public bool leer(string archivo, out string datos)
        {
            throw new NotImplementedException();
        }
    }
}
