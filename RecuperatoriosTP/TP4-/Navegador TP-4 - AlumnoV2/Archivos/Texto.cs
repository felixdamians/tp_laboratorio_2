using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _path;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        public Texto(string archivo)
        {
            this._path = archivo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            try
            {
                //
                StreamWriter sw = new StreamWriter(this._path,true);
                sw.WriteLine(datos);
                sw.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        
        }

        public bool leer(out List<string>datos)
        {
            try
            {
                StreamReader sr = new StreamReader(this._path);
               datos = new List<string>();
                while (!sr.EndOfStream)
                {
                    // ingreso cada linea en un nuevo item en la lista.
                    datos.Add(sr.ReadLine());
                }
                               
                sr.Close();

                return true;
            }
            catch (Exception)
            {
                datos = default(List<string>);
                return false;
            }

            }

        }
    }

