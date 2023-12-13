using System.Collections.Generic;
using System.Numerics;

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

        // Search start key's
        int index = 0;
        var keysEndingWithA = searchList.Where(s => s.Key.EndsWith('A')).ToList();
        Dictionary<string, string> fromToKeyList = [];
        foreach (var item in keysEndingWithA)
        {
            fromToKeyList.Add(item.Key, item.Key);
        }

        // Find extra steps to be taken for every start key
        ulong minimalSteps = int.MaxValue;
        ulong deltaSteps = 0;
        var cycles = new List<ulong>();
        var foundDeltas = new List<ulong>();
        foreach (var item in keysEndingWithA)
        {
            (var initialSteps, deltaSteps) = StepFinder.Search(item.Key, searchList, commands);
            if (initialSteps < minimalSteps)
            {
                minimalSteps = initialSteps;
            }
            cycles.Add(initialSteps);
            foundDeltas.Add(deltaSteps);
        }

        // Search minimal value for divider
        var answer =  foundDeltas.First();
        for (int i = 1; i < foundDeltas.Count; i++)
        {
            var val2 = foundDeltas[i];
            answer = Kgv(answer, val2);
        }


        return answer.ToString();
    }

    private static ulong Kgv(ulong a, ulong b)
    {
        var ggd = GGD(a, b);
        return (a * b) / ggd;
    }

    public static ulong GGD(ulong a, ulong b)
    {
        return b == 0
            ? a
            : GGD(b, a % b);
    }
}
