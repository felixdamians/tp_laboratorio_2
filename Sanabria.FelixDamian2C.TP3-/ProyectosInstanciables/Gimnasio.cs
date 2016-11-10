using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;


namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Jornada))]
    public class Gimnasio
    {
        public enum EClases
        { 
        Pilates = 0,
        Natacion = 1,
        CrossFit = 2,
        Yoga = 3
        }
        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;

        #region "PROPIEDADES"
        /// <summary>
        /// INDEXADOR QUE PERMITE ACCEDER A UNA JORNADA ESPECIFICA 
        /// </summary>
        /// <param name="indice"></param>
        /// <returns></returns>
        public Jornada this[int indice]
        {
            get
            {
                if (indice < this._jornada.Count || indice > this._jornada.Count)
                    return this._jornada[indice];
                else
                    return null;
            }
        }

        /// <summary>
        /// PROPIEDAD GET QUE PERMITE SERIALIZAR - ALUMNOS
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
        }
        /// <summary>
        /// PROPIEDADE GET QUE PERMITE SERIALIZAR - INSTRUCTOR 
        /// 
        /// </summary>
        public List<Instructor> Instructores
        {
            get
            {
                return this._instructores;
            }
        }
        /// <summary>
        /// PROPIEDAD GET QUE PERMITE SERIALIZAR - JORNADA
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this._jornada;
            }
        }
        #endregion


        #region "METODOS"

        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }
        /// <summary>
        ///METODO QUE GUARDARA UN OBJETO GIMNASIO EN UN ARCHIVO XML 
        /// </summary>
        /// <param name="gim">GIMNASIO A GUARDAR</param>
        /// <returns></returns>
        public static bool Guardar(Gimnasio gim)
        {
            Xml<Gimnasio> xml = new Xml<Gimnasio>();
            if (xml.guardar(@"C:\Gimnasio.xml", gim))
            {
                
                return true;
            }
            return false;
        }
       /// <summary>
       /// METODO PUBLICO QUE LEERA UN OBJETO GIMNASIO Y MOSTRARA POR CONSOLA SUS DATOS
       /// </summary>
       /// <param name="gim">GIMNASIO A LEER</param>
       /// <returns></returns>
       public static bool Leer(Gimnasio gim)
        {
            Xml<Gimnasio> xml = new Xml<Gimnasio>();
            Gimnasio aux;
            if(xml.leer(@"C:\Gimnasio.xml",out aux))
            {
             Console.WriteLine(aux.ToString());
             return true;
            }
            return false;
        }

       /// <summary>
       /// VERIFICA SI EL ALUMNO ESTA INSCRIPTO EN EL GIMNASIO 
       /// </summary>
       /// <param name="g">OBJETO GIMNASIO</param>
       /// <param name="a">ALUMNO A BUSCAR</param>
       /// <returns></returns>
 
       public static bool operator ==(Gimnasio g, Alumno a)
        {
            if (!Object.ReferenceEquals(g, null) && !Object.ReferenceEquals(a, null))
            {
                foreach (Alumno item in g._alumnos)
                {
                    if (item == a)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

       /// <summary>
       /// VERIFICA SI EL ALUMNO NO ESTA INSCRIPTO EN EL GIMNASIO 
       /// 
       /// </summary>
       /// <param name="g"> OBJETO GIMNASIO</param>
       /// <param name="a">ALUMNO QUE NO ESTA EN EL GIMNASIO</param>
       /// <returns></returns>
 
       public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

       /// <summary>
       /// OPERADOR IGUALIGUAL QUE VERIFICA SI EL INSTRUCTOR SE ENCUENTRA DANDO CLASES EN EL GIMNASIO 
       /// </summary>
       /// <param name="g">OBJETO GIMNASIO</param>
       /// <param name="i">INSTRUCTOR QUE SE ENCUENTRA EN EL GIMNASIO</param>
       /// <returns></returns>
 
       public static bool operator ==(Gimnasio g, Instructor i)
        {
            if (!Object.ReferenceEquals(g, null) && !Object.ReferenceEquals(i, null))
            {
                foreach (Instructor item in g._instructores)
                {
                    if (item == i)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

       /// <summary>
       /// OPERADOR DISTINTO QUE VERIFICA SI EL INSTRUCTOR NO SE ENCUENTRA DANDO CLASES EN EL GIMNASIO 
       /// </summary>
       /// <param name="g">OBJETO GIMNASIO</param>
       /// <param name="i">INSTRUCTOR QUE NO ESTA EN EL GIMNASIO </param>
       /// <returns></returns>
       public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

       /// <summary>
       /// OPERADOR + QUE AGREGARA UN ALUMNO SIEMPRE Y CUANDO NO SE ENCUENTRE EN EL GIMNASIO 
       /// </summary>
       /// <param name="g">OBJETO GIMNASIO</param>
       /// <param name="a">ALUMNO A AGREGAR</param>
       /// <returns></returns>
 
       public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (!Object.ReferenceEquals(g, null) && !Object.ReferenceEquals(a, null))
            {
                if (g != a)
                {
                    g._alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }
            return g;
        }

       /// <summary>
       /// OPERADOR + QUE AGREGARA UN INSTRUCTOR AL GIMNASIO SIEMPRE Y CUANDO NO SE ENCUENTRE EN ÉL.
       /// </summary>
       /// <param name="g">OBJETO GIMNASIO</param>
       /// <param name="i">INSTRUCTOR A AGREGAR</param>
       /// <returns></returns>
 
       public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (!Object.ReferenceEquals(g, null) && !Object.ReferenceEquals(i, null))
            {
                if (g != i)
                {
                    g._instructores.Add(i);
                }
            }
            return g;
        }

       /// <summary>
       /// METODO PRIVATE QUE MOSTRARA LOS DATOS DEL GIMNASIO 
       /// 
       /// </summary>
       /// <param name="gim"></param>
       /// <returns></returns>
       private static string MostrarDatos(Gimnasio gim)
        {
            string mensaje = "";
            foreach (Jornada item in gim._jornada)
            {
                mensaje += ((Jornada)item).ToString();
            }
            return mensaje;
        }

       /// <summary>
       /// METODO QUE HARA PUBLICOS LOS DATOS DEL GIMNASIO 
       /// </summary>
       /// <returns></returns>
 
       public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }

       /// <summary>
       /// OPERADOR QUE VERIFICA SI HAY AL MENOS UN INSTRUCTOR CAPAZ DE DAR LA CLASE 
       /// </summary>
       /// <param name="gim">OBJETO GIMNASIO</param>
       /// <param name="clase">CLASE QUE ESPERA RETORNAR UN INSTRUCTOR</param>
       /// <returns></returns>
        public static Instructor operator ==(Gimnasio gim, Gimnasio.EClases clase)
       {
           
           if (!Object.ReferenceEquals(gim, null))
           {
               foreach (Instructor item in gim._instructores)
               {
                   if (item == clase)
                   {
                       return item;
                   }
               }
           }
           throw new SinInstructorException();
       }

      /// <summary>
      ///  OPERADOR DISTINTO QUE VERIFICA SI NO HAY UN INSTRUCTOR QUE NO PUEDA DAR LA CLASE 
      /// </summary>
      /// <param name="gim">OBJETO GIMNASIO</param>
      /// <param name="clase">CLASE A VERIFICAR </param>
      /// <returns></returns>
      public static Instructor operator !=(Gimnasio gim, Gimnasio.EClases clase)
       {
           if (!Object.ReferenceEquals(gim, null))
           {
               foreach (Instructor item in gim._instructores)
               {
                   if (item != clase)
                   {
                       return item;
                   }
               }
           }
           return null;
       }
       /// <summary>
       /// OPERADOR + QUE AGREGARA UNA NUEVA CLASE A LA JORNADA /SIEMPRE Y CUANDO HAYA UN INSTRUCTOR  Y ALUMNOS QUE TOMEN LA CLASE. 
       /// </summary>
       /// <param name="gim">OBJETO GIMNASIO</param>
       /// <param name="clase"></param>
       /// <returns></returns>
       public static Gimnasio operator +(Gimnasio gim, Gimnasio.EClases clase)
       {
           if (!Object.ReferenceEquals(gim, null))
           {
               switch (clase)
               { 
                   case Gimnasio.EClases.CrossFit:
                       Jornada aux = new Jornada(clase, gim == clase);
                       foreach (Alumno item in gim._alumnos)
                       {
                           if (item == clase)
                           {
                               aux += item;
                           }
                       }
                       gim._jornada.Add(aux);
                       return gim;
                   case Gimnasio.EClases.Natacion:
                       Jornada aux2 = new Jornada(clase, gim == clase);
                       foreach (Alumno item in gim._alumnos)
                       {
                           if (item == clase)
                           {
                               aux2 += item;
                           }
                       }
                       gim._jornada.Add(aux2);
                       return gim;
                   case Gimnasio.EClases.Pilates:
                       Jornada aux3 = new Jornada(clase, gim == clase);
                       foreach (Alumno item in gim._alumnos)
                       {
                           if (item == clase)
                           {
                               aux3 += item;
                           }
                       }
                       gim._jornada.Add(aux3);
                       return gim;
                   case Gimnasio.EClases.Yoga:
                       Jornada aux4 = new Jornada(clase, gim == clase);
                       foreach (Alumno item in gim._alumnos)
                       {
                           if (item == clase)
                           {
                               aux4 += item;
                           }
                       }
                       gim._jornada.Add(aux4);
                       return gim;
               }
           }
           return null;
       }
        #endregion
    }
}
