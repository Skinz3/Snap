using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Snap.Grids.Orthogonal
{
    public class CellOrthogonal : Cell
    {
        /*
         * The size of the square, in pixels
         */
        public const int Size = 20;

        private FloatRect Rectangle
        {
            get;
            set;
        }

        public override Vector2f Center => new Vector2f(Rectangle.Left + (Size / 2f), Rectangle.Top + (Size / 2f));

        public override Vector2f Position => new Vector2f(Rectangle.Left, Rectangle.Top);

        public override Shape Shape
        {
            get;
            set;
        }

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
        public override void BuildShape()
        {
            this.Shape = new RectangleShape(new Vector2f(Size, Size));
            this.Shape.Position = Position;
        }
    }
}
