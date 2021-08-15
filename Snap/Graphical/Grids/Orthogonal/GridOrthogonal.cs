using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Graphical.Grids.Orthogonal
{
    public class GridOrthogonal : Grid<CellOrthogonal>
    {
        public GridOrthogonal(Vector2f position, int width, int height, Color bordersColor) : base(position, width, height, bordersColor)
        {

        }

        public override void BuildCells()
        {
            throw new NotImplementedException();
        }

        public override void BuildVertexBuffer()
        {
            throw new NotImplementedException();
        }
    }
}
