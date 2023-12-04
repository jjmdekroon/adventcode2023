

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventCode.Solvers.Q3;

public class SolverQuestion3A : SolverBase, ISolver
{
    private Matrix? _matrix;
    public string SolveQuestion()
    {
        // Create matrix of chars
        CreateMatrix();

        // Find Numbers = startPos + Length
        var matrixNumbers = FindNumbersInMatrix();


        OpenFile();
        WriteToFile(_matrix?.ContentToString());

        // Check perimeter of Number
        foreach (var matrixNumber in matrixNumbers)
        {
            if (NumberPerimeterWalker.NumberHasSymbolLink(_matrix, matrixNumber))
            {
                var nr = matrixNumber.Number;
                _matrix?.ReplaceMatrixNumberChars(matrixNumber.Point.X, matrixNumber.Point.Y, matrixNumber.Length, '-');
                matrixNumber.SetHasSymbol();
            }
        }

        WriteToFile(_matrix?.ContentToString());
        CloseFile();

        var answer = 0;
        foreach (var matrixNumber in matrixNumbers)
        {
            if (matrixNumber.HasSymbol)
            {
                answer += matrixNumber.Number;
            }
        }
        // If no symbox remove number
        // Add all numbers in Matrix

        return answer.ToString();
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

    private void CreateMatrix()
    {
        var arrayWidth = GetArrayLengthFromFirstLine();
        var arrayLength = _input.Length;

        _matrix = new Matrix(arrayWidth, arrayLength);
        var indexY = 0;
        foreach(var line in _input)
        {
            var lineCharArray = line.ToCharArray(0, arrayWidth);
            int indexX = 0;
            foreach(char c in lineCharArray)
            {
                _matrix.SetAt(indexX, indexY, c);
                indexX++;
            }

            indexY++;
        }
    }

    private int GetArrayLengthFromFirstLine()
    {
        var firstLine = _input.FirstOrDefault();
        if (firstLine is null)
        {
            return 0;
        }

        return firstLine.ToArray().Length;
    }
}
