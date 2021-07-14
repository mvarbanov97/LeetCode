using System;

namespace _07.ReverseInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            var test1 = 1534236469;
            var result1 = Reverse(test1);
            Console.WriteLine(result1);

            var test2 = -321;
            var result2 = Reverse(test2);
            Console.WriteLine(result2);

            var test3 = -2147483648;
            var result3 = Reverse(test3);
            Console.WriteLine(result3);

            var test4 = -1563847412;
            var testResult4 = Reverse(test4);
            Console.WriteLine(testResult4);
        }

        public static int Reverse(int x)
        {
            if (x <= int.MinValue)
                return 0;

            int left = x;
            int rev = 0;

            while (Convert.ToBoolean(left))
            {
                try
                {
                    // 2147483647 - int max value
                    //-2147483648 - int min value
                    
                    int r = left % 10;
                    Int64 dummyRev = rev;
                    Int64 revOverflow = Math.Abs((dummyRev * 10) + r);
                    if (revOverflow > int.MaxValue)
                        return 0;

                    rev = (rev * 10) + r;
                    left = left / 10;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            return rev;
        }
    }
}
