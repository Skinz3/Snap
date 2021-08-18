using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Snap.Grids;
using Snap.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snap.Grids
{
    public abstract class Grid : IDrawable
    {
        public delegate void MouseEvent(Cell cell);
        public event MouseEvent OnMouseEnter;
        public event MouseEvent OnMouseLeave;
        public event MouseEvent OnMouseRightClick;
        public event MouseEvent OnMouseLeftClick;

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
         * Disabling it improves performance on large grids. 
         */
        private bool HandleEvents
        {
            get;
            set;
        }

        public Cell[] Cells
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
        public Cell HoveredCell
        {
            get;
            private set;
        }

        public Vector2i Size
        {
            get;
            private set;
        }

        public int CellsCount => Size.X * Size.Y;
        /*
         * window : The render window where the grid is drawn
         * position : The position of the screen on the world
         * size : The relative size of the grid (number of rows and columns)
         * bordersColor : The color of the cells borders
         */
        public Grid(RenderWindow window, Vector2f position, Vector2i size, Color bordersColor, bool handleEvents = false)
        {
            this.Window = window;
            this.Position = position;
            this.Size = size;
            this.BordersColor = bordersColor;
            this.HandleEvents = handleEvents;
        }

        public void Build()
        {
            this.BuildCells();
            this.BuildVertexBuffer();

            if (HandleEvents)
            {
                Window.MouseButtonPressed += OnMouseButtonPressed;
                Window.MouseMoved += OnMouseMoved;
            }
        }

        private void OnMouseMoved(object sender, MouseMoveEventArgs e)
        {
            Vector2f position = Window.MapPixelToCoords(new Vector2i(e.X, e.Y));
            Cell cell = Cells.FirstOrDefault(x => x.Contains(position));

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

        public Cell GetNearestCellInDirection(Cell cell, DirectionsEnum direction)
        {
            return GetCellsInDirection(cell, direction, 1).FirstOrDefault();
        }
        public IEnumerable<Cell> GetCellsInDirection(Cell cell, DirectionsEnum directionsEnum, int delta)
        {
            List<Cell> cells = new List<Cell>();

            for (int i = 1; i <= delta; i++)
            {
                switch (directionsEnum)
                {
                    case DirectionsEnum.East:
                        cells.Add(GetCell(cell.X + i, cell.Y));
                        break;
                    case DirectionsEnum.SouthEast:
                        cells.Add(GetCell(cell.X + i, cell.Y + i));
                        break;
                    case DirectionsEnum.South:
                        cells.Add(GetCell(cell.X, cell.Y + i));
                        break;
                    case DirectionsEnum.SouthWest:
                        cells.Add(GetCell(cell.X - i, cell.Y + i));
                        break;
                    case DirectionsEnum.West:
                        cells.Add(GetCell(cell.X - i, cell.Y));
                        break;
                    case DirectionsEnum.NorthWest:
                        cells.Add(GetCell(cell.X - i, cell.Y - i));
                        break;
                    case DirectionsEnum.North:
                        cells.Add(GetCell(cell.X, cell.Y - i));
                        break;
                    case DirectionsEnum.NorthEast:
                        cells.Add(GetCell(cell.X + i, cell.Y - i));
                        break;
                }
            }

            return cells.Where(x => x != null);
        }

        private void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            Vector2f position = Window.MapPixelToCoords(new Vector2i(e.X, e.Y));
            Cell cell = Cells.FirstOrDefault(x => x.Contains(position));

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

        protected abstract void BuildCells();

        protected abstract void BuildVertexBuffer();

        public virtual void Draw(RenderWindow window)
        {
            GridBuffer.Draw(window, RenderStates.Default);
        }
        public Cell GetCell(int id)
        {
            return Cells[id];
        }
        public bool IsInMap(int x, int y)
        {
            return x < Size.X && y < Size.Y && x >= 0 && y >= 0;
        }
        public Cell GetCell(int x, int y)
        {
            if (!IsInMap(x, y))
            {
                return null;
            }
            else
            {
                return GetCell(x + Size.X * y);
            }
        }
    }
}
