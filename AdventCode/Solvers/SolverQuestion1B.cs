

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventCode.Solvers;

internal class SolverQuestion1B : SolverBase, ISolver
{
    private string[] NumberTextGroup =
    {
        "one",
        "two",
        "three",
        "four",
        "five",
        "six",
        "seven",
        "eight",
        "nine"
    };

    private string[] NumberGroup =
    {
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9"
    };


    public string SolveQuestion()
    {
        OpenFile();

        var answer = 0;

        WriteToFile("line;newine;number");

        foreach (var line in _input)
        {
            var newLine = ReplaceTextWithNumbers(line);
            var number = LineToNumber(newLine);
            answer += number;

            WriteToFile($"{line};{newLine};{number}");
        }

        CloseFile();

        return answer.ToString();
    }

    private string ReplaceTextWithNumbers(string line)
    {
        var firstNumberAsString = string.Empty;
        var lastNumberAsString = string.Empty;

        // First occurence of a number either as number or as text
        var (indexInLine, foundText) = GetFirstIndexOfStringsInString(NumberGroup, line);
        if (indexInLine != -1)
        {
            firstNumberAsString = foundText;
        }
        var (indexInLine2, foundText2) = GetFirstIndexOfStringsInString(NumberTextGroup, line);
        if (indexInLine == -1 || (indexInLine2 != -1 && indexInLine2 < indexInLine))
        {
            firstNumberAsString = foundText2;
        }

        // Last occurence of a number either as number or as text
        (indexInLine, foundText) = GetLastIndexOfStringsInString(NumberGroup, line);
        if (indexInLine != -1)
        {
            lastNumberAsString = foundText;
        }
        (indexInLine2, foundText2) = GetLastIndexOfStringsInString(NumberTextGroup, line);
        if (indexInLine == -1 || (indexInLine2 != -1 && indexInLine2 > indexInLine))
        {
            lastNumberAsString = foundText2;
        }

        var convertedLine = line;
        if (!string.IsNullOrEmpty(firstNumberAsString))
        {
            var number = StringToNumber(firstNumberAsString);
            convertedLine = convertedLine.Replace(firstNumberAsString, number.ToString());
        }

        if (!string.IsNullOrEmpty(lastNumberAsString))
        {
            var number = StringToNumber(lastNumberAsString);
            convertedLine = convertedLine.Replace(lastNumberAsString, number.ToString());
        }

        return convertedLine;
    }

    private int StringToNumber(string numberAsString)
    {
        if (NumberTextGroup.Contains(numberAsString))
        {
            var index = Array.IndexOf(NumberTextGroup, numberAsString);
            return index + 1;
        }

        if (NumberGroup.Contains(numberAsString))
        {
            return Int32.Parse(numberAsString);
        }


        return -1;
    }
}
