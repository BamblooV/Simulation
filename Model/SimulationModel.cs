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
        private List<Actions.Action> InitActions = new()
        {
            new RockSpawnAction(10),
            new TreeSpawnAction(15),
            new GrassSpawnAction(40),
        };

        public SimulationModel(WorldMap map)
        {
            Map = map;

            Initialize();
        }

        private void Initialize()
        {
            foreach (var action in InitActions)
            {
                action.Execute(this);
            }
        }
    }
}
