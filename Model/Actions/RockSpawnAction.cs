using Simulation.Model.Entities;
using Simulation.Model.Map;

namespace Simulation.Model.Actions
{
    internal class RockSpawnAction : SpawnAction
    {
        public RockSpawnAction(int population) : base(population)
        {
        }

        protected override Rock CreateEntity(SimulationModel context, Coordinates coordinates)
        {
            return new Rock(coordinates, context.Map);
        }
    }
}
