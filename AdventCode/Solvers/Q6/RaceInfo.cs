namespace AdventCode.Solvers.Q6
{
    public class RaceInfo
    {
        private readonly long _totalTime;
        private readonly long _recordDistance;
        private (long, long) _winningDistances;


        public long WaysToWin => _winningDistances.Item2 - _winningDistances.Item1 + 1;


        public RaceInfo(long totalTime, long recordDistance)
        {
            _totalTime = totalTime;
            _recordDistance = recordDistance;

            _winningDistances = CalculateMaxDistance();
        }

        public (long, long) CalculateMaxDistance()
        {
            var minIndex = 0L;
            var maxIndex = 0L;

            var endindex = (_totalTime + 1) / 2L;
            for (long i = 0; i <= endindex && (minIndex <= 0L || maxIndex <= 0L); i++)
            {
                var buttonPress = i;
                var newDistance = buttonPress * (_totalTime - buttonPress);
                if (newDistance > _recordDistance)
                {
                    minIndex = buttonPress;
                }

                // 01234567
                // .... ....
                //   s..s
                //   s
                buttonPress = _totalTime - i;
                newDistance = buttonPress * (_totalTime - buttonPress);
                if (newDistance > _recordDistance)
                {
                    maxIndex = buttonPress;
                }
            }

            return (minIndex, maxIndex);
        }
    }
}