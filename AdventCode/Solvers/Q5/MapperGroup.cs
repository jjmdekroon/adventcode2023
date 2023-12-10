
using System;
using System.Collections.Generic;

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


        public List<(long, long)> MapRange(List<(long, long )> ranges)
        {
            var result = new List<(long, long)>();
            var tempList = new List<(long, long)>();

            result.AddRange(ranges);

            foreach (var mapper in _mappers)
            {
                tempList.Clear();
                tempList.AddRange(result);

                result.Clear();
                foreach (var range in tempList)
                {
                    var mappedRanges = mapper.MapRange(range.Item1, range.Item2);
                    result.AddRange(mappedRanges);
                }
            }

            return result;
        }
    }
}
