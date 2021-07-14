using System;
using System.Linq;

namespace _04.MedianOfTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // [1,3]
            // [2]
            // 
            // [1,2]
            // [3,4]
            // 
            // [0,0]
            // [0,0]
            // 
            // []
            // [1]
            // 
            // [2]
            // []
            //
            // []
            // [1,2,3,4,5]

            int[] firstNums = { };
            int[] secondNums = { 1, 2, 3, 4, 5 };

            var median = FindMedianSortedArrays(firstNums, secondNums);
            Console.WriteLine(median);
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] combined = new int[nums1.Length + nums2.Length];
            if (nums1.Length == 0)
            {
                combined = nums2.Concat(nums1).OrderBy(x => x).ToArray();
            }
            else
            {
                combined = nums1.Concat(nums2).OrderBy(x => x).ToArray();
            }

            double result = 0;


            if (combined.Length % 2 == 0)
            {
                var firstIndex = combined.Length / 2 - 1;
                var secondIndex = combined.Length / 2;
                result = (double)(combined[firstIndex] + combined[secondIndex]) / 2;
            }
            else if (combined.Length % 3 > 0 || combined.Length == 3 || combined.Length % 3 == 0)
            {
                var index = Math.Floor((decimal)combined.Length / 2);
                result = combined[(int)index];
            }
            else
            {
                result = combined.First();
            }

            return result;
        }
    }
}
