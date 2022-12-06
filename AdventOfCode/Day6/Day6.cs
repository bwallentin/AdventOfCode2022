using System.Reflection;

namespace AdventOfCode.Day6
{
    internal class Day6
    {
        internal void Work()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day6\input.txt");
            var input = File.ReadAllText(filePath);
            
            var first = Solve(input, 4);
            var second = Solve(input, 14);
        }

        private int Solve(string input, int distinctChars)
        {
            for (int i = 0; i < (input.Length - (distinctChars-1)); i++)
            {
                var text = input.Substring(i, distinctChars);

                if (text.Distinct().Count() == distinctChars)
                {
                    return i + distinctChars;
                }
            }
            return 0;
        }
    }
}
