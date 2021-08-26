using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Scenes
{
    public abstract class Scene : IDrawable
    {
        public abstract void Draw(GameWindow window);

        public abstract void OnCreate(GameWindow window);

        public abstract void OnDestroy(GameWindow window);
    }
}
