namespace AdventOfCode2023.Days
{
    public class Day02 : BaseDay
    {
        private readonly List<ElfGame> _input;
        private readonly Dictionary<string, int> _colours =
            new()
            {
                { "blue", 14 },
                { "red", 12 },
                { "green", 13 }
            };

        public Day02()
        {
            _input = File.ReadLines(InputFilePath)
                .Select(x => x.Split(": "))
                .Select(
                    x =>
                        new ElfGame
                        {
                            GameId = int.Parse(x[0].Split(" ")[1]),
                            Contents = x[1].Replace(",", ";").Split("; ")
                        }
                )
                .ToList();
        }

        public override string Solve1()
        {
            var sum = 0;
            foreach (var game in _input)
            {
                if (
                    game.Contents!.All(x => int.Parse(x.Split(" ")[0]) <= _colours[x.Split(" ")[1]])
                )
                    sum += game.GameId;
            }

            return sum.ToString();
        }

        public override string Solve2()
        {
            var sum = 0;

            foreach (var game in _input)
            {
                var lowest = new Dictionary<string, int>
                {
                    { "blue", 0 },
                    { "red", 0 },
                    { "green", 0 }
                };

                foreach (var item in game.Contents!)
                {
                    var countAndColour = item.Split(" ");
                    var count = int.Parse(countAndColour[0]);
                    var colour = countAndColour[1];

                    if (count > lowest[colour])
                        lowest[colour] = count;
                }
                sum += lowest.Values.Aggregate((a, b) => a * b);
            }

            return sum.ToString();
        }
    }
}
