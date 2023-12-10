namespace AdventCode.Solvers.Q5;

public class SolverQuestion5A : SolverBase, ISolver
{
    public string SolveQuestion()
    {
        var mapperInputParser = new MapperInputParser();
        var seedsInputParser = new SeedsInputParser();
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
                firstInputLine = false;
                seedsInputParser.Parse(line);
                continue;
            }

            mapperInputParser.Parse(line);
        }

        // Find answer
        var answer = long.MaxValue;
        var mapper = new SeedMapper(mapperInputParser.MapperGroups);
        foreach(var seed in seedsInputParser.Seeds)
        {
            var location = mapper.MapToLocation(seed);
            if (location < answer)
            {
                answer = location;
            }
        }

        return answer.ToString();
    }
}
