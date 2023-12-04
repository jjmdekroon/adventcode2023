using System.Drawing.Drawing2D;

namespace AdventCode.Solvers.Q3;

public class SolverQuestion3ABase : SolverBase
{
    protected Matrix _matrix = null!;

    protected void CreateMatrix()
    {
        var arrayWidth = GetArrayLengthFromFirstLine();
        var arrayLength = _input.Length;

        _matrix = new Matrix(arrayWidth, arrayLength);
        var indexY = 0;
        foreach (var line in _input)
        {
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            var lineCharArray = line.ToCharArray(0, arrayWidth);
            int indexX = 0;
            foreach (char c in lineCharArray)
            {
                _matrix.SetAt(indexX, indexY, c);
                indexX++;
            }

            indexY++;
        }
    }

    protected int GetArrayLengthFromFirstLine()
    {
        var firstLine = _input.FirstOrDefault();
        if (firstLine is null)
        {
            return 0;
        }

        return firstLine.ToArray().Length;
    }
}
