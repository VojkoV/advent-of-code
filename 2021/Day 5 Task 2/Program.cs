using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_5_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read input
            var lines = File.ReadAllLines(@"D:\Projects\Advent of Code 2021\Day 4\input.txt").ToList();
            int multipler = 1000;
            var TenAs = new string('0', multipler).Split("").ToList();
            double[,] D = new double[1000, 1000];
            Array.Clear(D, 0, D.Length);
            var numbers = lines.First().Split(",").Select(x => int.Parse(x)).ToList();
            // Remove numbers
            lines.Remove(lines.First());
            // Remove empty lines
            lines.RemoveAll(x => string.IsNullOrEmpty(x));
            lines = lines.Select(x => x.Trim().Replace("   ", " ").Replace("  ", " ")).ToList();
            var linesForResult = lines;
            // Read in all bingo cards
            List<List<List<int>>> cards = new();
            while (lines.Count >= 5)
            {
                // Init column lists
                var card = new List<List<int>>() { 
                    new List<int>(),
                    new List<int>(),
                    new List<int>(),
                    new List<int>(),
                    new List<int>(),
                };
                for (int rowCounter = 0; rowCounter < 5; rowCounter++)
                {
                    var row = lines.First().Split(" ").Select(x => int.Parse(x)).ToList();
                    // Add complete row list
                    card.Add(row);
                    row.ForEach(x => card[row.IndexOf(x)].Add(x));
                    lines.Remove(lines.First());
                }
                cards.Add(card);
            }
            foreach (var number in numbers)
            {
                cards.ForEach(c => c.ForEach(x => x.Remove(number)));
                var winningCard = cards.FirstOrDefault(c => c.Any(x => x.Count == 0));
                if(winningCard is not null)
                {
                    Console.WriteLine($"Winning card is at index: {cards.IndexOf(winningCard)}");
                    var unmarkedSum = winningCard.Sum(x => x.Sum()) / 2; // All numbers appear twice. Once in the row and once in the column list.
                    Console.WriteLine($"Winning score is: {unmarkedSum * number}");
                    break;
                }
            }

        }
    }
}
