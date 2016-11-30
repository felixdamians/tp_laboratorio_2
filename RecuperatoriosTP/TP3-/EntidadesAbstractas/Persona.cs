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

        #region "Atributos---"
        private string _nombre;
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region "Propiedades---"
        public string Nombre
        {
            get { return this._nombre; }
            set
            {
              this._nombre= Persona.ValidarNombreApellido(value);
            }
        }

        public string Apellido
        {
            get { return this._apellido; }
            set 
            {
                this._apellido = Persona.ValidarNombreApellido(value);
            }

        }


        public int DNI
        {
            get { return this._dni;}
            set { this._dni = Persona.ValidarDni(this._nacionalidad, value);}
        }

        public string StringToDNI
        {
            set
            {
                this._dni = Persona.ValidarDni(this.Nacionalidad, value);
            }
        }

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

        #endregion



        #region "Constructores---"

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public Persona() { }
        /// <summary>
        /// CONSTRUCTOR EL CUAL INSTANCIA LOS ATRIBUTOS DE NOMBRE, APELLIDO Y NACIONALIDAD
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this.Nacionalidad = nacionalidad;

        }

        

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }


        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion



        #region "VALIDADORES & METODO"
        private static string ValidarNombreApellido(string dato)
        {
            // Expresión regular para buscar solo caracteres de la a a la z minúsculas y mayúsculas con N repeticiones
            Regex regex = new Regex(@"[a-zA-Z]*");
            // Valido el dato
            Match match = regex.Match(dato);

            if (match.Success)
                return match.Value;
            else
                return "";
        }
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        /// 
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            //Quito los . que pueda tener el dni
            dato = dato.Replace(".", "");
            // Compruebo que el dni tenga por lo menos un 1 numero y no más de 8.
            if (dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException(dato.ToString());
            int numeroRetorno;
            try
            {
                numeroRetorno = int.Parse(dato);
            }
            catch (Exception e)
            {
                throw new DniInvalidoException(dato.ToString(), e);
            }

            return Persona.ValidarDni(nacionalidad, numeroRetorno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
            sb.AppendLine();
            sb.AppendFormat("NACIONALIDAD: {0}", this.Nacionalidad.ToString());
            sb.AppendLine();

            return sb.ToString();
        }

        #endregion


    }
}
