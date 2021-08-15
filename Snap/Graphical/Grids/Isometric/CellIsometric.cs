using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Graphical.Grids.Isometric
{
    public class CellIsometric : Cell
    {
        public const uint VerticesCount = 8;

        public Vector2f[] Points
        {
            get;
            set;
        }

        private Grid<CellIsometric> Grid
        {
            get;
            set;
        }
        public CellIsometric(Grid<CellIsometric> grid, int id) : base(id)
        {
            this.Grid = grid;
        }

        public override Vertex[] GetLineVertices()
        {
            List<Vertex> result = new List<Vertex>();

            for (int i = 0; i < Points.Length - 1; i++)
            {
                result.Add(new Vertex(Points[i], Grid.BordersColor));
                result.Add(new Vertex(Points[i + 1], Grid.BordersColor));
            }

            result.Add(new Vertex(Points[Points.Length - 1], Grid.BordersColor));
            result.Add(new Vertex(Points[0], Grid.BordersColor));

            return result.ToArray();
        }
    }
}
