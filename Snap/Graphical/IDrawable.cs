using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Graphical
{
    public interface IDrawable
    {
        void Draw(RenderWindow window);
    }
}
