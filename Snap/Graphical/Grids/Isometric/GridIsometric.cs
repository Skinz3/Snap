using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Graphical.Grids.Isometric
{
    public class GridIsometric : Grid<CellIsometric>
    {
        private const int CellWidth = 86;

        private const int CellHeigth = 43;

        public GridIsometric(RenderWindow window, Vector2f position, int width, int height, Color bordersColor, bool optimize = false) :
            base(window, position, width, height, bordersColor, optimize)
        {

        }

        public override void BuildCells()
        {
            this.Cells = new CellIsometric[Width * Heigth * 2];

            for (int id = 0; id < Cells.Length; id++)
            {
                Cells[id] = new CellIsometric(id);
            }

            int cellId = 0;
            float cellWidth = CellWidth;
            float cellHeight = CellHeigth;
            float offsetX = Position.X;
            float offsetY = Position.Y;

            float midCellHeight = cellHeight / 2;
            float midCellWidth = cellWidth / 2;

            for (float y = 0; y < (2 * Heigth); y += 1)
            {
                if (y % 2 == 0)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        var left = new Vector2f(offsetX + x * cellWidth, offsetY + y * midCellHeight + midCellHeight);
                        var top = new Vector2f(offsetX + x * cellWidth + midCellWidth, offsetY + y * midCellHeight);
                        var right = new Vector2f(offsetX + x * cellWidth + cellWidth, offsetY + y * midCellHeight + midCellHeight);
                        var down = new Vector2f(offsetX + x * cellWidth + midCellWidth, offsetY + y * midCellHeight + cellHeight);

                        Cells[cellId++].Points = new[] { left, top, right, down };
                    }
                }
                else
                {
                    for (int x = 0; x < Width; x++)
                    {
                        var left = new Vector2f(offsetX + x * cellWidth + midCellWidth, offsetY + y * midCellHeight + midCellHeight);
                        var top = new Vector2f(offsetX + x * cellWidth + cellWidth, offsetY + y * midCellHeight);
                        var right = new Vector2f(offsetX + x * cellWidth + cellWidth + midCellWidth, offsetY + y * midCellHeight + midCellHeight);
                        var down = new Vector2f(offsetX + x * cellWidth + cellWidth, offsetY + y * midCellHeight + cellHeight);


                        Cells[cellId++].Points = new[] { left, top, right, down };
                    }
                }
            }
        }

        public override void BuildVertexBuffer()
        {
            const uint verticesPerCells = 8;

            this.GridBuffer = new VertexBuffer(verticesPerCells * (uint)Cells.Length, PrimitiveType.Lines, VertexBuffer.UsageSpecifier.Static);

            uint i = 0;

            foreach (var cell in Cells)
            {
                uint j = 0;

                Vertex[] vertices = new Vertex[verticesPerCells];

                for (int w = 0; w < cell.Points.Length - 1; w++)
                {
                    vertices[j++] = new Vertex(cell.Points[w], BordersColor);
                    vertices[j++] = new Vertex(cell.Points[w + 1], BordersColor);
                }

                vertices[j++] = new Vertex(cell.Points[cell.Points.Length - 1], BordersColor);
                vertices[j++] = new Vertex(cell.Points[0], BordersColor);

                this.GridBuffer.Update(vertices, (uint)vertices.Length, i);
                i += verticesPerCells;
            }
        }
    }
}
