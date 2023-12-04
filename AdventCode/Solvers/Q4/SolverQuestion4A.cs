namespace AdventCode.Solvers.Q4;

internal class SolverQuestion4A : SolverBase, ISolver
{
    public string SolveQuestion()
    {
        int answer = 0;

        foreach (var line in _input)
        {
            // Split by :
            var headerSplit = line.Split(':');
            // Split part 2
            var numberListsSplit = headerSplit[1].Split('|');

            // Create the card
            var card = new Card(headerSplit[0], numberListsSplit[0], numberListsSplit[1]);

            // Update answer
            _ = card.CalculatePoints();
            answer += card.Points;
        }

        return answer.ToString();
    }
}
