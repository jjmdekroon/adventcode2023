namespace AdventCode.Solvers;

public class SolverQuestion2B : SolverBase, ISolver
{
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

            // Add extra admin:
            var ColorCount = new Dictionary<string, int>()
            {
                { "red", 0 },
                { "green", 0  },
                { "blue", 0  }
            };

            //   Split line by ,
            var itemSet = twopart[1].Split(",;".ToCharArray(), StringSplitOptions.None);
            //   per item get color and nr
            foreach (var item in itemSet)
            {
                //   Per line -> per item -> check condition
                var countColor = item.Trim().Split(' ');
                var count = Int32.Parse(countColor[0]);
                var color = countColor[1];

                if (count > ColorCount[color])
                {
                    ColorCount[color] = count;
                }
            }

            var lineMultiplied = ColorCount["red"] * ColorCount["green"] * ColorCount["blue"];
            answer += lineMultiplied;
        }

        return answer.ToString();
    }
}
