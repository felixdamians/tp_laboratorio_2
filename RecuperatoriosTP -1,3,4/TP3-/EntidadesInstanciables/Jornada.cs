using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;

        private Gimnasio.EClases _clase;

        private Instructor _instructor;


        #region "Propiedades---"

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }
        public Gimnasio.EClases Clases
        {
            get { return this._clase; }
            set { this._clase = value; }
        }
        public Instructor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value;}
        }

        #endregion

        #region "Metodo---"
        /// <summary>
        /// 
        /// </summary>
        public Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        #endregion

        #region "Metodos---"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();

            return texto.guardar("Jornada.txt", jornada.ToString());

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("JORNADA:\n");
            sb.AppendFormat("CLASE DE: {0} POR {1} \n", this._clase.ToString(), this._instructor.ToString());
            foreach (Alumno item in this._alumnos)
            {
                sb.AppendFormat(((Alumno)item).ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        ///   REVISAR-------------------------------------------------------------
        /// </summary>
        /// <param name="clases"></param>
        /// <param name="i"></param>
        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            :this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        #endregion

        #region "Operadores----"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
        if(!Object.ReferenceEquals(j,null) && !Object.ReferenceEquals(a,null))
            foreach (Alumno item in j._alumnos)
            {
                if (item == a)
                    return true;

            }
        return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// REVISA---------------------------------------------------------
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!Object.ReferenceEquals(j, null) && !Object.ReferenceEquals(a, null))
                if (a == j._clase)
                    j._alumnos.Add(a);

            return j;
        }


        #endregion

    }
}
