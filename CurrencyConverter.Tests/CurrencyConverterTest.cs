using System;
using CurrencyConverter;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyConverter.Tests;

[TestClass]
[TestSubject(typeof(Program))]
public class CurrencyConverterTest
{
    [TestMethod]
    public void TestZeroDollars()
    {
        Assert.AreEqual("Zero Dollars", Program.ConvertToWords(0));
    }

    [TestMethod]
    public void TestOneDollar()
    {
        Assert.AreEqual("One Dollar", Program.ConvertToWords(1));
    }

    [TestMethod]
    public void TestTwoDollars()
    {
        Assert.AreEqual("Two Dollars", Program.ConvertToWords(2));
    }

    [TestMethod]
    public void TestTeenDollars()
    {
        Assert.AreEqual("Fifteen Dollars", Program.ConvertToWords(15));
    }

    [TestMethod]
    public void TestTwentyDollars()
    {
        Assert.AreEqual("Twenty Dollars", Program.ConvertToWords(20));
    }

    [TestMethod]
    public void TestTwentyOneDollars()
    {
        Assert.AreEqual("Twenty-One Dollars", Program.ConvertToWords(21));
    }

    [TestMethod]
    public void TestOneHundredDollars()
    {
        Assert.AreEqual("One Hundred Dollars", Program.ConvertToWords(100));
    }

    [TestMethod]
    public void TestOneThousandDollars()
    {
        Assert.AreEqual("One Thousand Dollars", Program.ConvertToWords(1000));
    }

    [TestMethod]
    public void TestOneMillionDollars()
    {
        Assert.AreEqual("One Million Dollars", Program.ConvertToWords(1000000));
    }

    [TestMethod]
    public void TestOneBillionDollars()
    {
        Assert.AreEqual("One Billion Dollars", Program.ConvertToWords(1000000000));
    }

    [TestMethod]
    public void TestOneTrillionDollars()
    {
        Assert.AreEqual("One Trillion Dollars", Program.ConvertToWords(1000000000000));
    }

    [TestMethod]
    public void TestOneQuadrillionDollars()
    {
        Assert.AreEqual("One Quadrillion Dollars", Program.ConvertToWords(1000000000000000));
    }

    [TestMethod]
    public void TestComplexNumber()
    {
        Assert.AreEqual(
            "One Billion Two Hundred Thirty-Four Million Five Hundred Sixty-Seven Thousand Eight Hundred Ninety Dollars and Twelve Cents",
            Program.ConvertToWords(1234567890.12));
    }

    [TestMethod]
    public void TestOneCent()
    {
        Assert.AreEqual("One Cent", Program.ConvertToWords(0.01));
    }

    [TestMethod]
    public void TestTwoCents()
    {
        Assert.AreEqual("Two Cents", Program.ConvertToWords(0.02));
    }

    [TestMethod]
    public void TestTenCents()
    {
        Assert.AreEqual("Ten Cents", Program.ConvertToWords(0.10));
    }

    [TestMethod]
    public void TestElevenCents()
    {
        Assert.AreEqual("Eleven Cents", Program.ConvertToWords(0.11));
    }

    [TestMethod]
    public void TestNinetyNineCents()
    {
        Assert.AreEqual("Ninety-Nine Cents", Program.ConvertToWords(0.99));
    }

    [TestMethod]
    public void TestOneDollarOneCent()
    {
        Assert.AreEqual("One Dollar and One Cent", Program.ConvertToWords(1.01));
    }

    [TestMethod]
    public void TestThreeDecimalPlaces()
    {
        Assert.AreEqual("One Dollar and Twelve Cents", Program.ConvertToWords(1.123));
    }

    [TestMethod]
    public void TestSixDecimalPlaces()
    {
        Assert.AreEqual("One Dollar and Twelve Cents", Program.ConvertToWords(1.123456));
    }

    [TestMethod]
    public void TestRoundingToTwoDecimalPlaces()
    {
        Assert.AreEqual("One Dollar and Twelve Cents", Program.ConvertToWords(1.123));
    }

    [TestMethod]
    public void TestAllZerosInDecimal()
    {
        Assert.AreEqual("One Dollar", Program.ConvertToWords(1.000000));
    }

    [TestMethod]
    public void TestSomeZerosInDecimal()
    {
        Assert.AreEqual("One Dollar and Ten Cents", Program.ConvertToWords(1.100100));
    }

    [TestMethod]
    public void TestLargestPossibleValue()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            Program.ConvertToWords(999999999999999999.99);
        });
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestNegativeNumber()
    {
        Program.ConvertToWords(-1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestTooLargeNumber()
    {
        Program.ConvertToWords(1000000000000000000);
    }

    [TestMethod]
    public void TestVerySmallNumber()
    {
        Assert.AreEqual("Zero Dollars", Program.ConvertToWords(0.000001));
    }

    [TestMethod]
    public void TestNumberWithLeadingZeros()
    {
        Assert.AreEqual("One Dollar", Program.ConvertToWords(00001.00));
    }

    [TestMethod]
    public void TestLargeNumberWithManyZeros()
    {
        Assert.AreEqual("One Hundred Billion Dollars", Program.ConvertToWords(100000000000));
    }

    [TestMethod]
    public void TestNumberEndingWithZero()
    {
        Assert.AreEqual("Twenty Dollars", Program.ConvertToWords(20));
    }

    [TestMethod]
    public void TestLargeDecimalNumber()
    {
        Assert.AreEqual("One Dollar and Twenty-Three Cents", Program.ConvertToWords(1.2345678));
    }

    [TestMethod]
    public void TestExactlyOneDollar()
    {
        Assert.AreEqual("One Dollar", Program.ConvertToWords(1.00));
    }

    [TestMethod]
    public void TestExactlyTwoDollars()
    {
        Assert.AreEqual("Two Dollars", Program.ConvertToWords(2.00));
    }
}