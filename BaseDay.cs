namespace AdventOfCode2023
{
    public abstract class BaseDay
    {
        private string InputFileDirPath { get; } = "Inputs";
        private string InputFileExtension { get; } = ".txt";
        public string InputFilePath
        {
            get => Path.Combine(InputFileDirPath, $"{GetDay()}{InputFileExtension}");
        }

        private string GetDay()
        {
            var type = GetType().Name;
            return type.Substring(type.Length - 2, 2);
        }

        public abstract string Solve1();
        public abstract string Solve2();

    }
}