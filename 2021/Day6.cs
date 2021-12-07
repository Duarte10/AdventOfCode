using System;
using System.IO;
using System.Linq;

namespace AoC2021
{
    public static class Day6
    {
        public static void Part1()
        {
            long fishCount = CalculateFishCount(80);
            Console.WriteLine("Day 6, part 1:" + fishCount);
        }

        public static void Part2()
        {
            long fishCount = CalculateFishCount(256);
            Console.WriteLine("Day 6, part 2:" + fishCount);
        }

        private static long CalculateFishCount(int days)
        {
            long[] ages = new long[9];
            var input = File.ReadAllText(@"input/day6.txt").Split(",");
            foreach (string number in input) ages[Convert.ToInt32(number)]++;
            
            for (int i = 0; i < days; i++)
            {
                long newFish = ages[0];
                for (int k = 0; k < 8; k++)
                {
                    ages[k] = ages[k + 1];
                }
                ages[8] = newFish;
                ages[6] += newFish;
            }

            return ages.Sum();
        }
    }
}
