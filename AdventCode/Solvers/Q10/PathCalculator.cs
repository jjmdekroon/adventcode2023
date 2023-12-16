using System.Runtime.InteropServices;

namespace AdventCode.Solvers.Q10;

public static class PathCalculator
{
    public static void Calculate(ref IslandMatrix matrix, (int, int) startCell)
    {
        var convertedMatrix = matrix;

        // search into the 8 different directions
        List<PathSearcher> pathSearchers = [];

        var initialPathSearcher = new PathSearcher(
            matrix, 
            startCell, 
            directon: (startCell.Item1 - 1, startCell.Item2)
        );

        // Add to list

        // Walk through list until no more cells needs to be investigated


    }
}
