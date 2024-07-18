using System.Numerics;
using System.Text;

namespace CurrencyConverter;

internal class Program
{
    private static readonly string[] ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
    private static readonly string[] teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
    private static readonly string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
    private static readonly string[] scales = { "", "Thousand", "Million", "Billion", "Trillion", "Quadrillion" };

    private static BigInteger[] SplitDecimal(double amount)
    {
        BigInteger integerPart = (BigInteger)Math.Floor(amount);
        BigInteger decimalPart = (BigInteger)Math.Round((amount - (double)integerPart) * 100);

        return new[]
        {
            integerPart,
            decimalPart
        };
    }
    
    public static string ConvertToWords(double amount)
    {
        if (amount < 0 || amount >= 1000000000000000000d)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be between 0 and 999,999,999,999,999,999.999999");
        }

        BigInteger[] numberParts = SplitDecimal(amount);

        StringBuilder result = new StringBuilder();

        if (numberParts[0] > 0)
        {
            result.Append(ConvertNumberToWords(numberParts[0]));
            result.Append(numberParts[0] > 1 ? " Dollars" : " Dollar");
        }

        if (numberParts[1] > 0)
        {
            if (numberParts[0] > 0)
            {
                result.Append(" and ");
            }
            result.Append(ConvertFractionalPartToWords(numberParts[1]));
        }

        if (result.Length == 0)
        {
            result.Append("Zero Dollars");
        }

        return result.ToString();
    }

    // Technique 1: To use BigInteger and numerical manipulation
    private static string ConvertNumberToWords(BigInteger number)
    {
        if (number == 0)
            return "";

        if (number < 10)
            return ones[(int)number];

        if (number < 20)
            return teens[(int)number - 10];

        if (number < 100)
        {
            return tens[(int)number / 10] + ((number % 10 != 0) ? ("-" + ones[(int)(number % 10)]) : "");
        }

        if (number < 1000)
        {
            return ones[(int)(number / 100)] + " Hundred" + (number % 100 != 0 ? " " + ConvertNumberToWords(number % 100) : "");
        }

        for (int i = scales.Length - 1; i > 0; i--)
        {
            if (number >= BigInteger.Pow(1000, i))
            {
                return ConvertNumberToWords(number / BigInteger.Pow(1000, i)) + " " + scales[i] + 
                       (number % BigInteger.Pow(1000, i) != 0 ? " " + ConvertNumberToWords(number % BigInteger.Pow(1000, i)) : "");
            }
        }

        return "";
    }

    // Technique 2: To directly use string manipulation
    private static string ConvertFractionalPartToWords(BigInteger number)
    {
        string result = "";

        if (number >= 20 && number < 100)
            result = tens[(int)number / 10] + ((number % 10 != 0) ? ("-" + ones[(int)(number % 10)]) : "");
        else if (number >= 10 && number < 20)
            result = teens[(int)number - 10];
        else if (number < 10)
            result = ones[(int)number];

        return result + (number > 1 ? " Cents" : " Cent");
    }

    static void Main(string[] args)
    {
        string line = "";
        while (true)
        {
            Console.WriteLine("Enter a numeric value (e.g.: 12.345678) or 'quit' to exit:");
            line = Console.ReadLine();
            
            if (line == "quit") break;

            if (double.TryParse(line, out double numericValue))
            {
                string conversionResult = ConvertToWords(numericValue);
                Console.WriteLine($" > \"{conversionResult}\"");
            }
            else
            {
                Console.WriteLine("Invalid number was entered. Please try again. \n");
            }
        }
        
        Console.WriteLine("Quiting...");
    }
}