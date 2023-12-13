
namespace AdventCode.Solvers.Q8;

public class SolverQuestion8A : SolverBase, ISolver
{
    public string SolveQuestion()
    {
        char[] commands = [];
        int lineNumber = 0;
        var searchList = new Dictionary<string, (string, string)>();
        foreach (var line in _input)
        {
            lineNumber++;
            if (lineNumber == 1)
            {
                commands = line.ToArray();
                continue;
            }

            var lineSplit = line.Split('=').Select(s => s.Trim()).ToList();
            var from = lineSplit[0];
            var step1 = lineSplit[1].TrimStart('(').TrimEnd(')').ToString();
            var toLR = step1.Split(',').ToList();

            searchList.Add(from, (toLR[0].Trim(), toLR[1].Trim()));
        }

        var steps = StepFinder.Search("AAA", searchList, commands);

        /*int steps = 0;
        int index = 0;
        string key = "AAA";
        do
        {
            var step = searchList[key];
            var command = commands[index++];

            if (index == commands.Length)
            {
                index = 0;
            }

            key = command == 'L'
                ? step.Item1
                : step.Item2;

            steps++;

        } while (!key.Equals("ZZZ"));*/

        return steps.ToString();
    }

}
