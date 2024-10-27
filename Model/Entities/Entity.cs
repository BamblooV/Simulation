using Simulation.Model.Map;

namespace Simulation.Model.Entities
{
    internal abstract class Entity
    {
        public Coordinates Coordinates{ get; protected set; }
        protected WorldMap Map;

        public Entity(Coordinates coordinates, WorldMap map)
        {
            Coordinates = coordinates;
            Map = map;
        }

        public void Destroy()
        {
            Map.RemoveEntity(Coordinates);
        }
    }
}
