using System.Collections.Generic;

namespace AdventCode.Solvers.Q8;

public class SolverQuestion8B : SolverBase, ISolver
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

        int steps = 0;
        int index = 0;
        var keysEndingWithA = searchList.Where(s => s.Key.EndsWith('A')).ToList();
        Dictionary<string, string> fromToKeyList = [];
        foreach (var item in keysEndingWithA)
        {
            fromToKeyList.Add(item.Key, item.Key);
        }

        var endsSearch = true;
        do
        {
            var command = commands[index++];
            if (index == commands.Length)
            {
                index = 0;
            }

            var newFromToKeyList = new Dictionary<string, string>();
            endsSearch = true;
            foreach (var item in fromToKeyList)
            {
                var step = searchList[item.Value];

                var nextKey = command == 'L'
                    ? step.Item1
                    : step.Item2;

                newFromToKeyList.Add(item.Value, nextKey);
                
                endsSearch &= nextKey.EndsWith('Z');
            }

            fromToKeyList = newFromToKeyList;

            steps++;

        } while (!endsSearch);

        return steps.ToString();
    }
}
