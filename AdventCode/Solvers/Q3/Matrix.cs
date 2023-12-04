namespace AdventCode.Solvers.Q3;

public class Matrix
{
    public int Length { get; }
    public int Width { get; }

    public char[,] Content { get; } = null!;

    /// <summary>
    /// x = length
    /// y = widthg
    /// </summary>
    public Matrix(int length, int width)
    {
        Length = length;
        Width = width;

        Content = new char[length, width];
    }

    public void SetAt(int x, int y, char value)
    {
        if (x < 0 || x >= Length)
        {
            throw new ArgumentOutOfRangeException("x", $"value {x} is either <0 or >{Length}");
        }

        if (y < 0 || y >= Length)
        {
            throw new ArgumentOutOfRangeException("x", $"value {y} is either <0 or >{Width}");
        }

        Content[x, y] = value;
    }

    public bool CellContainsAnyOf(int x, int y, string validChars)
    {
        if (x  <0 || y < 0 || x >= Length || y >= Width)
        {
            throw new ArgumentOutOfRangeException();
        }

        return validChars.Contains(Content[x,y]);
    }

    public void ReplaceMatrixNumberChars(int x, int y, int length, char replacment)
    {
        if (x < 0 || y < 0 || x >= Length || y >= Width)
        {
            throw new ArgumentOutOfRangeException();
        }

        for (int i = 0; i < length; i++)
        {
            Content[x+i, y] = replacment;
        }
    }
    public string ContentToString()
    {
        var str = string.Empty;

        for (var y = 0; y < Width; y++)
        {
            for (var x = 0; x < Length; x++)
            {
                str += Content[x, y];
            }
            str += Environment.NewLine;
        }

        return str;
    }
}
