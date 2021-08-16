using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Snap.Graphical.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snap.Graphical.Grids
{
    public abstract class Grid<T> : IDrawable where T : Cell
    {
        public delegate void MouseEvent(T cell);
        public event MouseEvent OnMouseEnter;
        public event MouseEvent OnMouseLeave;
        public event MouseEvent OnMouseRightClick;
        public event MouseEvent OnMouseLeftClick;

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
        /*
         * No event will be triggered if Optimize is set to false. 
         * (OnMouseOverCell etc ..). 
         * No SFML shape will be drawn (only primitives)
         * Disabling it improves performance on large grids. 
         */
        private bool Optimize
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
        private RenderWindow Window
        {
            get;
            set;
        }
        public T HoveredCell
        {
            get;
            private set;
        }
        public Grid(RenderWindow window, Vector2f position, int width, int height, Color bordersColor, bool optimize = false)
        {
            this.Window = window;
            this.Position = position;
            this.Width = width;
            this.Heigth = height;
            this.BordersColor = bordersColor;
            this.BuildCells();
            this.BuildVertexBuffer();
            this.Optimize = optimize;

            if (!Optimize)
            {
                window.MouseButtonPressed += OnMouseButtonPressed;
                window.MouseMoved += OnMouseMoved;

                foreach (var cell in Cells)
                {
                    cell.BuildShape();
                }
            }
        }

        private void OnMouseMoved(object sender, MouseMoveEventArgs e)
        {
            Vector2f position = Window.MapPixelToCoords(new Vector2i(e.X, e.Y));
            T cell = Cells.FirstOrDefault(x => x.Contains(position));

            if (HoveredCell != null && cell != HoveredCell)
            {
                OnMouseLeave?.Invoke(HoveredCell);

                if (cell != null)
                {
                    OnMouseEnter?.Invoke(cell);
                }
            }

            HoveredCell = cell;
        }

        private void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            Vector2f position = Window.MapPixelToCoords(new Vector2i(e.X, e.Y));
            T cell = Cells.FirstOrDefault(x => x.Contains(position));

            if (cell != null)
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Right))
                {
                    OnMouseRightClick?.Invoke(cell);
                }
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    OnMouseLeftClick?.Invoke(cell);
                }
            }
        }

        public abstract void BuildCells();

        public abstract void BuildVertexBuffer();

        public virtual void Draw(RenderWindow window)
        {
            if (!Optimize)
            {
                foreach (var cell in Cells)
                {
                    cell.DrawShape(window);
                }
            }

            GridBuffer.Draw(window, RenderStates.Default);


        }
    }
}
