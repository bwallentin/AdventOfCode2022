using System.Reflection;

namespace AdventOfCode.Day1
{
    internal class Day1
    {
        internal void Work()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day1\Input.txt");
            var list = File.ReadAllText(filePath)
                .Split("\r\n\r\n")
                .Select(x => x.Split("\r\n").Select(x => int.Parse(x)))
                .Select(x => x.Sum())
                .OrderByDescending(x => x);

            var first = list.First();
            var second = list.Take(3).Sum();
        }
    }
}
