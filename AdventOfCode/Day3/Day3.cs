using System.Reflection;

namespace AdventOfCode.Day3
{
    internal class Day3
    {
        internal void Work()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day3\Input.txt");
            var firstPuzzle = File.ReadAllText(filePath)
                .Split("\r\n")
                .Select(item => new
                {
                    first = item.Substring(0, item.Length / 2),
                    second = item.Remove(0, item.Length / 2)
                })
                .Select(x => x.first.Intersect(x.second).First().ToString());

            var secondPuzzle = File.ReadAllText(filePath)
                .Split("\r\n")
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / 3)
                .Select(x => x.Select(v => v.Value))
                .Select(x => x.ElementAt(0).Select(s1 => s1)
                    .Intersect(x.ElementAt(1).Select(s2 => s2))
                    .Intersect(x.ElementAt(2).Select(s3 => s3)).First().ToString());

            var first = GetTotal(firstPuzzle);
            var second = GetTotal(secondPuzzle);

        }

        int GetTotal(IEnumerable<string> list)
        {
            return list.Select(x => x switch
            {
                "a" => 1,
                "b" => 2,
                "c" => 3,
                "d" => 4,
                "e" => 5,
                "f" => 6,
                "g" => 7,
                "h" => 8,
                "i" => 9,
                "j" => 10,
                "k" => 11,
                "l" => 12,
                "m" => 13,
                "n" => 14,
                "o" => 15,
                "p" => 16,
                "q" => 17,
                "r" => 18,
                "s" => 19,
                "t" => 20,
                "u" => 21,
                "v" => 22,
                "w" => 23,
                "x" => 24,
                "y" => 25,
                "z" => 26,

                "A" => 27,
                "B" => 28,
                "C" => 29,
                "D" => 30,
                "E" => 31,
                "F" => 32,
                "G" => 33,
                "H" => 34,
                "I" => 35,
                "J" => 36,
                "K" => 37,
                "L" => 38,
                "M" => 39,
                "N" => 40,
                "O" => 41,
                "P" => 42,
                "Q" => 43,
                "R" => 44,
                "S" => 45,
                "T" => 46,
                "U" => 47,
                "V" => 48,
                "W" => 49,
                "X" => 50,
                "Y" => 51,
                "Z" => 52,
            }).Sum();
        }
    }
}
