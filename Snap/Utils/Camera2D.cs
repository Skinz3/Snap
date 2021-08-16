using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Utils
{
    public class Camera2D
    {
        private RenderWindow Window
        {
            get;
            set;
        }
        private View View
        {
            get;
            set;
        }
        public Camera2D(RenderWindow window)
        {
            this.Window = window;
            this.View = Window.GetView();
        }

        public void Move(Vector2f delta)
        {
            this.View.Move(delta);
        }
        public void Update()
        {
            this.Window.SetView(View);
        }
    }
}
