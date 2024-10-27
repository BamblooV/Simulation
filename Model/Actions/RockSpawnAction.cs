using Simulation.Model.Entities;

namespace Simulation.Model.Actions
{
    internal class RockSpawnAction : SpawnAction
    {
        public RockSpawnAction(int population) : base(population)
        {
        }

        protected override Entity CreateEntity()
        {
            return new Rock();
        }
    }
}
