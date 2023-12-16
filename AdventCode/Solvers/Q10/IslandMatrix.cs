

namespace AdventCode.Solvers.Q10
{
    public class IslandMatrix
    {
        private readonly int _length;
        private readonly int _height;

        private List<List<char>> _content = [];

        public IslandMatrix(int length, int height)
        {
            _length = length;
            _height = height;
        }

        public void AddRow(string line)
        {
            _content.Add(line.ToList());            
        }

        internal (int, int) GetStartCell(char startCellContent)
        {
            foreach(var row in _content)
            {
                foreach (var cell in row)
                {
                    if (cell.Equals(startCellContent))
                    {
                        int rowIndex = _content.IndexOf(row);
                        int colIndex = row.IndexOf(cell);
                        return (rowIndex, colIndex);
                    }
                }
            }

            throw new Exception("No Start cell found");
        }
    }
}