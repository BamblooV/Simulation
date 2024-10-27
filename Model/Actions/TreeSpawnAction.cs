using Simulation.Model.Entities;

namespace Simulation.Model.Actions
{
    internal class TreeSpawnAction : SpawnAction
    {
        public TreeSpawnAction(int population) : base(population)
        {
        }

        protected override Entity CreateEntity()
        {
            return new Tree();
        }
    }
}
