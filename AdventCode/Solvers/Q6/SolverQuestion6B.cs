namespace AdventCode.Solvers.Q6;

public class SolverQuestion6B : SolverBase, ISolver
{
    public string SolveQuestion()
    {
        var time = 0L;
        var distance = 0L;
        foreach (var line in _input)
        {
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            var lineSplit = line.Split(':');

            if (lineSplit[0].Equals("Time"))
            {
                var timeString = new String(lineSplit[1].Trim().ToCharArray().Where(x => x != ' ').ToArray());
                time = long.Parse(timeString);
            }

            if (lineSplit[0].Equals("Distance"))
            {
                var distancesString = new String(lineSplit[1].Trim().ToCharArray().Where(x => x != ' ').ToArray());
                distance = long.Parse(distancesString);
            }
        }

        var raceInfo = new RaceInfo(time, distance);
        var answer = raceInfo.WaysToWin;


        return answer.ToString();
    }
}
