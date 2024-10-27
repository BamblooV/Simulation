using Simulation.Model.Entities;

namespace Simulation.Model.Actions
{
    internal class GrassSpawnAction : SpawnAction
    {
        public GrassSpawnAction(int population) : base(population)
        {
        }

        protected override Entity CreateEntity()
        {
            return new Grass();
        }
    }
}
