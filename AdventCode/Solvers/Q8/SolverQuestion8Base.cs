namespace AdventCode.Solvers.Q8;

public static class StepFinder
{
    public static (ulong, ulong) Search(string startKey, Dictionary<string, (string, string)> searchList, char[] commands)
    {
        ulong initialSteps = 0;
        bool firstFound = false;
        bool secondFound = false;
        ulong steps = 0;
        int index = 0;
        string key = startKey;
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

            if (firstFound && !secondFound && key.EndsWith('Z'))
            {
                secondFound = true;
            }

            if (!firstFound && key.EndsWith('Z'))
            {
                initialSteps = steps;
                steps = 0;
                firstFound = true;
            }


        } while (!(firstFound && secondFound));

        return (initialSteps, steps);
    }
}
