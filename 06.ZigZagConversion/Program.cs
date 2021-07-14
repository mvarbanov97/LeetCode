using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _06.ZigZagConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            var test1String = "PAYPALISHIRING";
            var test1Rows = 3;

            var result1 = Convert(test1String, test1Rows);
            Console.WriteLine(result1);
        }

        public static string Convert(string s, int numRows)
        {
            if (numRows == 1)
                return s;

            var result = new StringBuilder();

            List<StringBuilder> rows = new List<StringBuilder>();

            for (int i = 0; i < Math.Min(numRows, s.Length); i++)
                rows.Add(new StringBuilder());

            int currRow = 0;
            bool goingDown = false;

            for (int i = 0; i < s.Length; i++)
            {
                rows[currRow].Append(s[i]);
                if (currRow == 0 || currRow == numRows - 1) 
                    goingDown = !goingDown;

                currRow += goingDown ? 1 : -1;
            }

            foreach (var row in rows)
            {
                result.Append(row);
            }

            return result.ToString();
        }
    }
}
