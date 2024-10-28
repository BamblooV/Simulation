using Simulation.Model.Entities;
using Simulation.Model.Map;

namespace Simulation.Model.Actions
{
    internal abstract class SpawnAction : Action
    {
        private readonly int Population;

        public SpawnAction(int population) : base()
        {
            Population = population;
        }

        public override void Execute(SimulationModel context)
        {
            for (int i = 0; i < Population; i++)
            {
                if (!context.Map.TryGetRandomEmtyCell(out var emptyCoordinates)) return;
                
                var newEntity = CreateEntity(context, emptyCoordinates);
                context.Map.PlaceEntity(newEntity, emptyCoordinates);
            }
        }

        protected abstract Entity CreateEntity(SimulationModel context, Coordinates coordinates);
    }
}
