
using System.Diagnostics;

namespace AdventCode.Solvers.Q5;

[DebuggerDisplay("{Start} ... {End}, L={Length}")]
public class Range
{
    public long Start { get; init; }
    public long Length { get; init; }
    public long End => Start + Length;

    public bool IsAlreadyConverted { get; private set; }

    public Range(long start, long length, bool isAlreadyConverted)
    {
        if (length == 0)
        {
            Start = -1;
            Length = 0;
            IsAlreadyConverted = true;
        }

        Start = start;
        Length = length;
        IsAlreadyConverted = isAlreadyConverted;
    }

    internal void ResetAlreadyConverted()
    {
        IsAlreadyConverted = false;
    }
}
