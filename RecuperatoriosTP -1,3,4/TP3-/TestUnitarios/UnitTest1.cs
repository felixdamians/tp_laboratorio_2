using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// ------------------------- CASO 1_  DNI-INVALIDO----------------------------------------
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            
            try
            {
                string dni = "30.950.733";
                Alumno a1 = new Alumno(1, "Ignacio", "Sanabria", dni, EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Gimnasio.EClases.CrossFit);
                Assert.Fail("No hay excepcion para DNI Invalido: {0}", dni);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }


      
        /// <summary> ---------------- CASO 2_ VALORES NULOS -----------------------------------------------------------------------
        /// Comprueba que no haya valores nulos
        /// Arroja NullReferenceException
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            try
            {
                Gimnasio gim = new Gimnasio();
                Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion,
                Alumno.EEstadoCuenta.Deudor);
                Alumno a3 = null;
                gim += a2;
                gim += a3;
                Assert.Fail("Sin excepcion para NullReferenceException");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NullReferenceException));
            }
        }

    }
}
