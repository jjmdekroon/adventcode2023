namespace AdventCode.Solvers.Q5
{
    public class SeedsRangeInputParser
    {
        // SeedStart , count
        public List<(long, long)> SeedRanges { get; private set; } = [];
        public void Parse(string line) 
        {
            if (string.IsNullOrEmpty(line))
            {
                // Discard empty lines
                return;
            }

            var headerSplit = line.Split(':');
            string seedsLine = headerSplit[1].Trim();

            var seedItems = seedsLine
                .Split(' ')
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s => long.Parse(s))
                .ToList();

            for (int i = 0; i < seedItems.Count; i+=2) 
            {
                var seedStart = seedItems[i];
                var seedCount = seedItems[i+1];

                SeedRanges.Add((seedStart, seedCount));
            }
        }
    }
}
