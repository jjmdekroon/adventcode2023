namespace AdventCode.Solvers.Q5;

public class SeedsInputParser
{
    public List<long> Seeds { get; private set; } = [];
    public void Parse(string line) 
    {
        if (string.IsNullOrEmpty(line))
        {
            // Discard empty lines
            return;
        }

        var headerSplit = line.Split(':');
        string seedsLine = headerSplit[1].Trim();

        Seeds = seedsLine
            .Split(' ')
            .Where(s => !string.IsNullOrEmpty(s))
            .Select(s => long.Parse(s))
            .ToList();
    }
}
