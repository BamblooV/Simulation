using Simulation.Model.Map;

namespace Simulation.Model.Entities
{
    internal abstract class Entity
    {
        public Coordinates Coordinates{ get; protected set; }
        protected WorldMap map;

        public Entity(Coordinates coordinates, WorldMap map)
        {
            Coordinates = coordinates;
            this.map = map;
        }

        public void Destroy()
        {
            map.RemoveEntity(Coordinates);
        }
    }
}
