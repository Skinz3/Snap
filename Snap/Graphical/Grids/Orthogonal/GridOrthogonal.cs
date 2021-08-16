using SFML.Graphics;
using SFML.System;
using Snap.Graphical.Grids.Isometric;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Graphical.Grids.Orthogonal
{
    public class GridOrthogonal : Grid<CellOrthogonal>
    {
        public GridOrthogonal(RenderWindow window, Vector2f position, int width, int height, Color bordersColor, bool optimize = false) :
            base(window, position, width, height, bordersColor, optimize)
        {

        }

        public override void BuildCells()
        {
            this.Cells = new CellOrthogonal[Width * Heigth];

            int id = 0;

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Heigth; j++)
                {
                    Cells[id] = new CellOrthogonal(id);

                    float x = (i * CellOrthogonal.Size) + Position.X;
                    float y = (j * CellOrthogonal.Size) + Position.Y;
                    Cells[id].SetRectangle(new FloatRect(x, y, CellOrthogonal.Size, CellOrthogonal.Size));

                    id++;
                }
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
