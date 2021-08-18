using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Snap.Grids.Orthogonal
{
    public class CellOrthogonal : Cell
    {
        private FloatRect Rectangle
        {
            get;
            set;
        }

        public override Vector2f Center => new Vector2f(Rectangle.Left + (Rectangle.Width / 2f), Rectangle.Top + (Rectangle.Width / 2f));

        public override Vector2f Position => new Vector2f(Rectangle.Left, Rectangle.Top);

        public CellOrthogonal(int id, int x, int y) : base(id, x, y)
        {

        }

        public void SetRectangle(FloatRect rectangle)
        {
            this.Rectangle = rectangle;
        }

        public override bool Contains(Vector2f position)
        {
            return Rectangle.Contains(position.X, position.Y);
        }
    }
}
