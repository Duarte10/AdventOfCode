using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2021
{
    public static class Day5
    {
        public static void MarkPoint(Dictionary<string, int> positions, int x, int y)
        {
            string key = x.ToString() + "_" + y.ToString();
            int value;
            bool exists = positions.TryGetValue(key, out value);
            if (exists)
            {
                positions[key] = ++value;
            } else
            {
                positions[key] = 1;
            }
        }
        public static void Part1()
        {
            CalculateLines(false);
        }

        public static void Part2()
        {
            CalculateLines(true);
        }

        public static void CalculateLines(bool enableDiagonals)
        {
            var lines = System.IO.File.ReadLines(@"input/day5.txt");
            Dictionary<string, int> positions = new Dictionary<string, int>();
            foreach(var line in lines)
            {
                string[] parts = line.Split("->");
                string[] point1 = parts[0].Trim().Split(",");
                string[] point2 = parts[1].Trim().Split(",");
                int x1 = Convert.ToInt32(point1[0]);
                int y1 = Convert.ToInt32(point1[1]);
                int x2 = Convert.ToInt32(point2[0]);
                int y2 = Convert.ToInt32(point2[1]);

                int direction;
                
                if (x1 == x2)
                {
                    direction = y1 > y2 ? -1 : 1;

                    for(int i = y1; ; i+= direction)
                    {
                        MarkPoint(positions, x1, i);
                        if (i == y2)
                            break;
                    }
                    continue;
                }

                if (y1 == y2)
                {
                    direction = x1 > x2 ? -1 : 1;

                    for (int i = x1; ; i += direction)
                    {
                        MarkPoint(positions, i, y1);
                        if (i == x2)
                            break;
                    }
                    continue;
                }

                if(!enableDiagonals)
                {
                    continue;
                }
                

                decimal a = (decimal)(y2 - y1) / (x2 - x1);

                if (a != 1 && a != -1)
                {
                    continue;
                }
                decimal b = y1 - (a * x1);
                direction = x1 > x2 ? -1 : 1;

                for (int i = x1; ; i += direction)
                {
                    int y = (int)(a * i + b);
                    MarkPoint(positions, i, y);
                    if (i == x2)
                        break;
                }
            }

            Console.WriteLine(positions.Count(p => p.Value > 1).ToString());
        }
    }
}
