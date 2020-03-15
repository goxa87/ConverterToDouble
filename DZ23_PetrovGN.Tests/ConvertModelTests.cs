using Microsoft.VisualStudio.TestTools.UnitTesting;
using DZ23_PetrovGN.Logic;
using DZ23_PetrovGN;

namespace DZ23_PetrovGN.Tests
{
    [TestClass]
    public class ConvertModelTests
    {
        /// <summary>
        /// Корректные данные.
        /// </summary>
        [TestMethod]
        public void ConvertToDouble_CorrectInput()
        {
            // Настройка.
            var logic = new ConvertModel();
            string input = "123456789,12345";
            double expected = 123456789.12345;
            // Действие.
            double rezult = logic.ConvertToDouble(input);
            // Проверка.
            Assert.AreEqual(expected, rezult, 0.0000001); 
        }
        /// <summary>
        /// Корректные данные, отрицательное число.
        /// </summary>
        [TestMethod]
        public void ConvertToDouble_CorrectInputMinus()
        {
            // Настройка.
            var logic = new ConvertModel();
            string input = "-123456789,12345";
            double expected = -123456789.12345;
            // Действие.
            double rezult = logic.ConvertToDouble(input);
            // Проверка.
            Assert.AreEqual(expected, rezult, 0.0001);
        }

        /// <summary>
        /// Пустая строка.
        /// </summary>
        [TestMethod]
        public void ConvertToDouble_EmptyInput_Exception()
        {
            // Настройка.
            var logic = new ConvertModel();
            string input = "";
            // Действие.
            // Проверка.
            Assert.ThrowsException<MyConvertException>(() => logic.ConvertToDouble(input));
        }

        [TestMethod]
        public void ConvertToDouble_ManySeparators_Exception()
        {
            // Настройка.
            var logic = new ConvertModel();
            string input = "123,123,123";
            // Действие.
            // Проверка.
            Assert.ThrowsException<MyConvertException>(() => logic.ConvertToDouble(input));
        }

        [TestMethod]
        public void ConvertToDouble_IncorrectSymbols_Exception()
        {
            // Настройка.
            var logic = new ConvertModel();
            string input = "123,12t123";
            // Действие.
            // Проверка.
            Assert.ThrowsException<MyConvertException>(() => logic.ConvertToDouble(input));
        }

        [TestMethod]
        public void ConvertToDouble_SepaaratorAtFirstplace_Exception()
        {
            // Настройка.
            var logic = new ConvertModel();
            string input = ",12312123";
            // Действие.
            // Проверка.
            Assert.ThrowsException<MyConvertException>(() => logic.ConvertToDouble(input));
        }

        [TestMethod]
        public void ConvertToDouble_SepaaratorAtFirstplaceAfterMinus_Exception()
        {
            // Настройка.
            var logic = new ConvertModel();
            string input = "-,12312123";
            // Действие.
            // Проверка.
            Assert.ThrowsException<MyConvertException>(() => logic.ConvertToDouble(input));
        }

    }
}
