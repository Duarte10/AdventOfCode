using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2021
{
    public static class Day3
    {
        public static void Part1()
        {
            int length = System.IO.File.ReadLines(@"input/day3.txt").First().Length;
            int[] values = new int[length];
            foreach (string line in System.IO.File.ReadLines(@"input/day3.txt"))
            {
                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];
                    if (c == '0') values[i]--;
                    else values[i]++;
                }
            }

            string gamma = string.Concat(values.Select(s => s > 0 ? '1' : '0'));
            string epsilon = string.Concat(values.Select(s => s > 0 ? '0' : '1'));
            int result = Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
            Console.WriteLine("Day 3, Part 1: " + result);
        }

        public static void Part2()
        {
            List<string> lines = System.IO.File.ReadLines(@"input/day3.txt").ToList();
            string oxygenRating = GetValue(lines, "most_common");
            string co2Rating = GetValue(lines, "least_common");
            int result = Convert.ToInt32(oxygenRating, 2) * Convert.ToInt32(co2Rating, 2);
            Console.WriteLine("Day 3, Part 2: " + result);
        }

        private static string GetValue(List<string> lines, string criteria)
        {
            int[] values = new int[lines.First().Length];
            for (int i = 0; i < values.Length; i++)
            {
                foreach (var line in lines)
                {
                    char c = line[i];
                    if (c == '0') values[i]--;
                    else values[i]++;
                }

                if (values[i] >= 0)
                {
                    char compareBit = criteria == "most_common" ? '1' : '0';
                    lines = lines.Where(l => l[i] == compareBit).ToList();
                }
                else
                {
                    // keep only 0's
                    char compareBit = criteria == "most_common" ? '0' : '1';
                    lines = lines.Where(l => l[i] == compareBit).ToList();
                }

                if (lines.Count == 1) return lines.First();
            }

            if (lines.Count == 1) return lines.First();
            throw new Exception("Line not found");
        }

    }
}
