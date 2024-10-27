using Simulation.Model.Entities;
using Simulation.Model.Map;

namespace Simulation.Model.Actions
{
    internal class TreeSpawnAction : SpawnAction
    {
        public TreeSpawnAction(int population) : base(population)
        {
        }

        protected override Tree CreateEntity(SimulationModel context, Coordinates coordinates)
        {
            return new Tree(coordinates, context.Map);
        }
    }
}
