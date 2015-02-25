using System;
using NUnit.Framework;
using Real;

namespace Testing
{
    [TestFixture]
    public class Test
    {

        private RealNumber _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new RealNumber();
        }

        [Test]
        public void Should_Sum_Right_BigInteger_Case()
        {
            var num1 = new RealNumber("1");
            var num2 = new RealNumber("99999");
            Assert.AreEqual((num1+num2).ToString(), "100000");
        }

        [Test]
        public void Should_String_Right()
        {
            var num1 = new RealNumber("1.10");
            Assert.AreEqual(num1.ToString(), "1.10");
        }


        [Test]
        public void Should_String_Right1()
        {
            var num1 = new RealNumber("93124.10");
            Assert.AreEqual(num1.ToString(), "93124.10");
        }

        [Test]
        [ExpectedException(typeof (InvalidOperationException))]
        public void Should_Should_Throw_Exception_When_Number_Is_Written_Wrong()
        {
            var num1 = new RealNumber("93124.1.0");
            Assert.AreEqual(num1.ToString(), "93124.10");   
        }

        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void Should_Should_Throw_Exception_When_Number_Is_Written_Wrong1()
        {
            var num1 = new RealNumber("93124.1a0");
            Assert.AreEqual(num1.ToString(), "93124.10");
        }


        [Test]
        public void Should_Sum_Right_Real_Case()
        {
            var num1 = new RealNumber("1.10");
            var num2 = new RealNumber("99999");
            Assert.AreEqual((num1 + num2).ToString(), "100000.10");
        }

        [Test]
        public void Should_Sum_Right_Real_Case1()
        {
            var num1 = new RealNumber("10.110");
            var num2 = new RealNumber("99990");
            Assert.AreEqual((num1 + num2).ToString(), "100000.110");
        }


        [Test]
        public void Should_Sum_Right_Real_Case2()
        {
            var num1 = new RealNumber("1111.11111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual((num1 + num2).ToString(), "11111.111109");
        }

        [Test]
        public void Should_Sum_Right_Real_Case3()
        {
            var num1 = new RealNumber("0.11111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual((num1 + num2).ToString(), "10000.111109");
        }

        [Test]
        public void Should_Sum_Right_Real_Case4()
        {
            var num1 = new RealNumber("0.00111111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual((num1 + num2).ToString(), "10000.00111011");
        }


        [Test]
        public void Should_Sum_Right_Real_Case5()
        {
            var num1 = new RealNumber("0.00111111");
            var num2 = new RealNumber("9999");
            Assert.AreEqual((num1 + num2).ToString(), "9999.00111111");
        }

        [Test]
        public void Should_Subtract_Right_BigInteger_Case()
        {
            var num1 = new RealNumber("1");
            var num2 = new RealNumber("99999");
            Assert.AreEqual((num1 - num2).ToString(), "-99998");
        }

        [Test]
        public void Should_Subtract_Right_BigInteger_Case1()
        {
            var num1 = new RealNumber("99999");
            var num2 = new RealNumber("1");
            Assert.AreEqual((num1 - num2).ToString(), "99998");
        }

        [Test]
        public void Should_Subtract_Right_Real_Case()
        {
            var num1 = new RealNumber("1.10");
            var num2 = new RealNumber("99999");
            Assert.AreEqual((num1 - num2).ToString(), "-99997.90");
        }

        [Test]
        public void Should_Subtract_Right_Real_Case1()
        {
            var num1 = new RealNumber("10.110");
            var num2 = new RealNumber("99990");
            Assert.AreEqual((num1 - num2).ToString(), "-99979.890");
        }


        [Test]
        public void Should_Subtract_Right_Real_Case2()
        {
            var num1 = new RealNumber("1111.11111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual((num1 - num2).ToString(), "-8888.888889");
        }

        [Test]
        public void Should_Subtract_Right_Real_Case3()
        {
            var num1 = new RealNumber("0.11111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual((num1 - num2).ToString(), "-9999.888889");
        }

        [Test]
        public void Should_Subtract_Right_Real_Case4()
        {
            var num1 = new RealNumber("0.00111111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual((num1 - num2).ToString(), "-9999.99888789");
        }


        [Test]
        public void Should_Subtract_Right_Real_Case5()
        {
            var num1 = new RealNumber("0.00111111");
            var num2 = new RealNumber("9999");
            Assert.AreEqual((num1 - num2).ToString(), "-9998.99888889");
        }

        [Test]
        public void Should_Subtract_Right_Real_Case6()
        {
            var num1 = new RealNumber("9999");
            var num2 = new RealNumber("0.00111111");
            Assert.AreEqual((num1 - num2).ToString(), "9998.99888889");
        }
    }
}
