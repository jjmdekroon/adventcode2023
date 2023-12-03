namespace AdventCode.Solvers;

public class SolverQuestion2A : SolverBase, ISolver
{
    private readonly Dictionary<string, int> conditionColorCount = new Dictionary<string, int>
    { 
        { "red", 12 },
        { "green", 13 },
        { "blue", 14 }
    };

    public string SolveQuestion()
    {
        var answer = 0;

        // for every line
        int GameIndex = 0;
        foreach (var line in _input)
        {
            // Split by :
            var twopart = line.Split(":");
            var getIndex = twopart[0].Split(" ")[1];
            GameIndex = int.Parse(getIndex);

            //   Split line by ,
            var itemSet = twopart[1].Split(",;".ToCharArray(), StringSplitOptions.None);
            //   per item get color and nr
            bool lineIsOk = true;
            foreach (var item in itemSet)
            {
                //   Per line -> per item -> check condition
                var countColor = item.Trim().Split(' ');
                var count = Int32.Parse(countColor[0]);
                var color = countColor[1];
                var checkValue = conditionColorCount.GetValueOrDefault(color);
                if (count > checkValue)
                {
                    lineIsOk &= false;
                }
            }

            //   true = ok => +index
            //   false = nok
            if (lineIsOk)
            {
                answer += GameIndex;
            }
        }

        return answer.ToString();
    }
}
