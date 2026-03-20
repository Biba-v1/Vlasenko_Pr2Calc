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
    public class Calc_SortStansia
    {
        [TestMethod]
        public void SortStancia_SloznieVir()
        {
            //Проверка на то сможет ли данный метод верно интерпретировать полученое выражение.
            
            string virazenie = "9-1*3+2^2-(3+1)*2";
            string[] expected = { "9", "1", "3", "*", "-", "2", "2", "^", "+", "3", "1", "+", "2", "*", "-" };

            string[] z = Calc.SortStancia(virazenie, out int count);

            string[] actual = new string[count];
            Array.Copy(z, actual, count);

            CollectionAssert.AreEqual(expected, actual, "RPN не совпадают, метод хлам!");
        }

        [TestMethod]
        public void SortStancia_VirSMinusVNachale()
        {
            //Проверка на то сможет ли данный метод верно интерпретировать полученое выражение.

            string virazenie = "-9+2*3";
            string[] expected = {"-9", "2", "3", "*", "+"};

            string[] z = Calc.SortStancia(virazenie, out int count);

            string[] actual = new string[count];
            Array.Copy(z, actual, count);

            CollectionAssert.AreEqual(expected, actual, "RPN не совпадают, метод хлам!");
        }

        [TestMethod]
        public void SortStancia_VirSDoubleTip()
        {
            //Проверка на то сможет ли данный метод верно интерпретировать полученое выражение.

            string virazenie = "3.8 - 28.13";
            string[] expected = { "3.8", "28.13", "-"};

            string[] z = Calc.SortStancia(virazenie, out int count);

            string[] actual = new string[count];
            Array.Copy(z, actual, count);

            CollectionAssert.AreEqual(expected, actual, "RPN не совпадают, метод хлам!");
        }
    }
}
