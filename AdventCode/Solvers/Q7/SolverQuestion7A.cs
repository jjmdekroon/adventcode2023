namespace AdventCode.Solvers.Q7;

internal class SolverQuestion7A : SolverBase, ISolver
{
    public string SolveQuestion()
    {
        var hands = new List<Hand>();

        foreach (var item in _input)
        {
            if (string.IsNullOrEmpty(item))
            {
                continue;
            }

            var lineSplit = item.Trim().Split(' ');
            hands.Add(
                new Hand(
                    inTheHand: lineSplit[0],
                    bid: int.Parse(lineSplit[1])
            ));
        }

        var listOfHands = hands
            .OrderBy(o => o.Type)
            .ThenByDescending(o => o.HandValue).ToList();

        var answer = 0;
        for (var i = 0; i < listOfHands.Count; i++)
        {
            answer += (i + 1) * listOfHands[i].Bid;
        }

        return answer.ToString();
    }
}
