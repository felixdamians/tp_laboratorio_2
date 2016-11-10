using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Instructor : PersonaGimnasio
    {
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;
        
        #region "CONSTRUCTORES"
        /// <summary>
        /// CONSTRUCTOR PUBLIC QUE PERMITE SERIALIZAR  
        /// </summary>
        public Instructor()
        { }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this.RandomClases();
            this.RandomClases();
        }

        static Instructor()
        {
            Instructor._random = new Random();
        }
#endregion

        #region "METODOS"

        /// <summary>
        /// METODO RANDOM QUE ASIGNA UNA CLASE AL AZAR 
        /// </summary>
        private void RandomClases()
        {
            this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(0, 3));
        }

        /// <summary>
        /// METODO PROTEGIDO QUE RETORNA UN STRING CON LAS CLASES ASIGNADAS AL INSTRUCTOR 
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            string mensaje = "CLASES DEL DIA:\n";
            string aux = "";
            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                aux += item.ToString()+"\n";
            }
            return mensaje + aux;
        }

        /// <summary>
        /// METODO PROTEGIDO QUE RETORNARA LOS DATOS DEL INSTRUCTOR 
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos();
        }
        /// <summary>
        /// METODO QUE HARA PUBLICO LOS DATOS DEL INSTRUCTOR 
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos() + this.ParticiparEnClase()+"\n";
        }

        /// <summary>
        ///  OPERADOR IGUALIGUAL QUE VERIFICA SI EL INSTRUCTOR DA ESA CLASE 
        /// </summary>
        /// <param name="i">OBJETO INSTRUCTOR</param>
        /// <param name="clase">CLASE QUE DA EL INSTRUCTOR </param>
        /// <returns></returns>
        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            if (!Object.ReferenceEquals(i, null))
            {     
                foreach (Gimnasio.EClases item in i._clasesDelDia)
                {
                    if (item == clase)
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        /// <summary>
        /// OPERADOR DISTINTO QUE VERIFICA SI EL INSTRUCTOR NO DA ESA CLASE
        /// </summary>
        /// <param name="i">INSTRUCTOR A COMPARAR</param>
        /// <param name="clase">CLASE QUE NO DA EL INSTRUCTOR</param>
        /// <returns></returns>
        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
