using System;

namespace Kata.StringCalculator.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Should_Calculate_EmptyString_ReturnsZero()
        {
            //Arrange

            //Act
            int result = StringCalculator.Calculate("");

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Should_Calculate_SingleNumber_ReturnsNumber()
        {
            //Arrange

            //Act
            int result = StringCalculator.Calculate("2");

            //Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Should_Calculate_TwoNumbersCommaDelimited_ReturnsSum()
        {
            //Arrange

            //Act
            int result = StringCalculator.Calculate("2,3");

            //Assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Should_Calculate_TwoNumbersNewLineDelimited_ReturnsSum()
        {
            //Arrange

            //Act
            int result = StringCalculator.Calculate("2\n3");

            //Assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Should_Calculate_ThreeNumbersEitherDelimited_ReturnsSum()
        {
            //Arrange

            //Act
            int result = StringCalculator.Calculate("2\n3,4");

            //Assert
            Assert.AreEqual(9, result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Calculate_NegativeNumbers_ThrowsException()
        {
            //Arrange

            //Act
            int result = StringCalculator.Calculate("-2\n3,4");

            //Assert
        }

        [Test]
        public void Should_Calculate_NumbersGreaterThan1000_AreIgnored()
        {
            //Arrange

            //Act
            int result = StringCalculator.Calculate("2\n1001,4");

            //Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Should_Calculate_WithSingleLineDelimiter_ReturnsSum()
        {
            //Arrange

            //Act
            int result = StringCalculator.Calculate("//#2#3#4");

            //Assert
            Assert.AreEqual(9, result);
        }

        [Test]
        public void Should_Calculate_WithMultiCharDelimiter_ReturnsSum()
        {
            //Arrange

            //Act
            int result = StringCalculator.Calculate("//[###]2###3###4");

            //Assert
            Assert.AreEqual(9, result);
        }

        [Test]
        public void Should_Calculate_WithManySingleOrMultiCharDelimiter_ReturnsSum()
        {
            //Arrange

            //Act
            int result = StringCalculator.Calculate("//[$][,]2$3,4,5");

            //Assert
            Assert.AreEqual(14, result);
        }  
    }
}
