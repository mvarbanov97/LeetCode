using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testNums = { 3, 2, 4 };
            int target = 6;

            var result = TwoSum(testNums, target);
            Console.WriteLine($"{result[0]} {result[1]}");
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            Dictionary<int, int> id = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (id.ContainsValue(target - nums[i]))
                {
                    result[1] = i;
                    foreach (var key in id.Keys)
                    {
                        if (id[key] == target - nums[i])
                            result[0] = key;
                    }

                }
                id[i] = nums[i];
            }
            return result;
        }
    }
}
