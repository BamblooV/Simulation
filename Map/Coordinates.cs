
namespace Simulation.Map
{
    internal record Coordinates
    {
        public int Row { get; }
        public int Col { get; }

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
