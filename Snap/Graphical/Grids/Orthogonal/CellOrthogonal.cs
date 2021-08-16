using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Snap.Graphical.Grids.Orthogonal
{
    public class CellOrthogonal : Cell
    {
        public const int Size = 50;

        public FloatRect Rectangle
        {
            get;
            set;
        }
        public CellOrthogonal(int id) : base(id)
        {
        }


        public override bool Contains(Vector2f position)
        {
            return Rectangle.Contains(position.X, position.Y);
        }


    }
}
