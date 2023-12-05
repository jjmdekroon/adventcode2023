
namespace AdventCode.Solvers.Q5
{
    public class MapperGroup
    {
        private List<Mapper> _mappers = [];
        public string SourceName { get; private set; }
        public string TargetName { get; private set; }

        public MapperGroup(string header)
        {
            var nameSplit = header
                .Trim()
                .Split('-')
                .ToList();

            SourceName = nameSplit[0];
            TargetName = nameSplit[2];
        }

        public void Add(Mapper mapper)
        {
            _mappers.Add(mapper);
        }

        public long Map(long source)
        {
            var destination = -1L;
            foreach(var mapper in _mappers)
            {
                destination = mapper.Map(source);
                if(destination != source)
                {
                    // if mapping succeeds exit otherwise try another mapper
                    break;
                }
            }

            return destination;
        }
    }
}
