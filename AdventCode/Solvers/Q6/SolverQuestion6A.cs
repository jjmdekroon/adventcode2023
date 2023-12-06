namespace AdventCode.Solvers.Q6;

public class SolverQuestion6A : SolverBase, ISolver
{
    public string SolveQuestion()
    {
        List<int> times = [];
        List<int> distances = [];
        foreach (var line in _input)
        {
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            var lineSplit = line.Split(':');

            if (lineSplit[0].Equals("Time"))
            {
                times = lineSplit[1].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(x => int.Parse(x)).ToList();
            }

            if (lineSplit[0].Equals("Distance"))
            {
                distances = lineSplit[1].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(x => int.Parse(x)).ToList();
            }
        }

        if(times.Count != distances.Count)
        {
            return "Error in input";
        }

        var race = new List<RaceInfo>();
        for(int i = 0; i < times.Count; i++)
        {
            race.Add(new RaceInfo(times[i], distances[i]));
        }

        var answer = 1L;
        foreach(var raceStep in race)
        {
            answer *= raceStep.WaysToWin;
        }

        return answer.ToString();
    }
}
