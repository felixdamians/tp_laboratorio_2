using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.Xml.Serialization;
using System.Xml;
using EntidadesAbstractas;



namespace EntidadesInstanciables
{
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Persona))]
    [XmlInclude(typeof(PersonaGimnasio))]

    public class Gimnasio
    {

        #region "Atributos---"
        private List<Alumno> _alumnos;

        private List<Instructor> _instructores;

        private List<Jornada> _jornada;

        public enum EClases
        {
            Natacion,
            CrossFit,
            Pilates,
            Yoga
        }

        #endregion 


        #region "Constructor---"
        /// <summary>
        /// CONSTRUCTOR POR EL CUAL INSTANCIA LA JORNADA, ALUMNOS E INSTRUCTORES EN LISTAS. 
        /// </summary>
        public Gimnasio() 
        {
            this._jornada = new List<Jornada>();
            this._instructores = new List<Instructor>();
            this._alumnos = new List<Alumno>();
        }
        #endregion

        #region "Metodos---"
        /// <summary>
        /// METODO POR EL CUAL GUARDAREMOS EL ARCHIVO EN UN XML. 
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Guardar(Gimnasio gim)
        {
            Archivos.Xml<Gimnasio> xml = new Archivos.Xml<Gimnasio>();

            return xml.guardar("Gimnasio.xml",gim);


        }
        /// <summary>
        /// DEVUELDE UN STRING CON LOS DATOS DE LA JORNADA 
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Jornada:");

            for (int i = 0; i < gim._jornada.Count; i++)
            {
                sb.AppendLine(gim[i].ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }

        #endregion

        #region "INDEXADOR---"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                if (i <= this._jornada.Count)
                    return this._jornada[i];
                else
                    return null;
            }
        }

        #endregion


        

        #region "Operadores---"
        /// <summary>
        ///  OPERADOR QUE VALIDA SI EL ALUMNO SE ENCUENTRA EN EL GIMNASIO
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            if (!Object.ReferenceEquals(g, null) && !Object.ReferenceEquals(a, null))
                foreach (Alumno item in g._alumnos)
                {
                   if( item == a)
                    return true;
                }
            return false;
        }
        /// <summary>
        /// OPERADOR DISTINTO SI EL ALUMNO NO SE ENCUENTRA EN EL GIMNASIO
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Gimnasio g, Alumno a)
        {
        return !(g==a); 
        }

        /// <summary>
        /// AGREGA UN ALUMNO AL GIMNASIO
        /// /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (!Object.ReferenceEquals(g, null) && !Object.ReferenceEquals(a, null))
                if (g == a)
                {
                    throw new AlumnoRepetidoException();
                }
                else
                {
                    g._alumnos.Add(a);
                }
            return g;
        }



        /// <summary>
        ///  OPERADOR EL CUAL VALIDA SI UNA CLASE YA SE ENCUENTRA EN EL GIMNASIO
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clases"></param>
        /// <returns></returns>
        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            if (!Object.ReferenceEquals(g,null) && !Object.ReferenceEquals(clase,null))
                foreach (Instructor item in g._instructores)
                {
                    if (item == clase)
                        return item;
                }

            throw new SinInstructorException();
            
        
        }
        /// <summary>
        /// OPERADOR EL CUAL VALIDA SI UNA CLASE NO SE ENCUENTRA EN EL GIMNASIO
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clases"></param>
        /// <returns></returns>
        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            if (!Object.ReferenceEquals(g, null))
                foreach (Instructor item in g._instructores)
                {
                    if (item != clase)
                        return item;
                }

            return null;
        }

        /// <summary>
        ///        OPERARADOR QUE AGREGA UNA CLASE AL GIMNASIO
        /// /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            if (!Object.ReferenceEquals(g, null))

                try
                {
                    Jornada j = new Jornada(clase, g == clase);
                    foreach (Alumno item in g._alumnos)
                    {
                        if (item == clase)
                            j += item;
                    }
                    g._jornada.Add(j);

                    return g;
                }

                catch (SinInstructorException e)
                {
                    throw e;
                }

            return g;
        }
    
        /// <summary>
        /// OPERADOR QUE VALIDA SI EL INSTRUCTOR SE ENCUENTRA EN EL GIMNASIO
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Gimnasio g, Instructor i)
        {
            if (!Object.ReferenceEquals(g, null) && !Object.ReferenceEquals(i, null))
            {
                foreach (Instructor item in g._instructores)
                {
                    if (item == i)
                        return true;
                }
            }
            return false;        
        }

        /// <summary>
        /// OPERADOR DISTINTO QUE VALIDA SI EL INSTRUCTOR NO SE ENCUENTRA EN EL GYM
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// OPERADOR QUE AGREGA UN INSTRUCTORR
        /// AL GIMNASIO
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
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


        #endregion



    }
}
