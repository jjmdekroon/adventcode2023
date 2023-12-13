using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;

namespace AdventCode.Solvers.Q5;

public class Mapper
{
    private long _source;
    private long _length;
    private long _destination;
    private long _end;

    public Mapper(string inputLine)
    {
        var items = inputLine
            .Split(' ')
            .Where(s => !string.IsNullOrEmpty(s))
            .ToList();

        _destination = long.Parse(items[0]);

        _source = long.Parse(items[1]);
        _length = long.Parse(items[2]);

        _end = _source + _length;
    }

    public long Map(long key)
    {
        if (key >= _source && key < _end)
        {
            // within range so map it
            var delta = key - _source;
            return _destination + delta;
        }

        // No mapping needed.... return the same value
        return key;
    }

    public List<Range> MapRange(Range range)
    {
        var lijstVanRanges = new List<Range>();

        //              [...............]
        //    [........]
        //                                       [........]
        if (range.End < _source || range.Start > _end)
        {
            // Buiten range, geen conversie nodig
            lijstVanRanges.Add(new Range(range.Start, range.Length, false));
            return lijstVanRanges;
        }

        //              [...............]
        //                  [........]
        if (range.Start >= _source && range.End <= _end)
        {
            // Binnen range, volledige conversie nodig
            lijstVanRanges.Add(new Range(Map(range.Start), range.Length, true));
            return lijstVanRanges;
        }

        // Nu hebben we overlap en moeten we kijken of er 2 of 3 ranges zijn.

        //              [..................]
        //            [........................]
        if (range.Start < _source && range.End > _end)
        {
            // overlap splitsen in drie delen, middelste deel converteren
            lijstVanRanges.Add(new Range(range.Start, _source - range.Start, false));
            lijstVanRanges.Add(new Range(Map(_source), _end, true));
            lijstVanRanges.Add(new Range(_end, range.End - _end, false));
            return lijstVanRanges;
        }

        //              [..................]
        //     [..............]
        //     [....1...][..2.]

        if (range.Start < _source)
        {
            lijstVanRanges.Add(new Range(range.Start, _source - range.Start, false));
            lijstVanRanges.Add(new Range(Map(_source), range.End - _source, true));
            return lijstVanRanges;
        }


        //     [.....................]
        //              [..................]
        //              [..1........][..2..]
        lijstVanRanges.Add(new Range(Map(range.Start), _end - range.Start, true));
        lijstVanRanges.Add(new Range(_end, range.End - _end, false));
        
        return lijstVanRanges;
    }
}
