using System.Reflection;

namespace AdventOfCode.Day2
{
    internal class Day2
    {
        internal void Work()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day2\Input.txt");
            var input = File.ReadAllText(filePath).Split("\r\n");

            var rock = 1;
            var paper = 2;
            var scissors = 3;

            var win = 6;
            var draw = 3;
            var lose = 0;

            var first = input.Select(x => x switch
            {
                "A X" => rock + draw,
                "B X" => rock + lose,
                "C X" => rock + win,

                "A Y" => paper + win,
                "B Y" => paper + draw,
                "C Y" => paper + lose,

                "A Z" => scissors + lose,
                "B Z" => scissors + win,
                "C Z" => scissors + draw,
            }).Sum();

            var second = input.Select(x => x switch
            {
                "A X" => lose + scissors,
                "B X" => lose + rock,
                "C X" => lose + paper,

                "A Y" => draw + rock,
                "B Y" => draw + paper,
                "C Y" => draw + scissors,

                "A Z" => win + paper,
                "B Z" => win + scissors,
                "C Z" => win + rock,
            }).Sum();
        }
    }
}
