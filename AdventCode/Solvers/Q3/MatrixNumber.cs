
namespace AdventCode.Solvers.Q3;


public class MatrixNumber
{
    public string _numberAsString;

    public Point Point { get; private set; }
    public bool HasSymbol { get; private set; } = false;
    public int Number => int.Parse(_numberAsString);
    public int Length => _numberAsString.Length;
    
    public List<Point> SymbolPositions { get; private set; } = [];

    public MatrixNumber(Point point, string numberAsString)
    {
        Point = point;
        _numberAsString = numberAsString;
    }

    public void SetHasSymbol()
    {
        HasSymbol = true;
    }

    internal void AddLinkedSymbols(List<Point> symbolPositions)
    {
        SymbolPositions = symbolPositions;
    }
}
