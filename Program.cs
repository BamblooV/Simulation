using Simulation.Controller;
using Simulation.Model;
using Simulation.Model.Entities;
using Simulation.Model.Map;
using Simulation.Model.PathFinding;
using Simulation.View;

namespace Simulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var view = new ConsoleView();
            var map = new WorldMap(10, 10);
            var pathFinder = new PathFinderAStar(map);

            Coordinates startCoordinates = new(7, 2);
            Coordinates finishCoordinates = new(1, 8);

            map.PlaceEntity(new Grass(startCoordinates, map), startCoordinates);
            map.PlaceEntity(new Rock(new(4, 2), map), new(4, 2));
            map.PlaceEntity(new Rock(new(4, 3), map), new(4, 3));
            map.PlaceEntity(new Rock(new(4, 4), map), new(4, 4));
            map.PlaceEntity(new Rock(new(4, 5), map), new(4, 5));
            map.PlaceEntity(new Rock(new(5, 5), map), new(5, 5));
            map.PlaceEntity(new Rock(new(6, 5), map), new(6, 5));
            map.PlaceEntity(new Rock(new(7, 5), map), new(7, 5));
            map.PlaceEntity(new Grass(finishCoordinates, map), finishCoordinates);
            view.RenderMap(map);
            foreach (var item in pathFinder.Algorithm(startCoordinates, finishCoordinates))
            {
                if (!map.IsCellEmpty(item)) continue;
                map.PlaceEntity(new Tree(item, map), item);
            }
            view.RenderMap(map);
            //var model = new SimulationModel(map);
            //var controller = new SimulationController(model, view);
        }
    }
}
