

namespace AdventCode.Solvers.Q5;

internal class SeedMapper
{
    private List<MapperGroup> _mapperGroups = [];

    public SeedMapper(List<MapperGroup> mapperGroups)
    {
        _mapperGroups = mapperGroups;
    }

    public long MapToLocation(long seed)
    {
        var mapperGroup = _mapperGroups.Where(g => g.SourceName.Equals("seed")).First();
        var soil = mapperGroup.Map(seed);

        mapperGroup = _mapperGroups.Where(g => g.SourceName.Equals("soil")).First();
        var fertilizer = mapperGroup.Map(soil);

        mapperGroup = _mapperGroups.Where(g => g.SourceName.Equals("fertilizer")).First();
        var water = mapperGroup.Map(fertilizer);

        mapperGroup = _mapperGroups.Where(g => g.SourceName.Equals("water")).First();
        var light = mapperGroup.Map(water);

        mapperGroup = _mapperGroups.Where(g => g.SourceName.Equals("light")).First();
        var temperature = mapperGroup.Map(light);

        mapperGroup = _mapperGroups.Where(g => g.SourceName.Equals("temperature")).First();
        var humidity = mapperGroup.Map(temperature);

        mapperGroup = _mapperGroups.Where(g => g.SourceName.Equals("humidity")).First();
        var location = mapperGroup.Map(humidity);

        return location;
    }
}