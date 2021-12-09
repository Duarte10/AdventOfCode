using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2021
{
    public class Digit
    {
        public int Value { get; set; }
        public int[] RequiredSegments { get; set; }
    }
    public class SegmentLetter
    {
        public char Letter { get; set; }
        public List<int> PossiblePositions { get; set; }
        public bool Found { get; set; }
        public int FinalPosition { get; set; }
    }
    public class SegmentNumber
    {
        public int Number { get; set; }
        public int SegmentCount { get; set; }
        public int OccurrenceCount { get; set; }
        public List<int> PossiblePositions { get; set; }
    }
    public static class Day8
    {

        public static void Part1()
        {
            List<SegmentNumber> recurrentNumbers = new List<SegmentNumber>();
            recurrentNumbers.Add(new SegmentNumber() { Number = 1, SegmentCount = 2, OccurrenceCount = 0 });
            recurrentNumbers.Add(new SegmentNumber() { Number = 4, SegmentCount = 4, OccurrenceCount = 0 });
            recurrentNumbers.Add(new SegmentNumber() { Number = 7, SegmentCount = 3, OccurrenceCount = 0 });
            recurrentNumbers.Add(new SegmentNumber() { Number = 8, SegmentCount = 7, OccurrenceCount = 0 });


            var lines = System.IO.File.ReadLines(@"input/day8.txt");

            foreach (var line in lines)
            {
                string output = line.Split("|")[1].Trim();

                foreach (var sequence in output.Split(" "))
                {
                    var recurrentNumber = recurrentNumbers.FirstOrDefault(r => r.SegmentCount == sequence.Length);
                    if (recurrentNumber != null)
                    {
                        recurrentNumber.OccurrenceCount++;
                    }
                }
            }

            Console.WriteLine("Day 8, Part 1:" + recurrentNumbers.Sum(s => s.OccurrenceCount).ToString());
        }

        public static void Part2()
        {
        }
    }
}
