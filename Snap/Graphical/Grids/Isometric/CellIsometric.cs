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

        public CellIsometric(int id) : base(id)
        {

        }
        /*
         * Returns true if the specified point is inside the cell polygon, 
         * else, return false.
         */
        public override bool Contains(Vector2f point)
        {
            float xnew, ynew;
            float xold, yold;
            float x1, y1;
            float x2, y2;
            bool inside = false;

            if (Points.Length < 3)
                return false;

            xold = Points[Points.Length - 1].X;
            yold = Points[Points.Length - 1].Y;

            foreach (Vector2f t in Points)
            {
                xnew = t.X;
                ynew = t.Y;

                if (xnew > xold)
                {
                    x1 = xold;
                    x2 = xnew;
                    y1 = yold;
                    y2 = ynew;
                }
                else
                {
                    x1 = xnew;
                    x2 = xold;
                    y1 = ynew;
                    y2 = yold;
                }

                if ((xnew < point.X) == (point.X <= xold) && (point.Y - (long)y1) * (x2 - x1) < (y2 - (long)y1) * (point.X - x1))
                {
                    inside = !inside;
                }
                xold = xnew;
                yold = ynew;
            }
            return inside;
        }
    }
}
