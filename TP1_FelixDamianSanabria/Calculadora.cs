using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_FelixDamianSanabria
{
    class Calculadora
    {
        /// <summary>
        /// METODO ESTATICO, QUE REALIZA LA OPERACION ARITMETICA. 
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {


            double resultado=0, numeroUno, numeroDos;
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
        /// METODO ESTATICO DE LA CLASE, QUE VALIDA EL OPERADOR POR EL CUAL OPERARA LA CUENTA. 
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static string validarOperador(string operador)
        {
            string exito;

            if (operador == "+" || operador == "*" || operador == "/" || operador == "-")
            {
                exito= operador;
            }
            else
            {
                exito = "+";
            }
            return exito;
        }
    }
}
