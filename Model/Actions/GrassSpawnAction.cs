using Simulation.Model.Entities;
using Simulation.Model.Map;

namespace Simulation.Model.Actions
{
    internal class GrassSpawnAction : SpawnAction
    {
        public GrassSpawnAction(int population) : base(population)
        {
        }

        protected override Grass CreateEntity(SimulationModel context, Coordinates coordinates)
        {
            return new Grass(coordinates, context.Map);
        }
    }
}
