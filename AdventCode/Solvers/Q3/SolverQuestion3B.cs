using System.Text.RegularExpressions;

namespace AdventCode.Solvers.Q3;

public class SolverQuestion3B : SolverQuestion3ABase, ISolver
{
    public string SolveQuestion()
    {
        // Create matrix of chars
        CreateMatrix();

        // Find Numbers = startPos + Length
        var matrixNumbers = FindNumbersInMatrix();

        OpenFile();
        WriteToFile(_matrix.ContentToString());

        // Check perimeter of Number
        foreach (var matrixNumber in matrixNumbers)
        {
            if (NumberPerimeterWalker.NumberHasSymbolLink(_matrix, matrixNumber, NumberPerimeterWalker.CheckForGearChar))
            {
                matrixNumber.SetHasSymbol();
            }
            else
            {
                // Remove all other numbers
                _matrix.ReplaceMatrixNumberChars(matrixNumber.Point.X, matrixNumber.Point.Y, matrixNumber.Length, '-');
            }
        }

        
        var answer = 0;
        foreach (var matrixNumber in matrixNumbers)
        {
            var linkedMatrixNumber = SearchLinkedMatrixNumber(matrixNumbers, matrixNumber);
            if (linkedMatrixNumber is not null)
            {
                var mul = matrixNumber.Number * linkedMatrixNumber.Number;
                answer += mul;
            }
            else
            {
                _matrix.ReplaceMatrixNumberChars(matrixNumber.Point.X, matrixNumber.Point.Y, matrixNumber.Length, '.');
            }
        }

        // All counted double
        answer /= 2;

        WriteToFile(_matrix.ContentToString());
        CloseFile();

        return answer.ToString();
    }

    private MatrixNumber? SearchLinkedMatrixNumber(List<MatrixNumber> matrixNumbers, MatrixNumber searchMatrixNumber)
    {
        foreach(var matrixNumber in matrixNumbers)
        {
            foreach(var position in searchMatrixNumber.SymbolPositions)
            {
                if (matrixNumber != searchMatrixNumber &&  matrixNumber.SymbolPositions.Contains(position))
                {
                    // Found the connectiong symbol
                    return matrixNumber;
                }    
            }
        }

        return null;
    }

    private List<MatrixNumber> FindNumbersInMatrix()
    {
        var numbers = new List<MatrixNumber>();

        int yPos = 0;
        foreach (var line in _input)
        {
            var result = Regex.Split(line, "[^\\d]").Where(l => l.Length > 0).ToList();
            var startSearchIndex = 0;
            foreach (var number in result)
            {
                var pos = line.IndexOf(number, startSearchIndex);
                numbers.Add(new MatrixNumber(new Point(pos, yPos), number));
                startSearchIndex = pos + number.Length;
            }

            yPos++;
        }

        return numbers;
    }

}
