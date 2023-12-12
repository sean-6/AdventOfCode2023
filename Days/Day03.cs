namespace AdventOfCode2023.Days
{
    public class Day03 : BaseDay
    {
        private readonly string[] _input;

        public Day03()
        {
            _input = File.ReadAllLines(InputFilePath);
        }

        public override string Solve1()
        {
            // Add up all the part numbers to see what is missing
            // Numbers adjacent, even diagnoally are part numbers, anything except '.' is a part number

            var sum = 0;
            // Iterate Lines
            for (var i = 0; i < _input.Length; i++)
            {
                var line = _input[i];

                //Iterate chars
                for (var j = 0; j < _input[i].Length; j++)
                {
                    var character = line[j];

                    if (character.Equals('.') || char.IsDigit(character))
                        continue;

                    //top left

                    //top

                    // top right

                    //left

                    //right

                    // bottom left

                    //bottom

                    //bottom right
                }
            }

            return sum.ToString();
        }

        public override string Solve2()
        {
            return string.Empty;
        }
    }
}