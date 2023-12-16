

namespace AdventCode.Solvers.Q9;

public class EnvironmentRow
{
    private long[] items = [];
    public EnvironmentRow(string valueString)
    {
        var step1 = valueString.Trim().Split(' ').ToList();
        var step2 = step1.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        items = step2.Select(x => long.Parse(x.Trim())).ToArray();
    }

    public List<long> Values => items.ToList();

    public long TotalValue => items.Sum(x => x);

    internal EnvironmentRow CalculateNextRow()
    {
        var newItems = string.Empty;
        for (int i = 1; i < items.Length; i++)
        {
            var value = items[i] - items[i - 1];
            newItems += " " + value.ToString();
        }

        return new EnvironmentRow(newItems);
    }
}
