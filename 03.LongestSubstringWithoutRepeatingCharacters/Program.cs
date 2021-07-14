using System;
using System.Collections.Generic;

namespace _03.LongestSubstringWithoutRepeatingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            var testString = "abcabcbb"; // 3
            var testString2 = "bbbbbb"; // 1
            var testString3 = "pwwkew"; // 3
            var testString4 = ""; // 0
            var testString5 = "au"; // 2
            var testString6 = "dvdf"; //3


            var result = LengthOfLongestSubstring(testString);
            var result2 = LengthOfLongestSubstring(testString2);
            var result3 = LengthOfLongestSubstring(testString3);
            var result4 = LengthOfLongestSubstring(testString4);
            var result5 = LengthOfLongestSubstring(testString5);
            var result6 = LengthOfLongestSubstring(testString6);
            Console.WriteLine(result);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
            Console.WriteLine(result4);
            Console.WriteLine(result5);
            Console.WriteLine(result6);
        }

        public static int LengthOfLongestSubstring(string str)
        {
            Dictionary<char, int> seen = new Dictionary<char, int>();
            int maximum_length = 0;

            // starting the inital point of window to index 0
            int start = 0;

            for (int index = 0; index < str.Length; index++)
            {
                // Checking if we have already seen the element or not
                if (seen.ContainsKey(str[index]))
                {
                    // If we have seen the number, move the start pointer
                    // to position after the last occurrence
                    start = Math.Max(start, seen[str[index]] + 1);
                }

                // Updating the last seen value of the character
                seen[str[index]] = index;
                maximum_length = Math.Max(maximum_length, index - start + 1);
            }
            return maximum_length;
        }
    }
}
