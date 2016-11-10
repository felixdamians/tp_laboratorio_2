using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio : Persona
    {
        private int _identificador;

        #region "CONSTRUCTORES"
        /// <summary>
        /// CONSTRUCTOR DE PERSONA GIMNASIO PARA SERIALIZAR 
        /// </summary>
        public PersonaGimnasio()
        { 
        
        }
        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }
        #endregion

        #region "Metodos
        /// <summary>
        /// METODO PROTEGIDO VIRTUAL, EL CUAL MUESTRA LOS DATOS DE PERSONA 
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.ToString());
            sb.AppendFormat("\nCARNET NUMERO: {0}", this._identificador);
            sb.AppendLine("");
            return sb.ToString();
        }

        /// <summary>
        /// METODO ABSTRACTO QUE RETORNA UN STRING
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// COMPARA DOS OBJETOS. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is PersonaGimnasio)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// VERIFICA SI DOS PERSONAS SON IGUALES POR SU ID O DNI (OBJETO PERSONA)
        /// </summary>
        /// <param name="pg1"> OBJETO PersonaGimnasio 1 a comparar</param>
        /// <param name="pg2"> OBJETO PersonaGimnasio 2 a comparar</param>
        /// <returns></returns>
        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            if (!Object.ReferenceEquals(pg1, null) && !Object.ReferenceEquals(pg2, null))
            {
                if (pg1.Equals(pg2))
                {
                    if (pg1._identificador == pg2._identificador || pg1.DNI == pg2.DNI)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// VERIFICA SI DOS PERSONAS SON DISTINTAS POR SU ID O DNI (OBJETO PERSONA)
        /// </summary>
        /// <param name="pg1">PersonaGimnasio 1 a comparar</param>
        /// <param name="pg2">PersonaGimnasio 2 a comparar</param>
        /// <returns></returns>
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

    }
}
