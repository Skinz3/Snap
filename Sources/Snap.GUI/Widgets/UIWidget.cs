using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.GUI.Widgets
{
    public abstract class UIWidget : IDrawable
    {
        public abstract Vector2f Position
        {
            get;
        }

        public abstract void Draw(RenderWindow window);
    }
}
