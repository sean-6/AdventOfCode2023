namespace AdventOfCode2023.Days
{
    public class Day03 : BaseDay
    {
        private readonly char[][] _input;

        public Day03()
        {
            _input = File.ReadAllLines(InputFilePath).Select(x => x.ToCharArray()).ToArray();
        }

        public bool IsValidCoordinate(int x, int y, int rowLength, int arrayLength) => x >= 0 && y >= 0 && y < rowLength && x < arrayLength;

        public override string Solve1()
        {
            var numbers = new List<int>();
            for (var i = 0; i < _input.Length; i++)
            {
                var number = 0;
                var hasAdjacentSymbol = false;
                for (var j = 0; j < _input[i].Length; j++)
                {
                    var character = _input[i][j];
                    var isDigit = char.IsDigit(character);
                    if (isDigit)
                    {
                        var digit = character - '0';
                        number *= 10;
                        number += digit;

                        hasAdjacentSymbol = hasAdjacentSymbol || IsSymbolAdjacent(i, j, _input);
                    }

                    if (j == _input.Length - 1 || !isDigit)
                    {
                        if (hasAdjacentSymbol)
                        {
                            numbers.Add(number);
                        }

                        hasAdjacentSymbol = false;
                        number = 0;
                    }
                }
            }

            return numbers.Sum().ToString();
        }

        private bool IsSymbolAdjacent(int x, int y, char[][] input)
        {
            var offsets = new List<(int X, int Y)>
            {
                (x - 1, y - 1), (x - 1, y), (x - 1, y + 1), (x, y - 1), (x, y + 1), (x + 1, y - 1), (x + 1, y), (x + 1, y + 1)
            };

            return offsets.Where(coordinate => IsValidCoordinate(coordinate.X, coordinate.Y, input[x].Length, input[y].Length)).Any(coordinate => _input[coordinate.X][coordinate.Y] != '.' && !char.IsDigit(_input[coordinate.X][coordinate.Y]));
        }

        public override string Solve2()
        {
            return string.Empty;
        }
    }
}