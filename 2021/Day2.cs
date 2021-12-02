using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2021
{
    public static class Day2
    {
        public static void Part1()
        {
            int x = 0;
            int y = 0;
            foreach (string line in System.IO.File.ReadLines(@"input/day2.txt"))
            {
                string [] lineParts = line.Split(' ');
                string direction = lineParts[0];
                int value = Convert.ToInt32(lineParts[1]);
                switch (direction)
                {
                    case "forward":
                        x += value;
                        break;
                    case "down":
                        y += value;
                        break;
                    case "up":
                        y -= value;
                        break;
                }
            }
            Console.WriteLine("Day 2, Part 1 result: " + x * y);
        }

        public static void Part2()
        {
            int x = 0;
            int y = 0;
            int aim = 0;
            foreach (string line in System.IO.File.ReadLines(@"input/day2.txt"))
            {
                string[] lineParts = line.Split(' ');
                string direction = lineParts[0];
                int value = Convert.ToInt32(lineParts[1]);
                switch (direction)
                {
                    case "forward":
                        x += value;
                        y += aim * value;
                        break;
                    case "down":
                        aim += value;
                        break;
                    case "up":
                        aim -= value;
                        break;
                }
            }
            Console.WriteLine("Day 2, Part 2 result: " + x * y);
        }
    }
}
