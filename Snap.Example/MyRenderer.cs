using SFML.Graphics;
using SFML.Window;
using Snap.Graphical;
using Snap.Graphical.Grids.Isometric;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Example
{
    public class MyRenderer : Renderer
    {
        GridIsometric Grid
        {
            get;
            set;
        }

        public MyRenderer(VideoMode mode, string title, ContextSettings settings, Styles styles = Styles.Default) : base(mode, title, settings, styles)
        {
            this.Grid = new GridIsometric(new SFML.System.Vector2f(100, 100), 10, 10, Color.Black);
        }

        protected override void Draw()
        {
            this.Grid.Draw(Window);
        }
    }
}
