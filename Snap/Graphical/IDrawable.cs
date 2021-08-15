using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Graphical
{
    public interface IDrawable
    {
        Vector2f Position
        {
            get;
        }
        void Draw(RenderWindow window);
    }
}
