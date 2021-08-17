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

        public int Size => Width * Heigth;

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
        public Cell GetCell(int id)
        {
            return Cells[id];
        }
        public bool IsInMap(int x, int y)
        {
            return x < Width && y < Heigth && x >= 0 && y >= 0;
        }
        public Cell GetCell(int x,int y)
        {
            if (!IsInMap(x, y))
            {
                return null;
            }
            else
            {
                return GetCell(x + Width * y);
            }
        }
    }
}
