namespace Simulation.Model.PathFinding
{
    internal interface IPathFindingStrategy<T>
    {
        public List<T> Algorithm(T start, T target);
    }
}
