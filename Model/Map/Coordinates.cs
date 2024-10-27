namespace Simulation.Model.Map
{
    internal sealed record Coordinates
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

        public int GetDistance(Coordinates coordinates)
        {
            return Convert.ToInt32(
                Math.Round(
                    Math.Sqrt(
                        Math.Pow(coordinates.Row - Row, 2) + Math.Pow(coordinates.Col - Col, 2)
                        )
                    )
                );
        }
    }
}
