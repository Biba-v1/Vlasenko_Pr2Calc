using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalcLib;

namespace CalcLibUnitTest
{
    [TestClass]
    public class Calc_Priority_Tests
    {
        // ПРоверка метода на выдачу приоритетов.

        [TestMethod]
        public void prioritytyTest_Minusik()
        {
            char x = '-';

            int expected = 1;
            int actual = Calc.priorityty(x);


            Assert.AreEqual(expected, actual, "Приоритеты не совпадают, метод хлам!");
        }

        [TestMethod]
        public void prioritytyTest_Plusik()
        {
            char x = '+';

            int expected = 1;
            int actual = Calc.priorityty(x);


            Assert.AreEqual(expected, actual, "Приоритеты не совпадают, метод хлам!");
        }

        [TestMethod]
        public void prioritytyTest_Delenie()
        {
            char x = '/';

            int expected = 2;
            int actual = Calc.priorityty(x);


            Assert.AreEqual(expected, actual, "Приоритеты не совпадают, метод хлам!");
        }

        [TestMethod]
        public void prioritytyTest_Umnozenie()
        {
            char x = '*';

            int expected = 2;
            int actual = Calc.priorityty(x);


            Assert.AreEqual(expected, actual, "Приоритеты не совпадают, метод хлам!");
        }

        [TestMethod]
        public void prioritytyTest_kvadrat()
        {
            char x = '^';

            int expected = 3;
            int actual = Calc.priorityty(x);


            Assert.AreEqual(expected, actual, "Приоритеты не совпадают, метод хлам!");
        }

        [TestMethod]
        public void prioritytyTest_UnidentifiedSymbols()
        {
            char x = '@';

            int expected = 0;
            int actual = Calc.priorityty(x);

            Assert.AreEqual(expected, actual, "Приоритеты не совпадают, метод хлам!");
        }
    }
}
