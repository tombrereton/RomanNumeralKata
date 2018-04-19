using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;

namespace RomanNumeralsKata
{
    //Katas
    //Roman Numbers
    //Definition
    //Given a positive integer number(eg 42) determine its Roman numeral representation as a String(eg "XLII"). You cannot write numerals like IM for 999. 
    //Examples
    //Arabic number Roman numeral Arabic number Roman numeral
    //1   I   60  LX
    //2   II  70  LXX
    //3   III 80  LXXX
    //4   IV  90  XC
    //5   V   100 C
    //6   VI  200 CC
    //7   VII 300 CCC
    //8   VIII    400 CD
    //9   IX  500 D
    //10  X   600 DC
    //20  XX  700 DCC
    //30  XXX 800 DCCC
    //40  XL  900 CM
    //50  L   1000    M
    [TestFixture]
    public class RomanNumeralConverterTests
    {
        [Test]
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        public void GivenWeReceiveAnArabicNumber_ThenWeReturnCorrectRomanNumeral(int input, string expected)
        {
            var result = RomanNumeralConverter.ConvertArabicToRomanNumeral(input);

            Assert.That(result, Is.EqualTo(expected));
        }
    }

    public class RomanNumeralConverter
    {
        public static string ConvertArabicToRomanNumeral(int input)
        {
            IDictionary<int, string> romanNumerals = new Dictionary<int, string>()
            {
                {1, "I"},
                {4, "IV"},
                {5, "V"},
                {6, "VI"},
                {7, "VII"},
                {8, "VIII"}
            };

            if (input > 5)
            {
                return "V" + ConvertArabicToRomanNumeral(input - 5);
            }

            if (romanNumerals.ContainsKey(input))
            {
                return romanNumerals[input];
            }

            return "I" + ConvertArabicToRomanNumeral(input - 1);
        }
    }
}