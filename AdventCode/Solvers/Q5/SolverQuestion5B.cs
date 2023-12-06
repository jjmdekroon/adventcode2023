namespace AdventCode.Solvers.Q5;

public class SolverQuestion5B : SolverBase, ISolver
{
    public string SolveQuestion()
    {
        var mapperInputParser = new MapperInputParser();
        var seedsInputParser = new SeedsRangeInputParser();
        var firstInputLine = true;

        // Prepare
        foreach (var line in _input)
        {
            if (string.IsNullOrEmpty(line))
            {
                // Discard empty lines
                continue;
            }

            if (firstInputLine)
            {
                seedsInputParser.Parse(line);
            }

            mapperInputParser.Parse(line);
        }

        var answer = 0;



        return "Not yet found";
    }
}
