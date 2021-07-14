using System;
using System.Text;

namespace _05.LongestPalindromicSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            var test1 = "babad"; // bab
            var test2 = "ac"; // a
            var test3 = "a"; // a
            var test4 = "bb"; // bb
            var test5 = "ccc"; // ccc
            var test6 = "abcdeedcba"; // abcdeedcba

            var result1 = LongestPalindrome(test1);
            Console.WriteLine(result1);

            var result1Optimized = LongestPalindromeOptimized(test1);
            Console.WriteLine(result1Optimized);

            var result2 = LongestPalindrome(test2);
            Console.WriteLine(result2);

            var result3 = LongestPalindrome(test3);
            Console.WriteLine(result3);

            var result4 = LongestPalindrome(test4);
            Console.WriteLine(result4);

            var result5 = LongestPalindrome(test5);
            Console.WriteLine(result5);

            var result6 = LongestPalindrome(test6);
            Console.WriteLine(result6);

            var timeLimitTest = "kztakrekvefgchersuoiuatzlmwynzjhdqqftjcqmntoyckqfawikkdrnfgbwtdpbkymvwoumurjdzygyzsbmwzpcxcdmmpwzmeibligwiiqbecxwyxigikoewwrczkanwwqukszsbjukzumzladrvjefpegyicsgctdvldetuegxwihdtitqrdmygdrsweahfrepdcudvyvrggbkthztxwicyzazjyeztytwiyybqdsczozvtegodacdokczfmwqfmyuixbeeqluqcqwxpyrkpfcdosttzooykpvdykfxulttvvwnzftndvhsvpgrgdzsvfxdtzztdiswgwxzvbpsjlizlfrlgvlnwbjwbujafjaedivvgnbgwcdbzbdbprqrflfhahsvlcekeyqueyxjfetkxpapbeejoxwxlgepmxzowldsmqllpzeymakcshfzkvyykwljeltutdmrhxcbzizihzinywggzjctzasvefcxmhnusdvlderconvaisaetcdldeveeemhugipfzbhrwidcjpfrumshbdofchpgcsbkvaexfmenpsuodatxjavoszcitjewflejjmsuvyuyrkumednsfkbgvbqxfphfqeqozcnabmtedffvzwbgbzbfydiyaevoqtfmzxaujdydtjftapkpdhnbmrylcibzuqqynvnsihmyxdcrfftkuoymzoxpnashaderlosnkxbhamkkxfhwjsyehkmblhppbyspmcwuoguptliashefdklokjpggfiixozsrlwmeksmzdcvipgkwxwynzsvxnqtchgwwadqybkguscfyrbyxudzrxacoplmcqcsmkraimfwbauvytkxdnglwfuvehpxd";
            var timeLimitResult = LongestPalindrome(timeLimitTest);
            Console.WriteLine(timeLimitResult);
        }

        public static string LongestPalindrome(string str)
        {
            var result = string.Empty;

            if (str.Length == 1 || (str.Length == 2 && str[0] != str[1]))
                return result = str[0].ToString();

            // All subStrings of length 1 are palindromes
            int maxLength = 1, start = 0;

            // Nested loop to mark start and end index
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i; j < str.Length; j++)
                {
                    int flag = 1;

                    // Check palindrome
                    for (int k = 0; k < (j - i + 1) / 2; k++)
                    {
                        if (str[i + k] != str[j - k])
                        {
                            flag = 0;
                            break;
                        }
                    }

                    if (flag != 0 && (j-i + 1) > maxLength)
                    {
                        start = i;
                        maxLength = j - i + 1;
                    }
                }
            }

            for (int l = start; l <= start + maxLength - 1; l++)
            {
                result += str[l];
            }
            
            return result;
        }

        public static string LongestPalindromeOptimized(string s)
        {
            int maxLength = 0, startIndex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int start = i, end = i;
                while (end < s.Length - 1 && s[start] == s[end + 1])
                    end++;

                while (end < s.Length - 1 && start > 0 && s[start - 1] == s[end + 1])
                {
                    start--;
                    end++;
                }
                if (maxLength < end - start + 1)
                {
                    maxLength = end - start + 1;
                    startIndex = start;
                }
            }
            return s.Substring(startIndex, maxLength);
        }
    }
}
