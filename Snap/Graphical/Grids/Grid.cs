using SFML.Graphics;
using SFML.System;
using Snap.Graphical.Grids;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Graphical.Grids
{
    public abstract class Grid<T> : IDrawable where T : Cell
    {
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
        protected VertexBuffer GridBuffer
        {
            get;
            set;
        }

        public T[] Cells
        {
            get;
            protected set;
        }

        public Color BordersColor
        {
            get;
            private set;
        }

        public Grid(Vector2f position, int width, int height, Color bordersColor)
        {
            this.Position = position;
            this.Width = width;
            this.Heigth = height;
            this.BordersColor = bordersColor;
            this.BuildCells();
            this.BuildVertexBuffer();
        }

        public abstract void BuildCells();

        public abstract void BuildVertexBuffer();

        public void Draw(RenderWindow window)
        {
            GridBuffer.Draw(window, RenderStates.Default);
        }
    }
}
