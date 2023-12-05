namespace AdventCode.Solvers.Q5;

public class SolverQuestion5A : SolverBase, ISolver
{
    public string SolveQuestion()
    {
        var parser = new InputParser();
        foreach (var line in _input)
        {
            parser.Parse(line);
        }

        var answer = long.MaxValue;
        var mapper = new SeedMapper(parser.MapperGroups);
        foreach(var seed in parser.Seeds)
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
