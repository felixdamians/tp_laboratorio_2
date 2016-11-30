using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Calculadora
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {


            double resultado, numeroUno, numeroDos;
            resultado = 0;
            operador = Calculadora.validarOperador(operador);
            numeroUno = numero1.getNumero();
            numeroDos = numero2.getNumero();
            switch (operador)
            {
                case "+":
                    resultado = numeroUno + numeroDos;
                    break;
                case "-":
                    resultado = numeroUno - numeroDos;
                    break;
                case "*":
                    resultado = numeroUno * numeroDos;
                    break;
                case "/":
                    if (numeroDos == 0)
                    {
                        resultado = 0;
                    }
                    else
                    {
                        resultado = numeroUno / numeroDos;
                    }
                    break;
            }
            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static string validarOperador(string operador)
        {
            string retorno;

            if (operador == "+" || operador == "*" || operador == "/" || operador == "-")
            {
                retorno = operador;
            }
            else
            {
                retorno = "+";
            }
            return retorno;
        }
    }
}
