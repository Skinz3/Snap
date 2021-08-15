using SFML.Graphics;
using SFML.System;
using Snap.Graphical.Grids;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Graphical.Grids
{
    public abstract class Grid : IDrawable
    {
        public event Action<Cell> OnMouseClick;

        public int Width
        {
            get;
            private set;
        }
        public int Heigth
        {
            get;
            private set;
        }
        public Vector2f Position
        {
            get;
            private set;
        }
        private VertexBuffer GridBuffer
        {
            get;
            set;
        }
        public void Draw(RenderWindow window)
        {
            throw new NotImplementedException();
        }
    }
}
