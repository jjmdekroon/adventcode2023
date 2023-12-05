namespace AdventCode.Solvers.Q5;

public class InputParser
{
    private int _lineNumber = 0;
    private MapperGroup _currentMappeGroup = null!;
    
    public  List<long> Seeds { get; private set; } = [];

    public List<MapperGroup> MapperGroups { get; private set; } = [];

    // Reads and parses the data
    // 1)  the seeds
    // 2..n) the mapper group data
    //       contains: header + data(source, dest, count)
    public void Parse(string line)
    {
        if (string.IsNullOrEmpty(line))
        {
            // Discard empty lines
            return;
        }

        _lineNumber++;
        if (_lineNumber == 1)
        {
            var headerSplit = line.Split(':');
            string seedsLine = headerSplit[1].Trim();

            Seeds = seedsLine
                .Split(' ')
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s => long.Parse(s))
                .ToList();
            
            return;
        }

        ParseMappingData(line);
    }


    private void ParseMappingData(string line)
    {
        if (line.Contains(':'))
        {
            var headerSplit = line.Split(' ');
            string header = headerSplit[0].Trim();

            // new mappergroup
            _currentMappeGroup = new MapperGroup(header);
            MapperGroups.Add(_currentMappeGroup);
            return;
        }

        var mapper = new Mapper(line);
        _currentMappeGroup.Add(mapper);
    }
}
