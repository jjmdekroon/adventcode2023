using System.Numerics;

namespace AdventCode.Solvers.Q9;

public class SolverQuestion9B : SolverBase, ISolver
{
    public string SolveQuestion()
    {
        var diffs = new List<int>();
        var lastNr = new List<int>();
        var answer = 0;

        foreach (var line in _input)
        {
            var step1 = line.Trim().Split(' ').ToList();
            var step2 = step1.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            var items = step2.Select(x => int.Parse(x.Trim())).ToArray();
            var predictedValue = items[0];
            List<int> checkItems = [];
            do
            {
                checkItems.Clear();
                for (var i = 0; i < (items.Length - 1); i++)
                {
                    checkItems.Add(items[i + 1] - items[i]);
                }

                predictedValue -= checkItems[0];

                items = checkItems.ToArray();

            } while (checkItems.Sum() != 0);

            answer += predictedValue;
        }


        return answer.ToString();
    }
}
