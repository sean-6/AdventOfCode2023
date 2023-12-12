namespace AdventOfCode2023.Days
{
    public class Day01 : BaseDay
    {
        private readonly IEnumerable<string> _input;

        private Dictionary<string, int> _mappedNumbers = new Dictionary<string, int>
        {
            {"one", 1 },
            {"two", 2 },
            {"three", 3 },
            {"four", 4 },
            {"five", 5 },
            {"six", 6 },
            {"seven", 7 },
            {"eight", 8 },
            {"nine", 9 }
        };

        public Day01()
        {
            _input = File.ReadLines(InputFilePath);
        }

        public override string Solve1()
        {
            return _input.Select(x => x.Where(x => char.IsDigit(x)).ToList())
                 .Select(x => $"{x[0]}{x[^1]}")
                 .Select(x => int.Parse(x))
                 .Sum()
                 .ToString();
        }

        public override string Solve2()
        {
            var nums = new List<int>();

            for (var i = 0; i < _input.Count(); i++)
            {
                var numbers = new List<int>();
                var currentStringAsArray = _input.ElementAt(i).ToCharArray();

                for (var j = 0; j < currentStringAsArray.Length; j++)
                {
                    var currentChar = currentStringAsArray[j];

                    if (int.TryParse(currentChar.ToString(), out var num))
                        numbers.Add(num);

                    if (j + 2 < currentStringAsArray.Length)
                    {
                        var sub = _input.ElementAt(i).Substring(j, 3);

                        if (_mappedNumbers.Any(x => x.Key.Equals(sub)))
                            numbers.Add(_mappedNumbers.First(x => x.Key.Equals(sub)).Value);
                    }
                    if (j + 3 < currentStringAsArray.Length)
                    {
                        var sub = _input.ElementAt(i).Substring(j, 4);

                        if (_mappedNumbers.Any(x => x.Key.Equals(sub)))
                            numbers.Add(_mappedNumbers.First(x => x.Key.Equals(sub)).Value);
                    }
                    if (j + 4 < currentStringAsArray.Length)
                    {
                        var sub = _input.ElementAt(i).Substring(j, 5);

                        if (_mappedNumbers.Any(x => x.Key.Equals(sub)))
                            numbers.Add(_mappedNumbers.First(x => x.Key.Equals(sub)).Value);
                    }
                }

                nums.Add(int.Parse($"{numbers.First()}{numbers.Last()}"));
            }

            return nums.Sum().ToString();
        }
    }
}