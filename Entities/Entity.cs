using Simulation.Map;

namespace Simulation.Entities
{
    internal abstract class Entity
    {
        public Coordinates Coordinates { get; set; }

        public Entity(Coordinates coordinates) => Coordinates = coordinates;
    }
}
