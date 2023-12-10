using Microsoft.VisualBasic.Logging;
using System.Collections.Generic;

namespace AdventCode.Solvers.Q5;

public class Mapper
{
    public long Source { get; private set; }
    public long Destination { get; private set; }
    public long Length { get; private set; }

    public Mapper(string inputLine)
    {
        var items = inputLine
            .Split(' ')
            .Where(s => !string.IsNullOrEmpty(s))
            .ToList();

        Source = long.Parse(items[1]);
        Destination = long.Parse(items[0]);
        Length = long.Parse(items[2]);
    }

    public long Map(long key)
    {
        if (key >= Source && key < Source + Length)
        {
            // within range so map it
            var delta = key - Source;
            return Destination + delta;
        }

        // No mapping needed.... return the same value
        return key;
    }

    public List<(long, long)> MapRange(long start, long length)
    {
        var lijstVanRanges = new List<(long, long)>();

        // AAAAAAAAAAAAAAAAHHHHHHHHHHHHHHHHHHHHHH
        // I GIVE UP

        return lijstVanRanges;
    }
}
