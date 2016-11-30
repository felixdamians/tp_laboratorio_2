using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno:PersonaGimnasio
    {
        #region "Atributos---"
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            MesPrueba
        }

        private Gimnasio.EClases _clasesQueToma;

        private EEstadoCuenta _estadoCuenta;
        #endregion

        #region "Constructores---"

        public Alumno()
        { }
        /// <summary>
        /// CONSTRUCTOR POR EL CUAL INSTANCIA LAS CLASES QUE TOMA EL ALUMNO 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="clasesQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad ,Gimnasio.EClases clasesQueToma )
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesQueToma = clasesQueToma;
        }

        /// <summary>
        /// CONSTRUCTOR POR EL CUAL INSTANCIA EL ESTADO DE CUENTA
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="clasesQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases clasesQueToma, EEstadoCuenta estadoCuenta)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            //sb.AppendLine(base.MostrarDatos());
            //sb.AppendLine();
            //sb.AppendFormat("Estado de cuenta: {0}" + this._estadoCuenta.ToString()).AppendLine();
            //sb.AppendFormat("Clases que toma: {0}" + this._clasesQueToma.ToString()).AppendLine();

            return base.MostrarDatos();
        }

        public override string ToString()
        {
            return this.MostrarDatos() + this.ParticiparEnClase() + "\nESTADO DE CUENTA:" + this._estadoCuenta.ToString() + "\n";
        }

        protected override string ParticiparEnClase() 
        {
           
               string mensaje = "TOMA CLASES DE :\n " + this._clasesQueToma.ToString();
               return mensaje;
        }
        #endregion

        #region "Operadores---"

        /// <summary>
        /// OPERADOR QUE VALIDA SI EL ALUMNO SE ENCUENTRA EN ESA CLASE 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            if (a._clasesQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
           
                return true;
            
            return false;
        }

        /// <summary>
        ///  OPERADOR QUE VALIDA SI EL ALUMNO NO SE ENCUENTRA EN ESA CLASE 
        /// /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
       {
           return (a._clasesQueToma != clase);
        }

        #endregion


    }
}
