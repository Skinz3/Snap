using SFML.Graphics;
using SFML.System;
using Snap.Grids.Isometric;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Grids.Orthogonal
{
    public class GridOrthogonal : Grid
    {
        private int CellSize
        {
            get;
            set;
        }
        public GridOrthogonal(RenderWindow window, Vector2f position, Vector2i size, Color bordersColor, int cellSize, bool optimize = false) :
            base(window, position, size, bordersColor, optimize)
        {
            this.CellSize = cellSize;
        }

        protected override void BuildCells()
        {
            this.Cells = new CellOrthogonal[CellsCount];

            for (int id = 0; id < CellsCount; id++)
            {
                int x = id % Size.X;
                int y = (id - x) / Size.X;

                Vector2f position = new Vector2f((x * CellSize) + Position.X, (y * CellSize) + Position.Y);
                CellOrthogonal cell = new CellOrthogonal(id, x, y, CellSize);
                cell.SetRectangle(new FloatRect(position.X, position.Y, CellSize, CellSize));
                Cells[id] = cell;
            }

        }

        protected override void BuildVertexBuffer()
        {
            List<Vertex> vertices = new List<Vertex>();

            for (int x = 0; x < (Size.X + 1) * CellSize; x += CellSize)
            {
                vertices.Add(new Vertex(new Vector2f(Position.X + x, Position.Y), BordersColor));

                vertices.Add(new Vertex(new Vector2f(Position.X + x, Position.Y + (Size.Y * CellSize)), BordersColor));
            }

            for (int y = 0; y < (Size.Y + 1) * CellSize; y += CellSize)
            {
                vertices.Add(new Vertex(new Vector2f(Position.X, Position.Y + y), BordersColor));
                vertices.Add(new Vertex(new Vector2f(Position.X + (Size.X * CellSize), Position.Y + y), BordersColor));
            }

            this.GridBuffer = new VertexBuffer((uint)vertices.Count, PrimitiveType.Lines, VertexBuffer.UsageSpecifier.Static);
            this.GridBuffer.Update(vertices.ToArray(), (uint)vertices.Count, 0);
        }
    }
}
