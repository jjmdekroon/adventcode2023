
using System;
using System.Reflection;

namespace AdventCode.Solvers.Q3;

public static class NumberPerimeterWalker
{
    public static Func<int, int, Matrix, bool> CheckForValidChar => (x, y, matrix) =>
    {
        if (x < 0 || y < 0 || x >= matrix.Length || y >= matrix.Width)
        {
            return false;
        }
        return !matrix.CellContainsAnyOf(x, y, "0123456789.");
    };
    public static Func<int, int, Matrix, bool> CheckForGearChar => (x, y, matrix) =>
    {
        if (x < 0 || y < 0 || x >= matrix.Length || y >= matrix.Width)
        {
            return false;
        }

        return matrix.CellContainsAnyOf(x, y, "*");
    };

    // Check cells where the dots are placed:
    // . . . . .
    // . 1 2 3 .
    // . . . . .
    // 
    // Check on the dots if there is a symbol
    // keep the edge cases in mind.
    public static bool NumberHasSymbolLink(Matrix? matrix, MatrixNumber matrixNumber, Func<int, int, Matrix, bool> checker)
    {
        var symbolPositions = new List<Point>();

        if(matrix is null)
        {
            return false;
        }

        // start left-top
        var x = matrixNumber.Point.X - 1;
        var y = matrixNumber.Point.Y - 1;
        var length = matrixNumber.Length;

        for (int index = 0; index < (length + 2); index++)
        {
            if(checker(x + index, y, matrix))
            {
                symbolPositions.Add(new Point(x + index, y));
            }
        }
        
        // next line
        y++;
        if (checker(x, y, matrix))
        {
            symbolPositions.Add(new Point(x, y));
        }

        if (checker(x + length + 1, y, matrix))
        {
            symbolPositions.Add(new Point(x + length + 1, y));
        }

        // next line
        y++;
        for (int index = 0; index < (length + 2); index++)
        {
            if (checker(x + index, y, matrix))
            {
                symbolPositions.Add(new Point(x + index, y));
            }
        }

        matrixNumber.AddLinkedSymbols(symbolPositions);

        // True if any symbol is found
        return symbolPositions.Any();
    }

    // Check the cell
    // true when there is an symol found
    // False when a number is found or an . or the position does not exsist (out of bounds)
/*    private static bool SafeDetermineContainSymboxInMatrix(int x, int y, Matrix matrix)
    {
        if (x < 0 || y < 0 || x >= matrix.Length || y >= matrix.Width)
        {
            // out of bounds
            return false;
        }

        return !matrix.CellContainsAnyOf(x, y, "0123456789.");
    }*/
}
