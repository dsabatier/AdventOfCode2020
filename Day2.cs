using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    class Program
    {

        static readonly string filePath = @"...input.txt";
        static void Main(string[] args)
        {
            Console.WriteLine(GetValidPasswordCount());
        }

        private static int GetValidPasswordCount()
        {
            if (!File.Exists(filePath)) return -1;

            int total = 0;
            Dictionary<char, int> lookup = new Dictionary<char, int>();
            Dictionary<char, Tuple<int, int>> rulesLookup = new Dictionary<char, Tuple<int, int>>();

            foreach (string line in File.ReadLines(filePath))
            {
                var parts = line.Split(' ');
                var rangeParts = parts[0].Split('-');
                int min = int.Parse(rangeParts[0]);
                int max = int.Parse(rangeParts[1]);
                var key = parts[1][0];
                var password = parts[2];
                int count = password.Split(key).Length - 1;
                
                // for part 1
                // if (count >= min && count <= max)
                // {
                //     Console.WriteLine($"min: {min}, max: {max}, key: {key}, password: {password}, count: {count}");
                //     total++;
                // }
                
                
                // for part 2
                if (count == 0)
                    continue;
                
                bool first = password[min-1] == key;
                bool second = password[max-1] == key;

                if (first ^ second)
                {
                    total++;
                }
            }
            
            return total;
        }
    }
}
