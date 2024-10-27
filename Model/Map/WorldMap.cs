using Simulation.Model.Entities;

namespace Simulation.Model.Map
{
    internal class WorldMap
    {
        private Dictionary<Coordinates, Entity> Cells = new();
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
            Cells.Add(coordinates, entity);
        }

        public void RemoveEntity(Coordinates coordinates)
        {
            CheckCoordinates(coordinates);
            Cells.Remove(coordinates);
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

            if (Cells.TryGetValue(coordinates, out var entity)) return entity;

            return null;
        }

        public bool IsCellEmpty(Coordinates coordinates)
        {
            CheckCoordinates(coordinates);

            return Cells.ContainsKey(coordinates);
        }
    }
}
