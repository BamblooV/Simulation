using Simulation.Model;
using Simulation.View;

namespace Simulation.Controller
{
    internal class SimulationController
    {
        private SimulationModel Model;
        private ISimulationView View;

        public SimulationController(SimulationModel model, ISimulationView view)
        {
            Model = model;
            View = view;

            view.RenderMap(model.Map);
        }
    }
}
