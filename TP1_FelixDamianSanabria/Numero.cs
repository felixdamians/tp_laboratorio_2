using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_FelixDamianSanabria
{
    class Numero
    {
        private double numero;
        /// <summary>
        /// OBJETO QUE NO CONTIENE PARAMETRO, SE INICIALIZA CON LA VARIABLE EN 0. 
        /// </summary>
        public Numero():this(0)
        {
            
        }
        /// <summary>
        /// INICIALIZA EL ATRIBUTO PRIVADO EN VARIABLE NUMERO. AL OBJETO SE LE PASA POR PARAMETRO UN DOUBLE numero.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public Numero (double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// ATRIBUTO DE CARACTER PUBLICO, SE PASA POR PARAMETRO CADENA NUMERO - REUTILIZACION DE CODIGO
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public Numero(string numero):this(double.Parse(numero))
        {
       
        }

        /// <summary>
        /// METODO PRIVADO SETTER QUE ASIGNA AL NUMERO LA FUNCION VALIDAR. 
        /// </summary>
        /// <param name="numero"></param>
        private void setNumero(string numero)           
            
        {
            this.numero = ValidarNumero(numero);
        }
        /// <summary>
        /// METODO QUE VALIDA NUMERO, SE PASA POR PARAMETRO LA CADENA NUMEROSTRING.-
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        private double ValidarNumero(string numeroString)   
        {

            bool caso;
            double result;
            double num;
             
            caso = double.TryParse(numeroString,out result);

            if(caso == true)
            {
                num = result;
            }
            else
            {
                num = 0;
            }

            return num;
        }
        /// <summary>
        /// METODO GET QUE RETORNA AL NUMERO. 
        /// </summary>
        /// <returns></returns>
        public double getNumero()
        {
            return this.numero;
        }

        }


    }

