using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;

        #region "CONSTRUCTORES"

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        public Jornada(Gimnasio.EClases clase, Instructor instructor):this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion


        #region "PROPIEDADES"
        /// <summary>
        /// PROPIEDAD GET QUE SERIALIZA LAS CLASES
        /// </summary>
        public Gimnasio.EClases Clase
        {
            get
            {
                return this._clase;
            }
        }
        /// <summary>
        /// PROPIEDAD GET QUE SERIALIZA EL INSTRUCTOR
        /// </summary>
        public Instructor Instructor
        {
            get
            {
                return this._instructor;
            }
        }
        #endregion


        #region "METODOS"

        /// <summary>
        /// OPERADOR IGUALIGUAL QUE VERIFICA SI EL ALUMNO PARTICIPA DE ESA CLASE 
        /// </summary>
        /// <param name="j">OBJETO JORNADA</param>
        /// <param name="a">ALUMNO A BUSCAR EN LA CLASE</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            if (!Object.ReferenceEquals(j, null) && !Object.ReferenceEquals(a, null))
            {
                foreach (Alumno item in j._alumnos)
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
        /// OPERADOR DISTINTO QUE VERIFICA SI EL ALUMNO NO PARTICIPA DE LA CLASE 
        /// </summary>
        /// <param name="j">OBJETO JORNADA</param>
        /// <param name="a">ALUMNO QUE NO ESTA EN LA CLASE</param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// OPERADOR + QUE AGREGA A UN ALUMNO A LA CLASE SI EL MISMO NO PARTICIPA DE ELLA. 
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a agregar en la clase</param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!Object.ReferenceEquals(j, null) && !Object.ReferenceEquals(a, null))
            {
                if (j != a)
                {
                    j._alumnos.Add(a);
                }
            }
            return j;
        }
        /// <summary>
        /// METODO QUE HARA PUBLICOS LOS DATOS DE LA JORNADA
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\nJORNADA:");
            sb.AppendLine("");
            sb.AppendFormat("CLASE DE {0} POR {1} \n", this._clase.ToString(), this._instructor.ToString());
            sb.AppendFormat("ALUMNOS:");
            foreach (Alumno item in this._alumnos)
            {
                sb.AppendFormat("\n"+item.ToString());
            }
            sb.AppendLine("");
            sb.AppendFormat("<-------------------------->");
            return sb.ToString();
        }
        /// <summary>
        /// METODO QUE GUARDARA UNA JORNADA EN UN ARCHIVO TEXT
        /// </summary>
        /// <param name="jornada">JORNADA A GUARDAR</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto text = new Texto();
            if (text.guardar(@"C:\Jornada.txt", jornada.ToString()))
            {
              return true;
            }
            return false;
        }

        /// <summary>
        /// METODO QUE LEERA UN ARCHIVO DE TEXTO Y LO MOSTRARA POR CONSOLA 
        /// </summary>
        /// <param name="jornada">JORNADA A LEER</param>
        /// <returns></returns>
        public static bool Leer(Jornada jornada)
        {
            Texto text = new Texto();
            string datos;
            if (text.leer(@"C:\Jornada.txt", out datos))
            {
            Console.WriteLine(datos);
            return true;
            }
            return false;
        }

        
        #endregion
    }
}
