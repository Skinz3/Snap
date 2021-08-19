using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Utils.Cameras
{
    public class Camera2D
    {
        protected RenderWindow Window
        {
            get;
            private set;
        }
        public View View
        {
            get;
            private set;
        }
        public Camera2D(RenderWindow window)
        {
            this.Window = window;
            this.View = Window.GetView();
        }
        public void Zoom(float factor)
        {
            this.View.Zoom(factor);
        }
        public void Move(Vector2f delta)
        {
            this.View.Move(delta);
        }
        public virtual void Update()
        {
            this.Window.SetView(View);
        }
    }
}
