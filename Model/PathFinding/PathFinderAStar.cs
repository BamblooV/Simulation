using Simulation.Model.Map;

namespace Simulation.Model.PathFinding
{
    internal sealed class PathFinderAStar : IPathFindingStrategy<Coordinates>
    {
        private WorldMap Map;
        public PathFinderAStar(WorldMap map)
        {
            Map = map;
        }

        public List<Coordinates> Algorithm(Coordinates start, Coordinates target)
        {
            List<Coordinates> result = new List<Coordinates>();
            var nodesMap = GenerateNodesFromMap(target);
            var startNode = nodesMap[start.Row, start.Col];
            var endNode = nodesMap[target.Row, target.Col];

            bool success = Search(startNode);
            if (success)
            {
                Node node = endNode;
                while (node.ParentNode != null)
                {
                    result.Add(node.Coordinates);
                    node = node.ParentNode;
                }

                result.Reverse();
            }

            return result;

            bool Search(Node from)
            {
                var nextNodes = GetAdjacentWalkableNodes(from, nodesMap);
                nextNodes.Sort((node1, node2) => node1.F.CompareTo(node2.F));
                foreach (var nextNode in nextNodes)
                {
                    if (nextNode.Coordinates == target)
                    {
                        return true;
                    }
                    else
                    {
                        if (Search(nextNode)) return true;
                    }
                }

                return false;
            }
        }

        private Node[,] GenerateNodesFromMap(Coordinates target)
        {
            var nodes = new Node[Map.RowsCount + 1, Map.ColsCount + 1];

            for (int row = 0; row <= Map.RowsCount; row++)
            {
                for (int col = 0; col <= Map.ColsCount; col++)
                {
                    Coordinates coordinates = new(row, col);
                    bool isWalkable = Map.IsCellEmpty(coordinates) || coordinates == target;
                    nodes[row, col] = new Node(coordinates, coordinates.GetDistance(target), isWalkable);
                }
            }

            return nodes;
        }

        private List<Node> GetAdjacentWalkableNodes(Node fromNode, Node[,] nodes)
        {
            var walkableNodes = new List<Node>();
            IEnumerable<Coordinates> nextCoordinates = GatAdjacentCoordinates(fromNode.Coordinates);

            foreach (var coord in nextCoordinates)
            {
                if (!Map.InBoundaries(coord)) continue;

                var node = nodes[coord.Row, coord.Col];

                if (!node.IsWalkable) continue;

                if (node.State == NodeState.Closed) continue;

                if (node.State == NodeState.Open)
                {
                    double traversalCost = node.Coordinates.GetDistance(fromNode.Coordinates);
                    double gTemp = fromNode.G + traversalCost;
                    if (gTemp < node.G)
                    {
                        node.ParentNode = fromNode;
                        walkableNodes.Add(node);
                    }
                }
                else
                {
                    node.ParentNode = fromNode;
                    node.State = NodeState.Open;
                    walkableNodes.Add(node);
                }

            }

            return walkableNodes;
        }

        private IEnumerable<Coordinates> GatAdjacentCoordinates(Coordinates coordinates)
        {
            var result = new List<Coordinates>();

            for (var rowShift = -1; rowShift <= 1; rowShift++)
            {
                for (var colShift = -1; colShift <= 1; colShift++)
                {
                    if (rowShift == 0 && colShift == 0) continue;

                    Coordinates adjacentCoordinate = new(coordinates.Row + rowShift, coordinates.Col + colShift);
                    result.Add(adjacentCoordinate);

                }
            }

            return result;
        }
    }
}
