using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabNetPractica2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void DividirTest()
        {
            string dividendoString = "9";
            string divisorString = "3";
            int resultadoEsperado = 3;

            int resultadoObtenido = Program.Dividir(dividendoString, divisorString);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DividirPorCeroTest()
        {
            string dividendoString = "15";
            string divisorString = "0";

            int resultadoObtenido = Program.Dividir(dividendoString, divisorString);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void IngresarLetraAlDividirTest()
        {
            string dividendoString = "a";
            string divisorString = "3";

            int resultadoObtenido = Program.Dividir(dividendoString, divisorString);
        }
    }
}