using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021
{
    public static class Day1
    {
        public static void Part1()
        {
            int prev = int.MaxValue;
            int result = 0;
            foreach (string line in System.IO.File.ReadLines(@"input/data.txt"))
            {
                int current = Convert.ToInt32(line);
                if (current > prev)
                    result++;
                prev = current;
            }
            Console.WriteLine("Day 1, Part 1 result: " + result.ToString());
        }

        public static void Part2()
        {
            int prev = int.MaxValue;
            int result = 0;
            Queue<int> currentThree = new Queue<int>();
            foreach (string line in System.IO.File.ReadLines(@"input/data.txt"))
            {
                int current = Convert.ToInt32(line);
                currentThree.Enqueue(current);

                if (currentThree.Count == 3)
                {
                    int currentSum = currentThree.Sum();
                    if (currentSum > prev) result++;
                    prev = currentSum;
                    currentThree.Dequeue();
                }
            }
            Console.WriteLine("Day 1, Part 2 result: " + result.ToString());
        }
    }
}
