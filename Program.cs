using Simulation.Controller;
using Simulation.Model;
using Simulation.Model.Map;
using Simulation.View;

namespace Simulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var view = new ConsoleView();
            var map = new WorldMap();
            var model = new SimulationModel(map);
            var controller = new SimulationController(model, view);
        }
    }
}
