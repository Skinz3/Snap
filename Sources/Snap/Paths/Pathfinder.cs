using SFML.System;
using Snap.Core.Collections;
using Snap.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snap.Paths
{
    public struct PathNode
    {
        public int CellId;
        public double F;
        public double G;
        public double H;
        public int Parent;
        public NodeState Status;
    }

    public enum NodeState : byte
    {
        None,
        Open,
        Closed
    }

    public class Pathfinder
    {
        public static int EstimateHeuristic = 1;

        private static readonly DirectionsEnum[] Directions = new[]
        {
            DirectionsEnum.SouthWest,
            DirectionsEnum.NorthWest,
            DirectionsEnum.NorthEast,
            DirectionsEnum.SouthEast,
            DirectionsEnum.South,
            DirectionsEnum.West,
            DirectionsEnum.North,
            DirectionsEnum.East,
        };

        private Grid Grid
        {
            get;
            set;
        }
        private ICellMetaProvider CellMetaProvider
        {
            get;
            set;
        }

        public Pathfinder(Grid grid, ICellMetaProvider cellMetaProvider)
        {
            this.Grid = grid;
            this.CellMetaProvider = cellMetaProvider;
        }


        public IEnumerable<Cell> FindPath(Cell startPoint, Cell endPoint, bool diagonal)
        {
            var success = false;

            var matrix = new PathNode[Grid.Size + 1];
            var openList = new PriorityQueueB<int>(new ComparePfNodeMatrix(matrix));
            var closedList = new List<PathNode>();

            var location = startPoint.Id;

            var counter = 0;

            matrix[location].CellId = location;
            matrix[location].Parent = -1;
            matrix[location].G = 0;
            matrix[location].F = EstimateHeuristic;
            matrix[location].Status = NodeState.Open;

            openList.Push(location);
            while (openList.Count > 0)
            {
                location = openList.Pop();
                var locationPoint = Grid.GetCell(location);

                if (matrix[location].Status == NodeState.Closed)
                    continue;

                if (location == endPoint.Id)
                {
                    matrix[location].Status = NodeState.Closed;
                    success = true;
                    break;
                }

                for (int i = 0; i < (diagonal ? 8 : 4); i++)
                {
                    Cell newLocationCell = Grid.GetNearestCellInDirection(locationPoint, Directions[i]);

                    if (newLocationCell == null)
                        continue;

                    var newLocation = newLocationCell.Id;

                    if (newLocation < 0 || newLocation >= Grid.Size)
                        continue;

                    if (!this.CellMetaProvider.IsWalkable(newLocationCell))
                        continue;

                    double newG = matrix[location].G + 1;

                    if ((matrix[newLocation].Status == NodeState.Open ||
                            matrix[newLocation].Status == NodeState.Closed) &&
                        matrix[newLocation].G <= newG)
                        continue;

                    matrix[newLocation].CellId = newLocation;
                    matrix[newLocation].Parent = location;
                    matrix[newLocation].G = newG;
                    matrix[newLocation].H = GetHeuristic(newLocationCell, endPoint);
                    matrix[newLocation].F = newG + matrix[newLocation].H;

                    openList.Push(newLocation);
                    matrix[newLocation].Status = NodeState.Open;
                }

                counter++;
                matrix[location].Status = NodeState.Closed;
            }

            if (success)
            {
                var node = matrix[endPoint.Id];

                while (node.Parent != -1)
                {
                    closedList.Add(node);
                    node = matrix[node.Parent];
                }

                closedList.Add(node);
            }

            closedList.Reverse();

            return closedList.Select(x => Grid.GetCell(x.CellId));
        }

        public Cell[] FindReachableCells(Cell from, int distance)
        {
            var result = new List<Cell>();
            var matrix = new PathNode[Grid.Size + 1];
            var openList = new PriorityQueueB<int>(new ComparePfNodeMatrix(matrix));
            var location = from.Id;
            var counter = 0;

            if (distance == 0)
                return new[] { from };

            matrix[location].CellId = location;
            matrix[location].Parent = -1;
            matrix[location].G = 0;
            matrix[location].F = 0;
            matrix[location].Status = NodeState.Open;

            openList.Push(location);
            while (openList.Count > 0)
            {
                location = openList.Pop();
                var locationPoint = Grid.GetCell(location);

                if (matrix[location].Status == NodeState.Closed)
                    continue;

                for (int i = 0; i < 4; i++)
                {
                    var newLocationCell = Grid.GetNearestCellInDirection(locationPoint, Directions[i]);

                    if (newLocationCell == null)
                        continue;

                    var newLocation = newLocationCell.Id;

                    if (newLocation < 0 || newLocation >= Grid.Size)
                        continue;

                    if (!this.CellMetaProvider.IsWalkable(newLocationCell))
                        continue;

                    double newG = matrix[location].G + 1;

                    if ((matrix[newLocation].Status == NodeState.Open ||
                            matrix[newLocation].Status == NodeState.Closed) &&
                        matrix[newLocation].G <= newG)
                        continue;

                    matrix[newLocation].CellId = newLocation;
                    matrix[newLocation].Parent = location;
                    matrix[newLocation].G = newG;
                    matrix[newLocation].H = 0;
                    matrix[newLocation].F = newG + matrix[newLocation].H;

                    if (newG <= distance)
                    {
                        result.Add(newLocationCell);
                        openList.Push(newLocation);
                        matrix[newLocation].Status = NodeState.Open;
                    }
                }

                counter++;
                matrix[location].Status = NodeState.Closed;
            }

            return result.ToArray();

        }

        private static double GetHeuristic(Cell pointA, Cell pointB)
        {
            var dxy = new Vector2f(Math.Abs(pointB.X - pointA.X), Math.Abs(pointB.Y - pointA.Y));
            var orthogonalValue = Math.Abs(dxy.X - dxy.Y);
            var diagonalValue = Math.Abs(((dxy.X + dxy.Y) - orthogonalValue) / 2);

            return EstimateHeuristic * (diagonalValue + orthogonalValue + dxy.X + dxy.Y);
        }
        internal class ComparePfNodeMatrix : IComparer<int>
        {
            private readonly PathNode[] m_matrix;

            public ComparePfNodeMatrix(PathNode[] matrix)
            {
                m_matrix = matrix;
            }

            public int Compare(int a, int b)
            {
                if (m_matrix[a].F > m_matrix[b].F)
                {
                    return 1;
                }

                if (m_matrix[a].F < m_matrix[b].F)
                {
                    return -1;
                }
                return 0;
            }

        }
    }
}
