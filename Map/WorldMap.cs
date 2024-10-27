using Simulation.Entities;

namespace Simulation.Map
{
    internal class WorldMap
    {
        private Dictionary<Coordinates, Entity> cells = new();
        public readonly int RowsCount = 20; // 0 .. 20
        public readonly int ColsCount = 20; // 0 .. 20

        public WorldMap(int rowsCount, int colsCount) : base()
        {
            RowsCount = rowsCount;
            ColsCount = colsCount;
        }

        public WorldMap() { }

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
            cells.Add(coordinates, entity);
        }

        public void RemoveEntity(Coordinates coordinates)
        {
            CheckCoordinates(coordinates);
            cells.Remove(coordinates);
        }

        public void MoveEntity(Coordinates from, Coordinates to)
        {
            CheckCoordinates(from);
            CheckCoordinates(to);

            var entity = TryGetEntity(from);

            if (entity is null) return;

            RemoveEntity(from);
            PlaceEntity(entity, to);
        }

        public Entity? TryGetEntity(Coordinates coordinates)
        {
            CheckCoordinates(coordinates);

            if (cells.TryGetValue(coordinates, out var entity)) return entity;

            return null;
        }

        public bool IsCellEmpty(Coordinates coordinates)
        {
            CheckCoordinates(coordinates);

            return cells.ContainsKey(coordinates);
        }
    }
}
