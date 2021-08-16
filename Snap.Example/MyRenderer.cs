using SFML.Graphics;
using SFML.Window;
using Snap.Graphical;
using Snap.Graphical.Grids.Isometric;
using Snap.Graphical.Grids.Orthogonal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Example
{
    public class MyRenderer : Renderer
    {
        GridOrthogonal Grid
        {
            get;
            set;
        }

        public MyRenderer(VideoMode mode, string title, ContextSettings settings, Styles styles = Styles.Default) : base(mode, title, settings, styles)
        {
            this.Grid = new GridOrthogonal(Window, new SFML.System.Vector2f(100, 100), 10, 10, Color.Black, false);
            this.Grid.OnMouseEnter += Grid_OnMouseEnter;
            this.Grid.OnMouseLeave += Grid_OnMouseLeave;
        }

        private void Grid_OnMouseLeave(CellOrthogonal cell)
        {
            cell.Shape.FillColor = Color.Transparent;
        }

        private void Grid_OnMouseEnter(CellOrthogonal cell)
        {
            cell.Shape.FillColor = Color.Blue;
        }

        protected override void Draw()
        {
            this.Grid.Draw(Window);
        }
    }
}
