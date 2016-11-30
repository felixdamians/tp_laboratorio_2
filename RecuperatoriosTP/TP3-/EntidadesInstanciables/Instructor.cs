using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Instructor:PersonaGimnasio
    {


        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;


        #region "Metodos---"

        /// <summary>
        /// METODO QUE ELIGE AL AZAR UN INSTRUCTOR PARA LA CLASE
        /// </summary>
        private void RandomClases()
        {
            this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(0, 3));
            
        }
        public Instructor() { }

        /// <summary>
        ///  METODO RANDOM PARA INSTRUCTOR
        /// </summary>
        static Instructor() 
        {
            Instructor._random = new Random();
        }

        /// <summary>
        /// CONSTRUCTOR QUE INSTANCIA LOS ATRIBUTOS DE LA CLASE ---- Y LAS CLASES DEL DIA LAS AGREGA A LA COLA. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad )
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this.RandomClases();
            this.RandomClases();
        }

        /// <summary>
        /// MUESTRA LOS DATOS DEL INSTRUCTOR A TRAVES DE SU CLASE BASE. 
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos();

        }
        /// <summary>
        /// DEVUELSE UN STRING CON TODOS LOS DATOS DE LA CLASE DEL INSTRUCTOR 
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            string mensaje = "CLASES DEL DIA:\n";
            string aux = "";
            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                aux += item.ToString() + "\n";
            }
            return mensaje + aux;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos() + this.ParticiparEnClase() + "\n";
        }


        


        #endregion


        #region "Operadores---"

        /// <summary>
        /// REVISAR-----------------------------    
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        { 
        if(!Object.ReferenceEquals(i,null))
            foreach (Gimnasio.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                    return true;
            }
        return false;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
