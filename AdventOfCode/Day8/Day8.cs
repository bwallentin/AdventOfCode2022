using System.Reflection;

namespace AdventOfCode.Day8
{
    internal class Day8
    {
        static readonly int size = 99;

        internal void Work()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day8\input.txt");
            var input = File.ReadAllText(filePath)
                .Split("\r\n")
                .ToList();
            int[,] array = GetArray(input);

            var first = FirstPuzzle(array);
            var second = SecondPuzzle(array);
        }

        private static int FirstPuzzle(int[,] array)
        {
            var counter = 0;

            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (var y = 0; y < array.GetLength(1); y++)
                {
                    var left = StepLeft(array, x, y);
                    var right = StepRight(array, x, y);
                    var up = StepUp(array, x, y);
                    var down = StepDown(array, x, y);

                    if (left.visible || right.visible || up.visible || down.visible)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        private static int SecondPuzzle(int[,] array)
        {
            var highest = 0;

            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (var y = 0; y < array.GetLength(1); y++)
                {
                    // Ignore outskirts
                    if(x == 0 || y == 0)
                    {
                        continue;
                    }

                    var up = StepUp(array, x, y);
                    var left = StepLeft(array, x, y);
                    var right = StepRight(array, x, y);
                    var down = StepDown(array, x, y);

                    var total = left.viewDistance * right.viewDistance * up.viewDistance * down.viewDistance;

                    if(total > highest)
                    {
                        highest = total;
                    }
                }
            }

            return highest;
        }


        private static (bool visible, int viewDistance) StepLeft(int[,] array, int x, int y)
        {
            var viewDistance = 0;

            if (y == 0)
            {
                return (true, viewDistance + 1);
            }

            var value = array[x, y];
            var visible = false;


            for (var i = y-1; i >= 0; i--)
            {
                viewDistance++;
                var current = array[x, i];

                if (current >= value)
                {
                    visible = false;
                    break;
                }
                else
                {
                    visible = true;
                }
            }

            return (visible, viewDistance);
        }


        private static (bool visible, int viewDistance) StepRight(int[,] array, int x, int y)
        {
            var viewDistance = 0;

            if ((y + 1) == array.GetLength(0))
            {
                return (true, viewDistance + 1);
            }

            var value = array[x, y];
            var visible = false;

            for (var i = y+1; i < size; i++)
            {
                viewDistance++;
                var current = array[x, i];

                if (current >= value)
                {
                    visible = false;
                    break;
                }
                else
                {
                    visible = true;
                }
            }

            return (visible, viewDistance);
        }


        private static (bool visible, int viewDistance) StepUp(int[,] array, int x, int y)
        {
            var viewDistance = 0;

            if (x == 0)
            {
                return (true, viewDistance+1);
            }

            var value = array[x, y];
            var visible = false;
            
            for (var i = x-1; i >= 0; i--)
            {
                viewDistance++;
                var current = array[i, y];

                if (current >= value)
                {
                    visible = false;
                    break;
                }
                else
                {
                    visible = true;
                }
            }

            return (visible, viewDistance);
        }

        private static (bool visible, int viewDistance) StepDown(int[,] array, int x, int y)
        {
            var viewDistance = 0;

            if ((x + 1) == array.GetLength(1))
            {
                return (true, viewDistance +1);
            }

            var value = array[x, y];
            var visible = false;

            for (var i = x + 1; i < size; i++)
            {
                viewDistance++;
                var current = array[i, y];

                if (current >= value)
                {
                    visible = false;
                    break;
                }
                else
                {
                    visible = true;
                }
            }

            return (visible, viewDistance);
        }

        private static int[,] GetArray(List<string> input)
        {
            var array = new int[size, size];
            for (var i = 0; i < input.Count; i++)
            {
                var line = input[i];
                for (var j = 0; j < line.Length; j++)
                {
                    var val = line[j].ToString();
                    array[i, j] = int.Parse(val);
                }
            }

            return array;
        }
    }
}
