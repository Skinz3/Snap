using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Grids
{
    public abstract class Cell
    {
        public int Id
        {
            get;
            private set;
        }

        public abstract Vector2f Center
        {
            get;
        }

        public abstract Vector2f Position
        {
            get;
        }

        public int X
        {
            get;
            private set;
        }
        public int Y
        {
            get;
            private set;
        }
        public Cell(int id, int x, int y)
        {
            this.Id = id;
            this.X = x;
            this.Y = y;
        }

        public abstract bool Contains(Vector2f position);

        public override string ToString()
        {
            return "Cell (" + Id + ")";
        }
    }
}
