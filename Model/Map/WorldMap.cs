using Simulation.Model.Entities;

namespace Simulation.Model.Map
{
    internal sealed class WorldMap
    {
        private readonly Dictionary<Coordinates, Entity> Cells = new();
        private readonly List<Coordinates> EmptyCells = new();
        private readonly Random Random = new Random();

        public readonly int RowsCount = 20; // 0 .. 20
        public readonly int ColsCount = 20; // 0 .. 20

        public WorldMap(int rowsCount, int colsCount) : base()
        {
            RowsCount = rowsCount;
            ColsCount = colsCount;
        }

        public WorldMap()
        {
            for (int row = 0; row < RowsCount; row++)
            {
                for (int col = 0; col < ColsCount; col++)
                {
                    EmptyCells.Add(new Coordinates(row, col));
                }
            }
        }

        private void CheckCoordinates(Coordinates coordinates)
        {
            var isRowOk = coordinates.Row >= 0 && coordinates.Row <= RowsCount;
            var isColOk = coordinates.Col >= 0 && coordinates.Col <= ColsCount;

            if (isRowOk && isColOk) return;

            throw new ArgumentOutOfRangeException($"Coordinates {coordinates} out of map boundary");
        }

        public void PlaceEntity(Entity entity, Coordinates coordinates)
        {
            CheckCoordinates(coordinates);
            Cells.Add(coordinates, entity);
            EmptyCells.Remove(coordinates);
        }

        public void RemoveEntity(Coordinates coordinates)
        {
            CheckCoordinates(coordinates);
            Cells.Remove(coordinates);
            EmptyCells.Add(coordinates);
        }

        public Entity? TryGetEntity(Coordinates coordinates)
        {
            CheckCoordinates(coordinates);

            if (Cells.TryGetValue(coordinates, out var entity)) return entity;

            return null;
        }

        public bool IsCellEmpty(Coordinates coordinates)
        {
            CheckCoordinates(coordinates);

            return !Cells.ContainsKey(coordinates);
        }

        public Coordinates? GetRandomEmtyCell()
        {
            if (EmptyCells.Count == 0) return null;

            var randomIndex = Random.Next(EmptyCells.Count);
            var randomCell = EmptyCells[randomIndex];
            EmptyCells.RemoveAt(randomIndex);
            return randomCell;
        }

        public int GetCapacity()
        {
            return EmptyCells.Count;
        }
    }
}
