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
        public GridOrthogonal(RenderWindow window, Vector2f position, int width, int height, Color bordersColor, bool optimize = false) :
            base(window, position, width, height, bordersColor, optimize)
        {

        }

        public override void BuildCells()
        {
            this.Cells = new CellOrthogonal[Width * Heigth];

            for (int id = 0; id < Width * Heigth; id++)
            {
                int x = id % Width;
                int y = (id - x) / Width;

                Vector2f position = new Vector2f((x * CellOrthogonal.Size) + Position.X, (y * CellOrthogonal.Size) + Position.Y);
                CellOrthogonal cell = new CellOrthogonal(id, x, y);
                cell.SetRectangle(new FloatRect(position.X, position.Y, CellOrthogonal.Size, CellOrthogonal.Size));
                Cells[id] = cell;
            }

        }

        public override void BuildVertexBuffer()
        {
            List<Vertex> vertices = new List<Vertex>();

            for (int x = 0; x < (Width + 1) * CellOrthogonal.Size; x += CellOrthogonal.Size)
            {
                vertices.Add(new Vertex(new Vector2f(Position.X + x, Position.Y), BordersColor));

                vertices.Add(new Vertex(new Vector2f(Position.X + x, Position.Y + (Heigth * CellOrthogonal.Size)), BordersColor));
            }

            for (int y = 0; y < (Heigth + 1) * CellOrthogonal.Size; y += CellOrthogonal.Size)
            {
                vertices.Add(new Vertex(new Vector2f(Position.X, Position.Y + y), BordersColor));
                vertices.Add(new Vertex(new Vector2f(Position.X + (Width * CellOrthogonal.Size), Position.Y + y), BordersColor));
            }

            this.GridBuffer = new VertexBuffer((uint)vertices.Count, PrimitiveType.Lines, VertexBuffer.UsageSpecifier.Static);
            this.GridBuffer.Update(vertices.ToArray(), (uint)vertices.Count, 0);
        }
    }
}
