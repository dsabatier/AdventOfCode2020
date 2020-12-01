using System;
using System.IO;

namespace AdventOfCode2020
{
    class Program
    {

        static readonly string filePath = @"...input.txt";
        static void Main(string[] args)
        {
             int twoSum = twoSum(2020);
             int threeSum = ThreeSum(2020);
        }
        
        // Part 1
        private static int TwoSum(int target)
        {
            if (!File.Exists(filePath)) return -1;
            
            var rawInput = File.ReadAllLines(filePath);
            var input = new int[rawInput.Length];
            for (var i = 0; i < input.Length; i++)
            {
                if (int.TryParse(rawInput[i], out int parsedInt))
                {
                    input[i] = parsedInt;
                }
            }

            Array.Sort(input);

            for (int i = 0; i < input.Length; i++)
            {
                int index = Array.BinarySearch(input, target - input[i]);

                if (index >= 0)
                {
                    return input[i] * input[index];
                }
            }

            return -1;
        }

        // part 2
        private static int ThreeSum(int target)
        {
            if (!File.Exists(filePath)) return -1;
            
            var rawInput = File.ReadAllLines(filePath);
            var input = new int[rawInput.Length];
            for (var i = 0; i < input.Length; i++)
            {
                if (int.TryParse(rawInput[i], out int parsedInt))
                {
                    input[i] = parsedInt;
                }
            }

            Array.Sort(input);

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    int index = Array.BinarySearch(input, target - input[i] - input[j]);

                    if (index >= 0)
                    {
                        return input[i] * input[index] * input[j];
                    }
                }
            }

            return -1;
        }
    }
}
