using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Graphical.Grids
{
    public abstract class Cell
    {
        private static Color BorderColor = new Color(0, 0, 0, 50);

        public int Id
        {
            get;
            private set;
        }

        public Vector2f Center
        {
            get;
        }

        public Vector2f Position
        {
            get;
        }

        public Cell(int id)
        {
            this.Id = id;
        }

        public abstract bool Contains(Vector2f position);
    }
}
