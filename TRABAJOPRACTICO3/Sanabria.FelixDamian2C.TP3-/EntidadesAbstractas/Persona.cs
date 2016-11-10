using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        private ENacionalidad _nacionalidad;
        private string _nombre;

        /// <summary>
        /// CONSTRUCTOR DE PERSONA, EN EL CUAL PODREMOS SERIALIZAR 
        /// </summary>
        public Persona()
        { }

        #region "PROPIEDADES"
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = Persona.ValidarNombreApellido(value);
            }
        }
        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = Persona.ValidarDni(this.Nacionalidad, value);
            }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = Persona.ValidarNombreApellido(value);
            }
        }
        public string StringToDNI
        {
            set
            {
                this._dni = Persona.ValidarDni(this.Nacionalidad, value);
            }
        }

        #endregion

        #region "CONSTRUCTORES"
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region "METODOS"
        
       /// <summary>
       /// VALIDARA EL DNI, DENTRO DEL RAGO PERMITIDO. Y SEGUN LA NACIONALIDAD.
       /// </summary>
       /// <param name="nacionalidad"></param>
       /// <param name="dato"></param>
       /// <returns>DNI validado si todo esta correcto, o 0(cero) en caso de error</returns>
       private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            { 
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                    {
                        throw new NacionalidadInvalidaException(dato.ToString());
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 89999999 || dato > 99999999)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
            }
            return dato;
        }

      
        /// <summary>
        /// VALIDARA QUE SEA UN DNI VALIDO, A TRAVES DEL STRING QUE SE LE PASE. 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        { 
            //Quito los . que pueda tener el dni
            dato = dato.Replace(".","");
           // Compruebo que el dni tenga por lo menos un 1 numero y no más de 8.
            if(dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException(dato.ToString());
            int numeroRetorno;
            try
            {
                numeroRetorno = int.Parse(dato);
            }
            catch(Exception e)
            {
             throw new DniInvalidoException(dato.ToString(),e);
            }

            return Persona.ValidarDni(nacionalidad,numeroRetorno);
        }

        /// <summary>
        /// VALIDARA QUE EL NOMBRE, Y EL DNI ESTE COMPUESTO POR LETRAS DE LA "a" A LA "z". 
        /// </summary>
        /// <param name="dato">NOMBRE Y APELLIDO A VALIDAR</param>
        /// <returns></returns>
        private static string ValidarNombreApellido(string dato)
        {
            //Expresión regular que sirve para buscar caracteres de a a la z minúsculas y mayúsculas con infinita repeticiones.
            Regex regex = new Regex(@"[a-zA-Z]*");
            //Valido el dato 
            Match match = regex.Match(dato);

            if (match.Success)
            {
                return match.Value;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// METODO PUBLICO QUE MOSTRARA LOS DATOS DE UNA PERSONA. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO:{0} , {1}", this._nombre, this._apellido);
            sb.AppendFormat("NACIONALIDAD: {0}", this._nacionalidad);
            return sb.ToString();
        }
        #endregion

    }
}
