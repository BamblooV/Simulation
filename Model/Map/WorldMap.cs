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

        public bool TryGetEntity(Coordinates coordinates, out Entity entity)
        {
            CheckCoordinates(coordinates);

            return Cells.TryGetValue(coordinates, out entity);
        }

        public bool IsCellEmpty(Coordinates coordinates)
        {
            CheckCoordinates(coordinates);

            return !Cells.ContainsKey(coordinates);
        }

        public bool TryGetRandomEmtyCell(out Coordinates coordinates)
        {
            coordinates = null;

            if (EmptyCells.Count == 0) return false;

            var randomIndex = Random.Next(EmptyCells.Count);
            coordinates = EmptyCells[randomIndex];
            EmptyCells.RemoveAt(randomIndex);
            return true;
        }

        public int GetCapacity()
        {
            return RowsCount * ColsCount;
        }

        public IEnumerable<Entity> GetEntriesByCondition(Predicate<KeyValuePair<Coordinates, Entity>> predicate)
        {
            List<Entity> result = new();

            foreach (var entry in Cells)
            {
                if (predicate(entry)) result.Add(entry.Value);
            }

            return result;
        }
    }
}
