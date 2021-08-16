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
        public MyRenderer(VideoMode mode, string title, ContextSettings settings, Styles styles = Styles.Default) : base(mode, title, settings, styles)
        {
            // Create your ressources here
        }

        protected override void Draw()
        {
            // Draw your ressources here
        }
    }
}
