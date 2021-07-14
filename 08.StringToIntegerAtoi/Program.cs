using System;
using System.Linq;

namespace _08.StringToIntegerAtoi
{
    class Program
    {
        static void Main(string[] args)
        {
            var testInput1 = "42";
            var result1 = MyAtoi(testInput1);
            Console.WriteLine(result1);

            var testInput2 = "   -42";
            var result2 = MyAtoi(testInput2);
            Console.WriteLine(result2);

            var testInput3 = "4193 with words";
            var result3 = MyAtoi(testInput3);
            Console.WriteLine(result3);

            var testInput4 = "words and 987";
            var result4 = MyAtoi(testInput4);
            Console.WriteLine(result4);

            var testInput5 = "-91283472332";
            var result5 = MyAtoi(testInput5);
            Console.WriteLine(result5);

            var wrongInput = "+-12";
            var wrongResult = MyAtoi(wrongInput);
            Console.WriteLine(wrongResult);

            var wrongInput2 = "";
            var wrongResult2 = MyAtoi(wrongInput2);
            Console.WriteLine(wrongResult2);

            var wrongInput3 = "1";
            var wrongResult3 = MyAtoi(wrongInput3);
            Console.WriteLine(wrongResult3);

            var wrongInput4 = "+";
            var wrongResult4 = MyAtoi(wrongInput4);
            Console.WriteLine(wrongResult4);

            var wrongInput5 = "0000-94ad";
            var wrongResult5 = MyAtoi(wrongInput5);
            Console.WriteLine(wrongResult5);
        }

        public static int MyAtoi(string str)
        {
            int result = 0;
            int sign = 1;

            if (!string.IsNullOrEmpty(str) && str.Length > 0)
            {
                char[] chars = str.ToCharArray();

                double num = 0;

                for (int i = 0; i < chars.Length; i++)
                {
                    // whitespace
                    if (chars[i] == ' ')
                    {
                        // prev char is digit & current char is whitespace
                        // so exit loop
                        if (i > 0 && chars[i - 1] >= '0' && chars[i - 1] <= '9')
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    } // plus or minus char
                    else if (chars[i] == '-' || chars[i] == '+')
                    {
                        // continue loop if, current char is plus or minus sign
                        // and next char is digit
                        // but prev char is not a digit
                        // For example: "0-1" should yield 0, since sign
                        // after digit doesn't count as a valid char to continue conversion
                        if (i + 1 < chars.Length && IsDigit(chars[i + 1]) &&
                            !(i - 1 >= 0 && IsDigit(chars[i - 1])))
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    } // current char is a digit
                    else if (IsDigit(chars[i]))
                    {
                        // add sign
                        if (num == 0 && i >= 1 && chars[i - 1] == '-')
                        {
                            sign = -1;
                        }

                        num = num * 10 + chars[i] - '0';
                    }
                    else
                    {
                        break;
                    }
                }

                if (sign > 0 && num > Int32.MaxValue)
                {
                    result = Int32.MaxValue;
                }
                else if (sign < 0 && num < Int32.MinValue)
                {
                    result = Int32.MinValue;
                }
                else
                {
                    num = sign * num;
                    result = (int)num;
                }
            }

            return result;
        }

        public static bool IsDigit(int val)
        {
            bool isDigit = false;

            if (val >= '0' && val <= '9')
            {
                isDigit = true;
            }

            return isDigit;

        }
    }
}