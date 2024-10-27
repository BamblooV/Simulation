namespace Simulation.Model.Map
{
    internal record Coordinates
    {
        public readonly int Row;
        public readonly int Col;

        public Coordinates(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public override string ToString()
        {
            return $"Simulation.Map.Coordinates {{ Row: {Row}; Col: {Col} }}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Col);
        }


    }
}
