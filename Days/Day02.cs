namespace AdventOfCode2023.Days
{
    public class Day02 : BaseDay
    {
        private IEnumerable<string> _input;

        public Day02()
        {
            _input = File.ReadLines(InputFilePath);
        }

        public override string Solve1()
        {
            var sum = 0;
            foreach (var line in _input)
            {
                var colours = new Dictionary<string, int>
                {
                    { "blue", 14 },
                    { "red", 12 },
                    { "green", 13 }
                };

                var splitInTwo = line.Split(":");
                var id = int.Parse(splitInTwo[0].Split(" ")[1]);

                var bagContents = splitInTwo[1].TrimStart();

                bagContents = bagContents.Replace(",", ";");
                var games = bagContents.Split(";");

                var contentWithNumbers = games.Select(game => game.Trim().Split(" ")).ToList();

                if (contentWithNumbers.All(x => int.Parse(x[0]) <= colours[x[1]]))
                    sum += id;
            }

            return sum.ToString();
        }

        public override string Solve2()
        {
            var sum = 0;
            foreach (var line in _input)
            {
                var lowest = new Dictionary<string, int>
                {
                    { "blue", 0 },
                    { "red", 0 },
                    { "green", 0 }
                };

                var colours = new Dictionary<string, int>
                {
                    { "blue", 14 },
                    { "red", 12 },
                    { "green", 13 }
                };

                var splitInTwo = line.Split(":");
                var id = int.Parse(splitInTwo[0].Split(" ")[1]);

                var bagContents = splitInTwo[1].TrimStart();

                bagContents = bagContents.Replace(",", ";");
                var games = bagContents.Split(";");

                var contentWithNumbers = games.Select(game => game.Trim().Split(" ")).ToList();

                foreach (var item in contentWithNumbers)
                {
                    var count = int.Parse(item[0]);
                    var colour = item[1];

                    if (count > lowest[colour])
                        lowest[colour] = count;
                }

                sum += lowest.Values.Aggregate((a, b) => a * b);
            }
            return sum.ToString();
        }
    }
}
