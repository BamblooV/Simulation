namespace Simulation.Model.Entities
{
    internal abstract class Entity
    {
        public readonly Guid Id;
        public delegate void OnDestroy(Entity entity);
        public event OnDestroy? DestroyHandler;

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object? obj)
        {
            return obj is Entity entity &&
                   Id == entity.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"Simulation.Entities.Entity {{ Id: {Id} }}";
        }

        public void Destroy()
        {
            DestroyHandler?.Invoke(this);
        }
    }
}
