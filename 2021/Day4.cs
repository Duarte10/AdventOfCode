using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2021
{
    public class Board
    {
        public Board()
        {
            this.Values = new int[5,5];
        }
        public int[,] Values { get; set; }
        public bool IsComplete { get; set; }
    }
    public static class Day4
    {
        private static List<Board> ReadBoards(IEnumerable<string> lines)
        {
            List<Board> boards = new List<Board>();
            boards.Add(new Board());
            var currentBoard = boards.First();
            int boardLineNumber = 0;
            foreach (string line in lines.Skip(2))
            {
                if (line == string.Empty)
                {
                    currentBoard = new Board();
                    boards.Add(currentBoard);
                    boardLineNumber = 0;
                    continue;
                }

                int boardColumn = 0;
                foreach (string s in line.Split(' '))
                {
                    if (string.IsNullOrWhiteSpace(s)) continue;
                    currentBoard.Values[boardLineNumber, boardColumn] = Convert.ToInt32(s);
                    boardColumn++;
                }

                boardLineNumber++;
            }

            return boards;
        }

        private static int CalculateResult(Board winningBoard, int drawnNumber)
        {
            int sum = 0;
            for (int i = 0; i < winningBoard.Values.GetLength(0); i++)
            {
                for (int k = 0; k < winningBoard.Values.GetLength(1); k++)
                {
                    if (winningBoard.Values[i, k] != -1)
                    {
                        sum += winningBoard.Values[i, k];
                    }
                }
            }

            return sum * drawnNumber;
        }

        public static void Part1()
        {
            var lines = System.IO.File.ReadLines(@"input/day4.txt");
            var drawnNumbers = lines.First().Split(",").Select(s => Convert.ToInt32(s)).ToArray();

            var boards = ReadBoards(lines);

            //int result = ;
            foreach(var number in drawnNumbers)
            {
                foreach(var board in boards)
                {
                    for (int i = 0; i < board.Values.GetLength(0); i++)
                    {
                        bool rowComplete = true;
                        for (int k = 0; k < board.Values.GetLength(1); k++)
                        {
                            if (board.Values[i,k] == number)
                            {
                                board.Values[i, k] = -1;
                            }

                            if (board.Values[i, k] != -1)
                            {
                                rowComplete = false;
                            }
                        }

                        if (rowComplete)
                        {
                            // Winner found
                            Console.WriteLine(CalculateResult(board, number).ToString());
                            return;
                        }
                    }

                    // check if any column is complete
                    for (int i = 0; i < board.Values.GetLength(1); i++)
                    {
                        bool columnComplete = true;
                        for (int k = 0; k < board.Values.GetLength(0); k++)
                        {
                            if (board.Values[k, i] != -1)
                            {
                                columnComplete = false;
                            }
                        }

                        if (columnComplete)
                        {
                            // Winner found
                            Console.WriteLine(CalculateResult(board, number).ToString());
                            return;
                        }
                    }
                }
            }
        }

        

        public static void Part2()
        {
            var lines = System.IO.File.ReadLines(@"input/day4.txt");
            var drawnNumbers = lines.First().Split(",").Select(s => Convert.ToInt32(s)).ToArray();

            var boards = ReadBoards(lines);
            //int result = ;
            foreach (var number in drawnNumbers)
            {
                foreach (var board in boards)
                {
                    if (board.IsComplete) continue;

                    for (int i = 0; i < board.Values.GetLength(0); i++)
                    {
                        bool rowComplete = true;
                        for (int k = 0; k < board.Values.GetLength(1); k++)
                        {
                            if (board.Values[i, k] == number)
                            {
                                board.Values[i, k] = -1;
                            }

                            if (board.Values[i, k] != -1)
                            {
                                rowComplete = false;
                            }
                        }

                        if (rowComplete)
                        {
                            board.IsComplete = true;
                            if (boards.Count(b => b.IsComplete) == boards.Count)
                            {
                                // Winner found
                                Console.WriteLine(CalculateResult(board, number).ToString());
                                return;
                            }

                            break;
                        }
                    }

                    // check if any column is complete
                    for (int i = 0; i < board.Values.GetLength(1); i++)
                    {
                        bool columnComplete = true;
                        for (int k = 0; k < board.Values.GetLength(0); k++)
                        {
                            if (board.Values[k, i] != -1)
                            {
                                columnComplete = false;
                            }
                        }

                        if (columnComplete)
                        {
                            board.IsComplete = true;
                            if (boards.Count(b => b.IsComplete) == boards.Count)
                            {
                                // Winner found
                                Console.WriteLine(CalculateResult(board, number).ToString());
                                return;
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
