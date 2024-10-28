using Simulation.Model.Map;

namespace Simulation.Model.PathFinding
{
    public enum NodeState { Untestetd, Open, Closed }

    internal class Node
    {
        public bool IsWalkable { get; private set; }
        public Coordinates Coordinates { get; private set; }
        /// <summary>
        /// The length of the path from the start node to this node.
        /// </summary>
        public double G { get; private set; } = 0;
        /// <summary>
        /// The straight-line distance from this node to the end node.
        /// </summary>
        public double H { get; private set; }
        /// <summary>
        /// Estimated total distance/cost.
        /// </summary>
        public double F { get { return G + H; } }
        public NodeState State { get; set; } = NodeState.Untestetd;
        private Node? _parentNode = null;
        public Node? ParentNode
        {
            get => _parentNode;
            set 
            { 
                _parentNode = value;
                if (_parentNode != null)
                {
                    G = _parentNode.G + Coordinates.GetDistance(_parentNode.Coordinates);
                } else
                {
                    G = 0;
                }
            } 
        }

        public Node(Coordinates coordinates, double h, bool walkable)
        {
            Coordinates = coordinates;
            H = h;
            IsWalkable = walkable;
        }
    }
}
