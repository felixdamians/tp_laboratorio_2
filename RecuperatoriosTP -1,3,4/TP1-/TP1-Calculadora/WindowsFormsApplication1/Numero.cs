using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Numero
    {

        private double _numero;
        /// <summary>
        /// CONSTRUCTOR SIN PARAMETROS. INICIALIZA EL ATRIBUTO PRIVADO NUMERO EN 0.
        /// </summary>
        public Numero()
        {
            this._numero = 0;
        }

        /// <summary>
        /// CONSTRUCTOR CON PARAMETRO STRING. LE DA VALOR AL ATRIBUTO PRIVADO NUMERO CON UN PARSEO DOUBLE DEL STRING NUMERO.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            this._numero = double.Parse(numero);
        }

        /// <summary>
        /// CONSTRUCTOR CON PARAMETRO DOUBLE. LE DA VALOR AL ATRIBUTO PRIVADO NUMERO CON LA ASIGNACION DEL PARAMETRO.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this._numero = numero;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double getNumero()
        {
            return this._numero;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns></returns>
        private static double validarNumero(string numeroString)
        {

            bool pudo;
            double result;
            double numero;

            pudo = double.TryParse(numeroString, out result);

            if (pudo == true)
            {
                numero = result;
            }
            else
            {
                numero = 0;
            }

            return numero;
        }

        /// <summary>
        /// Propiedad que valida el numero como cadena de caracteres
        /// </summary>
        /// <param name="numero"></param>
        private void setNumero(string numero)
        {
            this._numero = validarNumero(numero);
        }

        

    }
}
