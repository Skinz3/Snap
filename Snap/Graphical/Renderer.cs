using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Graphical
{
    public abstract class Renderer
    {
        public RenderWindow Window
        {
            get;
            private set;
        }

        private Clock Clock
        {
            get;
            set;
        }
        public virtual Color ClearColor => Color.White;

        public Renderer(VideoMode mode, string title, ContextSettings settings, Styles styles = Styles.Default)
        {
            this.Window = new RenderWindow(mode, title, styles, settings);
            this.Clock = new Clock();
        }

        public void Display()
        {
            Window.SetActive();

            Window.Closed += ((object sender, EventArgs e) =>
            {
                Window.Close();
            });

            while (Window.IsOpen)
            {
                Loop();
            }
        }

        private void Loop()
        {
            Window.Clear(ClearColor);
            Window.DispatchEvents();
            Draw();
            var fps = 1 / (Clock.ElapsedTime.AsMilliseconds() * 0.001);
            Window.SetTitle("FPS : " + (int)fps);
            Clock.Restart();
            Window.Display();

        }

        protected abstract void Draw();

    }
}
