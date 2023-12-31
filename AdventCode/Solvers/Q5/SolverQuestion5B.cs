﻿namespace AdventCode.Solvers.Q5;

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
                firstInputLine = false;
                seedsInputParser.ParseB(line);
                continue;
            }

            mapperInputParser.Parse(line);
        }

        var answer = long.MaxValue;
        var mapper = new SeedMapper(mapperInputParser.MapperGroups);
        foreach (var seedRange in seedsInputParser.SeedRanges)
        {
            var locations = mapper.MapToLocationByRange(seedRange.Item1, seedRange.Item2);
            foreach (var location in locations)
            {
                if (location.Start != 0 && location.Start < answer)
                {
                    answer = location.Start;
                }
            }
        }


        return answer.ToString();
    }
}
