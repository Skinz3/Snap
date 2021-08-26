using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap
{
    public abstract class GameWindow
    {
        public RenderWindow Window
        {
            get;
            private set;
        }

        public virtual Color ClearColor => Color.White;

        public GameWindow(VideoMode mode, string title, ContextSettings? settings = null, Styles styles = Styles.Default)
        {
            if (settings.HasValue)
            {
                this.Window = new RenderWindow(mode, title, styles, settings.Value);
            }
            else
            {
                this.Window = new RenderWindow(mode, title, styles);
            }
        }

        public void Open()
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
