using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021
{
    public static class Day9
    {
        public static void Part1()
        {
            var lines = System.IO.File.ReadLines(@"input/day9.txt");
            int width = lines.First().Length;
            int height = lines.Count();
            int[,] map = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                var line = lines.ElementAt(i).ToCharArray();
                for (int k = 0; k < width; k++)
                {
                    map[i, k] = (int)Char.GetNumericValue(line[k]);
                }
            }

            int result = 0;
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++)
                {
                    bool isLowest = true;
                    if (k > 0)
                    {
                        if (map[i, k - 1] <= map[i, k]) isLowest = false;
                    }

                    if (k + 1 < width)
                    {
                        if (map[i, k + 1] <= map[i, k]) isLowest = false;
                    }

                    if (i > 0)
                    {
                        if (map[i - 1, k] <= map[i, k]) isLowest = false;
                    }

                    if (i + 1 < height)
                    {
                        if (map[i + 1, k] <= map[i, k]) isLowest = false;
                    }

                    if (isLowest)
                    {
                        result += map[i, k] + 1;
                    }

                }
            }
            Console.WriteLine("Day 9, Part 1 result: " + result.ToString());
        }

        public static void Part2()
        {
            var lines = System.IO.File.ReadLines(@"input/day9.txt");
            int width = lines.First().Length;
            int height = lines.Count();
            int[,] map = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                var line = lines.ElementAt(i).ToCharArray();
                for (int k = 0; k < width; k++)
                {
                    map[i, k] = (int)Char.GetNumericValue(line[k]);
                }
            }

            int result = 0;
            int[] basins = new int[3];
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++)
                {
                    bool isLowest = true;
                    if (k > 0)
                    {
                        if (map[i, k - 1] <= map[i, k]) isLowest = false;
                    }

                    if (k + 1 < width)
                    {
                        if (map[i, k + 1] <= map[i, k]) isLowest = false;
                    }

                    if (i > 0)
                    {
                        if (map[i - 1, k] <= map[i, k]) isLowest = false;
                    }

                    if (i + 1 < height)
                    {
                        if (map[i + 1, k] <= map[i, k]) isLowest = false;
                    }

                    if (isLowest)
                    {
                        result += map[i, k] + 1;
                        int currentElementBasins = CalculateBasins(map, i, k, height, width);
                        for (int b =0; b < basins.Length; b++)
                        {
                            if (basins[b] < currentElementBasins)
                            {
                                basins[b] = currentElementBasins;
                                break;
                            }
                        }
                    }

                }
            }
            Console.WriteLine("Day 9, Part 2 result: " + basins.Aggregate(1, (a, b) => a * b));
        }

        private static int CalculateBasins(int[,] map, int i, int k, int height, int width)
        {
            int initialK = k, initialI = i;
            int basinsCount = 0;

            if (k > 0 && map[i, --k] < 9)
            {
                map[i, k] = 9;
                basinsCount += CalculateBasins(map, i, k, height, width) + 1;
            }

            k = initialK;

            if (k + 1 < width && map[i, ++k] < 9)
            {
                map[i, k] = 9;
                basinsCount += CalculateBasins(map, i, k, height, width) + 1;
            }

            k = initialK;

            if (i > 0 && map[--i, k] < 9)
            {
                map[i, k] = 9;
                basinsCount += CalculateBasins(map, i, k, height, width) + 1;
            }

            i = initialI;
            if (i + 1 < height && map[++i, k] < 9)
            {
                map[i, k] = 9;
                basinsCount += CalculateBasins(map, i, k, height, width) + 1;
            }

            return basinsCount;
        }
    }
}
