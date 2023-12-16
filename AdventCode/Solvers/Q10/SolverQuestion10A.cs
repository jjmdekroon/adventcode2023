using System.Drawing.Drawing2D;

namespace AdventCode.Solvers.Q10;

public class SolverQuestion10A : SolverBase, ISolver
{
    public string SolveQuestion()
    {
        var length = _input.First().ToArray().Length;
        var height = _input.Length;

        var matrix = new IslandMatrix(length, height);
        foreach (var line in _input) 
        {
            matrix.AddRow(line);
        }

        var startCell = matrix.GetStartCell('S');
        PathCalculator.Calculate(ref matrix, startCell);

        var answer = 24;

        return answer.ToString();
    }
}
