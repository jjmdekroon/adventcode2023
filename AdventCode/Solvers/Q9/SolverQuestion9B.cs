using System.Numerics;

namespace AdventCode.Solvers.Q9;

public class SolverQuestion9B : SolverBase, ISolver
{
    public string SolveQuestion()
    {
        var diffs = new List<int>();
        var lastNr = new List<int>();
        var answer = 0;

        var rows = new List<EnvironmentRow>();
        foreach (var line in _input)
        {
            var row = new EnvironmentRow(line);
            rows.Add(row);
        }

        foreach (var row in rows)
        {
            // calculate per row the subrows
            var subRows = new List<EnvironmentRow>();
            subRows.Add(row);

            var nextRow = row;
            while (nextRow.TotalValue > 0)
            {
                nextRow = nextRow.CalculateNextRow();
                subRows.Add(nextRow);
            }

            subRows.Reverse();
            for (int i = 1; i < subRows.Count; i++)
            {
                var prevRowItem = subRows[i - 1].Values.First();
            }

        }

        return answer.ToString();
    }
}
