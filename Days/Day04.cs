using AdventOfCode2023.Classes;

namespace AdventOfCode2023.Days
{
    public class Day04 : BaseDay
    {
        private readonly List<ScratchcardGame> _input;

        public Day04()
        {
            _input = File.ReadAllLines(InputFilePath)
                .Select(x => x.Split(": ")[1])
                .Select(x => x.Trim().Split(" | "))
                .Select(x => new ScratchcardGame
                {
                    GameNumbers = x[0].Trim().Replace("  ", " ").Split(" ").ToList().ConvertAll(x => int.Parse(x)),
                    WinningNumbers = x[1].Trim().Replace("  ", " ").Split(" ").ToList().ConvertAll(x => int.Parse(x))
                }).ToList();
        }

        public override string Solve1()
        {
            return _input.Select(x => x.GameNumbers.Where(y => x.WinningNumbers.Contains(y))).Sum(x => !x.Any() ? 0 : x.Skip(1).Aggregate(1, (a, _) => a * 2)).ToString();
        }

        public override string Solve2()
        {
            return "";
        }
    }
}