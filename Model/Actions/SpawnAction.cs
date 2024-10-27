using Simulation.Model.Entities;

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
                var newEntity = CreateEntity();
                context.AddEntity(newEntity);
            }
        }

        protected abstract Entity CreateEntity();
    }
}
