using System.Reflection;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day5
{
    internal class Day5
    {
        internal void Work()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day5\Input.txt");
            var input = File.ReadAllText(filePath)
                .Split("\r\n")
                .Where(x => x.StartsWith("move"));

            var firstPuzzleList = GetLists();
            var secondPuzzleList = GetLists();

            foreach (var line in input)
            {
                var numberInfo = Regex.Matches(line, @"\d+").OfType<Match>().Select(m => m.Value).Select(x => int.Parse(x)).ToArray();
                FirstPuzzleMover(howManyToMove: numberInfo[0], fromList: firstPuzzleList.ElementAt(numberInfo[1] - 1), toList: firstPuzzleList.ElementAt(numberInfo[2] - 1));
                SecondPuzzleMover(howManyToMove: numberInfo[0], fromList: secondPuzzleList.ElementAt(numberInfo[1] - 1), toList: secondPuzzleList.ElementAt(numberInfo[2] - 1));
            }

            var firstPuzzle = "";
            firstPuzzleList.ForEach(x => { firstPuzzle += x.Last(); });

            var secondPuzzle = "";
            secondPuzzleList.ForEach(x => { secondPuzzle += x.Last(); });
        }

        static void FirstPuzzleMover(int howManyToMove, List<string> fromList, List<string> toList)
        {
            for(int i=0; i<howManyToMove; i++)
            {
                var selected = fromList.Last();
                fromList.RemoveAt(fromList.Count - 1);
                toList.Add(selected);
            }
        }

        static void SecondPuzzleMover(int howManyToMove, List<string> fromList, List<string> toList)
        {
            var chunk = fromList.TakeLast(howManyToMove);
            toList.AddRange(chunk);
            fromList.RemoveRange(fromList.Count - howManyToMove, howManyToMove);
        }

        private static List<List<string>> GetLists()
        {
            return new List<List<string>>
            {
                new List<string>() { "T", "D", "W", "Z", "V", "P" },
                new List<string>() { "L", "S", "W", "V", "F", "J", "D" },
                new List<string>() { "Z", "M", "L", "S", "V", "T", "B", "H" },
                new List<string>() { "R", "S", "J" },
                new List<string>() { "C", "Z", "B", "G", "F", "M", "L", "W" },
                new List<string>() { "Q", "W", "V", "H", "Z", "R", "G", "B" },
                new List<string>() { "V", "J", "P", "C", "B", "D", "N" },
                new List<string>() { "P", "T", "B", "Q" },
                new List<string>() { "H", "G", "Z", "R", "C" }
            };
        }
    }
}
