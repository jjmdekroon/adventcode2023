using System.Linq;

namespace AdventCode.Solvers;

public class SolverQuestion1A : SolverBase, ISolver
{
    public string SolveQuestion()
    {
        var answer = 0;

        foreach(var line in _input)
        {
            var number = LineToNumber(line);
            answer += number;
        }

        return answer.ToString();
    }
}
