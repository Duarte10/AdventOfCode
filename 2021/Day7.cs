using System;
using System.Linq;

namespace AoC2021
{
    public static class Day7
    {
        public static void Part1()
        {
            int result = CalculateFuel(false); ;
            Console.WriteLine("Day 7, Part 1:" + result.ToString());
        }

        public static void Part2()
        {
            int result = CalculateFuel(true); ;
            Console.WriteLine("Day 7, Part 2:" + result.ToString());
        }

        private static int CalculateFuel(int[] numbers, int positionIndex, bool incrementingFuel)
        {
            int target = numbers[positionIndex];
            int fuel = 0;
            foreach(int number in numbers)
            {
                int steps = Math.Abs(number - target);
                if (!incrementingFuel)
                {
                    fuel += steps;
                }
                else
                {
                    for (int i = 0; i <= steps; i++)
                    {
                        fuel += i;
                    }
                }
            }
            return fuel;
        }
        public static int CalculateFuel(bool incrementingFuel)
        { 
            var text = System.IO.File.ReadAllText(@"input/day7.txt");
            int[] numbers = text.Split(",").Select(s => Convert.ToInt32(s)).ToArray();

            int median = numbers[numbers.Length / 2];

            int prevValueUp = int.MaxValue;
            int prevValueDown = int.MaxValue;

            bool resultFound = false;
            bool goingUpRight = false;
            bool goingUpLeft = false;

            int currentXUp = median;
            int currentXDown = median;

            int bestResult = int.MaxValue;

            while(!resultFound)
            {
                int currentResult = CalculateFuel(numbers, currentXUp, incrementingFuel);
                if (currentResult < bestResult) {
                    bestResult = currentResult;
                }

                if (currentResult > prevValueUp)
                {
                    goingUpRight = true;
                }

                currentResult = CalculateFuel(numbers, currentXDown, incrementingFuel);

                if (currentResult > prevValueDown)
                {
                    goingUpLeft = true;
                }

                if ((goingUpRight && goingUpLeft) || (currentXDown == 0 && currentXUp == (numbers.Length - 1)))
                {
                    return bestResult;
                }

                if (currentXUp < numbers.Length - 1)
                {
                    currentXUp++;
                }

                if (currentXDown > 0)
                {
                    currentXDown--;
                }
            }

            return -1;
        }
    }
}
