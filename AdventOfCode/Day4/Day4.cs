using System.Reflection;

namespace AdventOfCode.Day4
{
    internal class Day4
    {
        internal void Work()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day4\Input.txt");
            var input = File.ReadAllText(filePath)
                .Replace(",", "-")
                .Split("\r\n")
                .Select(x => x.Split("-").Select(x => int.Parse(x)));

            var first = FirstPuzzle(input);
            var second = SecondPuzzle(input);
        }

        int FirstPuzzle(IEnumerable<IEnumerable<int>> input)
        {
            var count = 0;
            foreach (var line in input)
            {
                GetNumbers(line, out var one, out var two, out var three, out var four);

                if (one >= three && two <= four ||
                    three >= one && four <= two)
                {
                    count++;
                }
            }
            return count;
        }

        int SecondPuzzle(IEnumerable<IEnumerable<int>> input)
        {
            var count = 0;
            foreach (var line in input)
            {
                GetNumbers(line, out var one, out var two, out var three, out var four);

                if (one < three)
                {
                    if (two >= three)
                    {
                        count++;
                    }
                }
                else if (one > three)
                {
                    if (one <= four)
                    {
                        count++;
                    }
                }
                else
                {
                    count++;
                }
            }
            return count;
        }

        void GetNumbers(IEnumerable<int> line, out int one, out int two, out int three, out int four)
        {
            one = line.ElementAt(0);
            two = line.ElementAt(1);
            three = line.ElementAt(2);
            four = line.ElementAt(3);
        }
    }
}
