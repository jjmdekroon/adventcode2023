namespace AdventCode.Solvers.Q4;

internal class SolverQuestion4B : SolverBase, ISolver
{
    public string SolveQuestion()
    {
        var cards = new List<Card>();


        foreach (var line in _input)
        {
            // Split by :
            var headerSplit = line.Split(':');
            // Split part 2
            var numberListsSplit = headerSplit[1].Split('|');

            // Create the card
            cards.Add(new Card(headerSplit[0], numberListsSplit[0], numberListsSplit[1]));
        }

        foreach(var card in cards)
        {
            var matches = card.CalculatePoints();            
            while(matches > 0)
            {
                var updateCard = cards.Where(x => x.Id == card.Id + matches).First();
                var copies = card.Instances - 1;
                updateCard?.IncreatePointsDoubler(1 + copies);
                matches--;
            }
        }

        int answer = 0;
        foreach (var card in cards)
        {
            answer += card.Instances;
        }

        return answer.ToString();
    }
}
