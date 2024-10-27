using Simulation.Model.Actions;
using Simulation.Model.Entities;
using Simulation.Model.Map;

namespace Simulation.Model
{
    internal sealed class SimulationModel
    {
        public int TurnCounter { get; private set; } = 0;
        public int RoundCounter { get; private set; } = 0;

        public readonly WorldMap Map;
        private Dictionary<Entity, Coordinates> EntitiesCoordinates = new();
        private List<Actions.Action> InitActions = new()
        {
            new RockSpawnAction(1),
            new TreeSpawnAction(2),
            new GrassSpawnAction(4),
        };

        public SimulationModel(WorldMap map)
        {
            Map = map;

            Initialize();
        }

        public void AddEntity(Entity entity)
        {
            var randomCoordinates = Map.GetRandomEmtyCell();

            if (randomCoordinates == null) return;

            entity.DestroyHandler += RemoveEntity;
            EntitiesCoordinates.Add(entity, randomCoordinates);
            Map.PlaceEntity(entity, randomCoordinates);
        }

        private void Initialize()
        {
            foreach (var action in InitActions)
            {
                action.Execute(this);
            }
        }

        private void RemoveEntity(Entity entity)
        {
            EntitiesCoordinates.TryGetValue(entity, out var coordinates);
            EntitiesCoordinates.Remove(entity);

            if (coordinates is null) return;

            Map.RemoveEntity(coordinates);
        }
    }
}
