using Simulation.Model.Map;
using Simulation.Model.PathFinding;

namespace Simulation.Model.Entities.Creatures
{
    internal abstract class Creature : Entity
    {
        private const int  MINIMAL_DISTANCE = 1;

        public readonly int Initiative;
        public readonly int Velocity;
        public bool IsDead { get; protected set; }
        protected int HealthPoint;
        protected IPathFindingStrategy<Coordinates> PathFinder;

        public Creature(IPathFindingStrategy<Coordinates> pathFinder,
                        Coordinates coordinates,
                        WorldMap map,
                        int initiative,
                        int velocity,
                        int healthPoint) : base(coordinates, map)
        {
            PathFinder = pathFinder;
            Initiative = initiative;
            Velocity = velocity;
            HealthPoint = healthPoint;
        }

        public void MakeTurn()
        {
            if (IsDead) return;

            if (!TryGetNearestPrey(out var nearestPrey)) return;

            var distance = GetDistanceToEntity(nearestPrey);

            if (distance <= MINIMAL_DISTANCE)
            {
                if (TryEat(nearestPrey)) return;
            }
        }

        public void TakeDamage(int damage)
        {
            HealthPoint -= damage;

            if (HealthPoint < 0)
            {
                IsDead = true;
            }
        }

        protected bool TryEat(Entity prey)
        {
            switch (prey)
            {
                case Creature creature:
                    if (creature.IsDead)
                    {
                        creature.Destroy();
                        return true;
                    }
                    return false;
                case Entity entity:
                    entity.Destroy();
                    return true;
                default: 
                    return false;
            }
        }

        protected int GetDistanceToEntity(Entity entity)
        {
            return Coordinates.GetDistance(entity.Coordinates);
        }

        protected bool TryGetNearestPrey(out Entity result)
        {
            result = null;
            int resultDistance = 0;

            var preys = Map.GetEntriesByCondition((entry) => CanEat(entry.Value));

            foreach (var prey in preys)
            {
                if (result is null)
                {
                    result = prey;
                    resultDistance = GetDistanceToEntity(prey);
                    continue;
                }

                var preyDistance = GetDistanceToEntity(prey);

                if (resultDistance > preyDistance)
                {
                    result = prey;
                    resultDistance = preyDistance;
                }
            }

            return result is not null;
        }

        abstract protected bool CanEat(Entity entity);
    }
}
