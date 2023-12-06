namespace AdventCode.Solvers.Q5;

public class MapperInputParser
{
    private MapperGroup _currentMappeGroup = null!;
    public List<MapperGroup> MapperGroups { get; private set; } = [];

    // Reads and parses the data
    // 1)  the seeds
    // 2..n) the mapper group data
    //       contains: header + data(source, dest, count)
    public void Parse(string line)
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

        if (_currentMappeGroup is null)
        {
            throw new ApplicationException("No current mapper");
        }

        var mapper = new Mapper(line);
        _currentMappeGroup.Add(mapper);
    }
}
