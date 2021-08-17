using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap
{
    public abstract class Renderer
    {
        public RenderWindow Window
        {
            get;
            private set;
        }

        public virtual Color ClearColor => Color.White;

        public Renderer(VideoMode mode, string title, ContextSettings settings, Styles styles = Styles.Default)
        {
            this.Window = new RenderWindow(mode, title, styles, settings);
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
            Window.Display();
        }

        protected abstract void Draw();

    }
}
