

namespace AdventCode.Solvers.Q4;

public class Card
{
    private int _points = 0;
    public int Instances { get; private set; } = 1;

    public int Id { get; private set; }
    public List<int> WinningNumbers { get; private set; } = [];
    public List<int> AvailableNumbers { get; private set; } = [];
    public int Points => Instances * _points;

    public Card(string headerId, string winningNumbersAsString, string availableNumbersAsString)
    {
        var headerItems = headerId.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList();
        Id = int.Parse(headerItems[1]);

        var winningNumbers = winningNumbersAsString.Trim().Split(' ') ?? [];
        WinningNumbers = winningNumbers
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(x => int.Parse(x)).ToList();

        var availableNumbers = availableNumbersAsString.Trim().Split(" ") ?? [];
        AvailableNumbers = availableNumbers
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(x => int.Parse(x)).ToList();
    }

    public int CalculatePoints()
    {
        var intersectedNumbers = WinningNumbers.Intersect(AvailableNumbers);

        if (intersectedNumbers.Any())
        {
            var timesTwo = intersectedNumbers.Count() - 1;
            _points = 1 << timesTwo;
            return intersectedNumbers.Count();
        }

        return 0;
    }

    internal void IncreatePointsDoubler(int increaseBy)
    {
        Instances += increaseBy;
    }
}
