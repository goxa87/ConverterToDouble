using Microsoft.VisualStudio.TestTools.UnitTesting;
using DZ23_PetrovGN.Logic;
using DZ23_PetrovGN;

namespace DZ23_PetrovGN.Tests
{
    [TestClass]
    public class ConvertModelTests
    {
        /// <summary>
        /// ���������� ������.
        /// </summary>
        [TestMethod]
        public void ConvertToDouble_CorrectInput()
        {
            // ���������.
            var logic = new ConvertModel();
            string input = "123456789,12345";
            double expected = 123456789.12345;
            // ��������.
            double rezult = logic.ConvertToDouble(input);
            // ��������.
            Assert.AreEqual(expected, rezult, 0.0000001); 
        }
        /// <summary>
        /// ���������� ������, ������������� �����.
        /// </summary>
        [TestMethod]
        public void ConvertToDouble_CorrectInputMinus()
        {
            // ���������.
            var logic = new ConvertModel();
            string input = "-123456789,12345";
            double expected = -123456789.12345;
            // ��������.
            double rezult = logic.ConvertToDouble(input);
            // ��������.
            Assert.AreEqual(expected, rezult, 0.0001);
        }

        /// <summary>
        /// ������ ������.
        /// </summary>
        [TestMethod]
        public void ConvertToDouble_EmptyInput_Exception()
        {
            // ���������.
            var logic = new ConvertModel();
            string input = "";
            // ��������.
            // ��������.
            Assert.ThrowsException<MyConvertException>(() => logic.ConvertToDouble(input));
        }

        [TestMethod]
        public void ConvertToDouble_ManySeparators_Exception()
        {
            // ���������.
            var logic = new ConvertModel();
            string input = "123,123,123";
            // ��������.
            // ��������.
            Assert.ThrowsException<MyConvertException>(() => logic.ConvertToDouble(input));
        }

        [TestMethod]
        public void ConvertToDouble_IncorrectSymbols_Exception()
        {
            // ���������.
            var logic = new ConvertModel();
            string input = "123,12t123";
            // ��������.
            // ��������.
            Assert.ThrowsException<MyConvertException>(() => logic.ConvertToDouble(input));
        }

        [TestMethod]
        public void ConvertToDouble_SepaaratorAtFirstplace_Exception()
        {
            // ���������.
            var logic = new ConvertModel();
            string input = ",12312123";
            // ��������.
            // ��������.
            Assert.ThrowsException<MyConvertException>(() => logic.ConvertToDouble(input));
        }

        [TestMethod]
        public void ConvertToDouble_SepaaratorAtFirstplaceAfterMinus_Exception()
        {
            // ���������.
            var logic = new ConvertModel();
            string input = "-,12312123";
            // ��������.
            // ��������.
            Assert.ThrowsException<MyConvertException>(() => logic.ConvertToDouble(input));
        }

    }
}
