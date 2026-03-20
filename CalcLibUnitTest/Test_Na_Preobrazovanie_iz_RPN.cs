using CalcLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibUnitTest
{
    [TestClass]
    public class Test_PolnovaAlgoritmaRPN
    {
        [TestMethod]
        public void calcc()
        {
            // Проверка основного метода, который включает в себя остальные 2

            string z = "9-1*3+2^2-(3+1)*2";

            string expected = "2";

            string actual = Calc.RPN(z);

            Assert.AreEqual(expected, actual, "Всё фигня, давай по новой.");
        }

        [TestMethod]
        public void calcc_DelenieNa0()
        {
            // Проверка основного метода, который включает в себя остальные 2

            string z = "9-1*3+2^2-(3+1)*2/0";

            string expected = "На ноль делить незя!";

            string actual = Calc.RPN(z);

            Assert.AreEqual(expected, actual, "Всё фигня, давай по новой.");
        }
    }
}
