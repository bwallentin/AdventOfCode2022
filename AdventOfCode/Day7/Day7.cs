using System.Reflection;

namespace AdventOfCode.Day7
{
    internal class Day7
    {
        internal void Work()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day7\input.txt");
            var input = File.ReadAllText(filePath)
                .Split("\r\n")
                .AsEnumerable();

            var directories = BuildDirectories(input);

            var first = FirstPuzzle(directories);
            var second = SecondPuzzle(directories);
        }

        private static int FirstPuzzle(List<Directory> directories)
        {
            return directories
                .Where(d => d.GetSize() <= 100000)
                .Select(d => d.GetSize())
                .Sum();
        }

        private static int SecondPuzzle(List<Directory> directories)
        {
            var diskSpace = 70000000;
            var unused = diskSpace - directories.First().GetSize();
            var neededSpace = 30000000 - unused;

            return directories
                .Select(d => d.GetSize())
                .Where(d => d > neededSpace)
                .Min();
        }

        private static List<Directory> BuildDirectories(IEnumerable<string> input)
        {
            var directories = new List<Directory>();

            var current = new Directory(null, "/");
            directories.Add(current);

            foreach (var line in input)
            {
                switch (line)
                {
                    case string s when s.StartsWith("$ cd"):
                        var targetDirectory = line.Split(' ').Last();
                        current = targetDirectory.Equals("..") ? current.Up() : current.Down(targetDirectory);
                        continue;

                    case string s when s.StartsWith("$ ls"):
                        continue;

                    case string s when s.StartsWith("dir "):
                        targetDirectory = line.Split(" ").Last();
                        var dir = new Directory(current, targetDirectory);
                        directories.Add(dir);
                        current.Children.Add(dir);
                        break;

                    default:
                        var value = line.Split(" ").First();
                        var fileName = line.Split(" ").Last();
                        current.Files.Add((fileName, int.Parse(value)));
                        break;
                }
            }

            return directories;
        }
    }

    internal class Directory
    {
        public string Name { get; }
        public Directory Parent { get; }
        public List<Directory> Children { get; } = new();
        public List<(string name, int size)> Files { get; } = new();

        public Directory(Directory parent, string name)
        {
            Parent = parent;
            Name = name;
        }

        public Directory Up() => Parent;

        public Directory Down(string name) => name.Equals("/")
            ? this
            : Children.First(d => d.Name.Equals(name));

        public int GetSize()
        {
            if (Children.Any())
            {
                return Children.Select(c => c.GetSize()).Sum() + Files.Select(f => f.size).Sum();
            }
            else
            {
                return Files.Select(f => f.size).Sum();
            } 
        }
    }
}
