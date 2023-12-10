namespace AdventCode.Solvers;

public class SolverBase
{
    private StreamWriter? _output;

    protected string _originalInput = string.Empty;
    protected string[] _input = Array.Empty<string>();


    public void SetInput(string input)
    {
        _originalInput = input;
        _input = input
            .Split(Environment.NewLine)
            .Where(l => !string.IsNullOrEmpty(l))
            .ToArray();
    }

    protected void OpenFile()
    {
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        _output = new StreamWriter(Path.Combine(docPath, $"QuestionResult.csv"));
    }

    protected void WriteToFile(string line)
    {
        _output?.WriteLine(line);
    }

    protected void CloseFile()
    {
        _output?.Close();
    }


    protected static int LineToNumber(string line)
    {
        var onlyNumbers = new String(line.Where((c) => Char.IsDigit(c)).ToArray());
        var collectedNumbers = string.Empty;
        var numberOfChars = onlyNumbers.ToArray().Count();
        if (numberOfChars == 1)
        {
            // copy that one char
            collectedNumbers = onlyNumbers + onlyNumbers;

        }
        else if (numberOfChars == 2)
        {
            // 2 number convert it
            collectedNumbers = onlyNumbers;
        }
        else if (numberOfChars > 2)
        {
            // Get first and last char
            collectedNumbers = onlyNumbers.First().ToString() + onlyNumbers.Last().ToString();
        }

        return Int32.Parse(collectedNumbers);
    }

    protected static (int, string) GetFirstIndexOfStringsInString(string[] stringGroup, string line)
    {
        var foundText = string.Empty;
        var foundPosition = line.Length + 1;
        foreach(var item in stringGroup)
        {
            var positionInString = line.IndexOf(item);
            if (positionInString >= 0 && positionInString < foundPosition)
            {
                foundText = item;
                foundPosition = positionInString;
            }
        }
        
        if(string.IsNullOrEmpty(foundText))
        {
            return (-1, string.Empty);
        }

        return (foundPosition, foundText);
    }

    protected static (int, string) GetLastIndexOfStringsInString(string[] stringGroup, string line)
    {
        var foundText = string.Empty;
        var foundPosition = -1;
        foreach (var item in stringGroup)
        {
            var positionInString = line.LastIndexOf(item);
            if (positionInString >= 0 && positionInString > foundPosition)
            {
                foundText = item;
                foundPosition = positionInString;
            }
        }

        if (string.IsNullOrEmpty(foundText))
        {
            return (-1, string.Empty);
        }
        
        return (foundPosition, foundText);
    }

}