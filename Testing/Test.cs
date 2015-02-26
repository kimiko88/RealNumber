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

        #region conversion test

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
        public void Should_String_Right2()
        {
            var num1 = new RealNumber("0.010");
            Assert.AreEqual(num1.ToString(), "0.010");
        }

        [Test]
        public void Should_String_Right3()
        {
            var num1 = new RealNumber("0.010101");
            Assert.AreEqual(num1.ToString(), "0.010101");
        }

        [Test]
        public void Should_String_Right4()
        {
            var num1 = new RealNumber("0.0000101013");
            Assert.AreEqual(num1.ToString(), "0.0000101013");
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
        #endregion

        #region summation test

        [Test]
        public void Should_Sum_Right_BigInteger_Case()
        {
            var num1 = new RealNumber("1");
            var num2 = new RealNumber("99999");
            Assert.AreEqual((num1 + num2).ToString(), "100000");
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
        #endregion

        #region subtraction test
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

        [Test]
        public void Should_Subtract_Right_Real_Case7()
        {
            var num1 = new RealNumber("0.01");
            var num2 = new RealNumber("0.00111111");
            Assert.AreEqual((num1 - num2).ToString(), "0.00888889");
        }
        #endregion

        #region multiplication test
        [Test]
        public void Should_Multiply_Right_BigInteger_Case()
        {
            var num1 = new RealNumber("1");
            var num2 = new RealNumber("99999");
            Assert.AreEqual((num1 * num2).ToString(), "99999");
        }

        [Test]
        public void Should_Multiply_Right_Real_Case()
        {
            var num1 = new RealNumber("1.10");
            var num2 = new RealNumber("99999");
            Assert.AreEqual((num1 * num2).ToString(), "109998.9000");
        }

        [Test]
        public void Should_Multiply_Right_Real_Case1()
        {
            var num1 = new RealNumber("10.110");
            var num2 = new  RealNumber("99990");
            Assert.AreEqual((num1 * num2).ToString(), "1010898.900000");
        }

        [Test]
        public void Should_Multiply_Right_Real_Case2()
        {
            var num1 = new RealNumber("1111.11111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual((num1 * num2).ToString(), "11111111.098888888890");
        }

        [Test]
        public void Should_Multiply_Right_Real_Case3()
        {
            var num1 = new RealNumber("0.11111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual((num1 * num2).ToString(), "1111.099999888890");
        }

        [Test]
        public void Should_Multiply_Right_Real_Case4()
        {
            var num1 = new RealNumber("0.00111111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual((num1 * num2).ToString(), "11.1110999988888900");
        }

        [Test]
        public void Should_Multiply_Right_Real_Case5()
        {
            var num1 = new RealNumber("0.00111111");
            var num2 = new RealNumber("9999");
            Assert.AreEqual((num1 * num2).ToString(), "11.1099888900000000");
        }

        [Test]
        public void Should_Multiply_Right_Real_Case6()
        {
            var num1 = new RealNumber("9999");
            var num2 = new RealNumber("0.00111111");
            Assert.AreEqual((num1 * num2).ToString(), "11.1099888900000000");
        }

        [Test]
        public void Should_Multiply_Right_Real_Case7()
        {
            var num1 = new RealNumber("0.01");
            var num2 = new RealNumber("0.00111111");
            Assert.AreEqual((num1 * num2).ToString(), "0.0000111111000000");
        }
        #endregion

        #region division operator test
        [Test]
        public void Should_Divide_Right_BigInteger_Case()
        {
            var num1 = new RealNumber("1");
            var num2 = new RealNumber("99999");
            Assert.AreEqual((num1 / num2).ToString(), "0.0000100001000010000");
        }

        [Test]
        public void Should_Divide_Right_Real_Case()
        {
            var num1 = new RealNumber("1.10");
            var num2 = new RealNumber("99999");
            var pp = (num1/num2).ToString();
            Assert.AreEqual((num1 / num2).ToString(), "0.000011000110001");
        }

        [Test]
        public void Should_Divide_Right_Real_Case1()
        {
            var num1 = new RealNumber("10.110");
            var num2 = new RealNumber("99990");
            Assert.AreEqual((num1 / num2).ToString(), "0.000101110111011");
        }

        [Test]
        public void Should_Divide_Right_Real_Case2()
        {
            var num1 = new RealNumber("1111.11111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual((num1 / num2).ToString(), "0.111111111011111");
        }

        [Test]
        public void Should_Divide_Right_Real_Case3()
        {
            var num1 = new RealNumber("0.11111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual((num1 / num2).ToString(), "0.000011111000001");
        }

        [Test]
        public void Should_Divide_Right_Real_Case4()
        {
            var num1 = new RealNumber("0.00111111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual((num1 / num2).ToString(), "0.0000001111110000");
        }

        [Test]
        public void Should_Divide_Right_Real_Case5()
        {
            var num1 = new RealNumber("0.00111111");
            var num2 = new RealNumber("9999");
            Assert.AreEqual((num1 / num2).ToString(), "0.000000111122112");
        }

        [Test]
        public void Should_Divide_Right_Real_Case6()
        {
            var num1 = new RealNumber("9999");
            var num2 = new RealNumber("0.00111111");
            Assert.AreEqual((num1 / num2).ToString(), "8999108.999108999108999");
        }

        [Test]
        public void Should_Divide_Right_Real_Case7()
        {
            var num1 = new RealNumber("0.01");
            var num2 = new RealNumber("0.00111111");
            Assert.AreEqual((num1 / num2).ToString(), "9.00000900000900000");
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Should_Should_Throw_Exception_When_Divide_By_Zero()
        {
            var num = new RealNumber("9");
            var denom = new RealNumber("0");
            (num/denom).ToString();
        }
        #endregion

        #region division method with precision test

        [Test]
        public void Should_Divide_Right_BigInteger_Case_With_Precision()
        {
            var num1 = new RealNumber("1");
            var num2 = new RealNumber("99999");
            Assert.AreEqual(RealNumber.Division(num1, num2, 50).ToString(), "0.000010000100001000010000100001000010000100001000010000");
        }

        [Test]
        public void Should_Divide_Right_Real_Case_With_Precision()
        {
            var num1 = new RealNumber("1.10");
            var num2 = new RealNumber("99999");
            var pp = (num1 / num2).ToString();
            Assert.AreEqual(RealNumber.Division(num1, num2, 50).ToString(), "0.00001100011000110001100011000110001100011000110001");
        }

        [Test]
        public void Should_Divide_Right_Real_Case1_With_Precision()
        {
            var num1 = new RealNumber("10.110");
            var num2 = new RealNumber("99990");
            Assert.AreEqual(RealNumber.Division(num1, num2, 50).ToString(), "0.00010111011101110111011101110111011101110111011101");
        }

        [Test]
        public void Should_Divide_Right_Real_Case2_With_Precision()
        {
            var num1 = new RealNumber("1111.11111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual(RealNumber.Division(num1, num2, 50).ToString(), "0.11111111101111111110111111111011111111101111111110");
        }

        [Test]
        public void Should_Divide_Right_Real_Case3_With_Precision()
        {
            var num1 = new RealNumber("0.11111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual(RealNumber.Division(num1, num2, 50).ToString(), "0.000011111000001111100000111110000011111000001111100000");
        }

        [Test]
        public void Should_Divide_Right_Real_Case4_With_Precision()
        {
            var num1 = new RealNumber("0.00111111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual(RealNumber.Division(num1, num2, 50).ToString(), "0.00000011111100001111110000111111000011111100001111");
        }

        [Test]
        public void Should_Divide_Right_Real_Case5_With_Precision()
        {
            var num1 = new RealNumber("0.00111111");
            var num2 = new RealNumber("9999");
            Assert.AreEqual(RealNumber.Division(num1, num2, 50).ToString(), "0.00000011112211221122112211221122112211221122112211");
        }

        [Test]
        public void Should_Divide_Right_Real_Case6_With_Precision()
        {
            var num1 = new RealNumber("9999");
            var num2 = new RealNumber("0.00111111");
            Assert.AreEqual(RealNumber.Division(num1, num2, 50).ToString(), "8999108.99910899910899910899910899910899910899910899910899");
        }

        [Test]
        public void Should_Divide_Right_Real_Case7_With_Precision()
        {
            var num1 = new RealNumber("0.01");
            var num2 = new RealNumber("0.00111111");
            Assert.AreEqual(RealNumber.Division(num1, num2, 50).ToString(), "9.00000900000900000900000900000900000900000900000900000");
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Should_Should_Throw_Exception_When_Divide_By_Zero_With_Precision()
        {
            var num = new RealNumber("9");
            var denom = new RealNumber("0");
            RealNumber.Division(num, denom, 50).ToString();
        }
        #endregion

        #region periodicDivision method with precision test

        [Test]
        public void Should_PeriodicDivide_Right_BigInteger_Case_With_Precision()
        {
            var num1 = new RealNumber("1");
            var num2 = new RealNumber("99999");
            Assert.AreEqual(RealNumber.PeriodicDivision(num1, num2, 50).ToString(), "0.00001");
        }

        [Test]
        public void Should_PeriodicDivide_Right_Real_Case_With_Precision()
        {
            var num1 = new RealNumber("1.10");
            var num2 = new RealNumber("99999");
            var pp = (num1 / num2).ToString();
            Assert.AreEqual(RealNumber.PeriodicDivision(num1, num2, 50).ToString(), "0.0000110001");
        }

        [Test]
        public void Should_PeriodicDivide_Right_Real_Case1_With_Precision()
        {
            var num1 = new RealNumber("10.110");
            var num2 = new RealNumber("99990");
            Assert.AreEqual(RealNumber.PeriodicDivision(num1, num2, 50).ToString(), "0.00010111");
        }

        [Test]
        public void Should_PeriodicDivide_Right_Real_Case2_With_Precision()
        {
            var num1 = new RealNumber("1111.11111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual(RealNumber.PeriodicDivision(num1, num2, 50).ToString(), "0.11111111101");
        }

        [Test]
        public void Should_PeriodicDivide_Right_Real_Case3_With_Precision()
        {
            var num1 = new RealNumber("0.11111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual(RealNumber.PeriodicDivision(num1, num2, 50).ToString(), "0.000011111000001");
        }

        [Test]
        public void Should_PeriodicDivide_Right_Real_Case4_With_Precision()
        {
            var num1 = new RealNumber("0.00111111");
            var num2 = new RealNumber("9999.999999");
            Assert.AreEqual(RealNumber.PeriodicDivision(num1, num2, 50).ToString(), "0.00000011111100001");
        }

        [Test]
        public void Should_PeriodicDivide_Right_Real_Case5_With_Precision()
        {
            var num1 = new RealNumber("0.00111111");
            var num2 = new RealNumber("9999");
            Assert.AreEqual(RealNumber.PeriodicDivision(num1, num2, 50).ToString(), "0.000000111122");
        }

        [Test]
        public void Should_PeriodicDivide_Right_Real_Case6_With_Precision()
        {
            var num1 = new RealNumber("9999");
            var num2 = new RealNumber("0.00111111");
            Assert.AreEqual(RealNumber.PeriodicDivision(num1, num2, 50).ToString(), "8999108.999108");
        }

        [Test]
        public void Should_PeriodicDivide_Right_Real_Case7_With_Precision()
        {
            var num1 = new RealNumber("0.01");
            var num2 = new RealNumber("0.00111111");
            Assert.AreEqual(RealNumber.PeriodicDivision(num1, num2, 50).ToString(), "9.000009");
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Should_PeriodicDivide_Throw_Exception_When_Divide_By_Zero_With_Precision()
        {
            var num = new RealNumber("9");
            var denom = new RealNumber("0");
            RealNumber.PeriodicDivision(num, denom, 50).ToString();
        }
        #endregion
    }
}
