using Microsoft.VisualBasic.Logging;

namespace AdventCode.Solvers.Q5;

public class Mapper
{
    public long Source { get; private set; }
    public long Destination { get; private set; }
    public long RangeLength { get; private set; }

    public Mapper(string inputLine)
    {
        var items = inputLine
            .Split(' ')
            .Where(s => !string.IsNullOrEmpty(s))
            .ToList();

        Source = long.Parse(items[1]);
        Destination = long.Parse(items[0]);
        RangeLength = long.Parse(items[2]);
    }

    public long Map(long key)
    {
        if (key >= Source && key < Source + RangeLength)
        {
            // within range so map it
            var delta = key - Source;
            return Destination + delta;
        }

        // No mapping needed.... return the same value
        return key;
    }
}
