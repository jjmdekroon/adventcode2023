namespace AdventCode.Solvers.Q10
{
    internal class PathSearcher
    {
        private IslandMatrix matrix;
        private (int, int) startCell;
        private (int, int) directon;

        public PathSearcher(IslandMatrix matrix, (int, int) startCell, (int, int) directon)
        {
            this.matrix = matrix;
            this.startCell = startCell;
            this.directon = directon;
        }

        public (int, int)? SearchNext((int, int) curentCell)
        {

            // No Path found anymore
            return null;
        }
    }
}