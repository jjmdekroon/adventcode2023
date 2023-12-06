namespace AdventCode.Solvers.Q5;

public class SeedsInformation
{
    public Dictionary<int, int> Seeds { get; private set; } = [];

    public void SetSeedNumbers(string line)
    {
        line
            .Split(' ')
            .Where(s => !string.IsNullOrEmpty(s))
            .Select(s => long.Parse(s))
            .ToList();
    }
}
