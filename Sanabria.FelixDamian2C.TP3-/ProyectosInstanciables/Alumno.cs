using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : PersonaGimnasio
    {
        public enum EEstadoCuenta
        { 
        MesPrueba,
        AlDia,
        Deudor
        }

        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #region "CONSTRUCTORES"
        /// <summary>
        /// CONSTRUCTOR ALUMNO PARA PODER SERIALIZAR 
        /// </summary>
        public Alumno()
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion
        
        #region "METODOS"

        /// <summary>
        ///  METODO PROTEGIDO SOBREESCRITO QUE MOSTRARA LOS DATOS DE UN ALUMNO 
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos();
        }
       

        /// <summary>
        /// METODO PROTEGIDO SOBREEESCRITO DE LA CLASE PERSONAGIMNASIO 
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
           string mensaje = "TOMA CLASES DE:" + this._claseQueToma.ToString();
           return mensaje;
        }

        /// <summary>
        /// METODO PUBLICO QUE MOSTRARA LOS DATOS DEL ALUMNO 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos() +this.ParticiparEnClase() + "\nESTADO DE CUENTA:" + this._estadoCuenta.ToString()+"\n";
        }

        /// <summary>
        /// VERIFICA SI UN ALUMNO TOMA ESA CLASE Y SU ESTADO ES NO DEUDOR 
        /// </summary>
        /// <param name="a">OBJETO ALUMNO</param>
        /// <param name="clase">CLASE QUE TOMA EL ALUMNO</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            if (!Object.ReferenceEquals(a, null))
            {
                if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///  VERIFICA SI EL ALUMNO NO TOMA ESA CLASE 
        /// </summary>
        /// <param name="a">OBJETO ALUMNO</param>
        /// <param name="clase">CLASE QUE NO TOMA EL ALUMNO</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            if (!Object.ReferenceEquals(a, null))
            {
                if (a._claseQueToma != clase)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

    }
}
