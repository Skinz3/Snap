using SFML.Graphics;
using SFML.Window;
using Snap.Scenes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap
{
    public class GameWindow : RenderWindow
    {
        public Color ClearColor
        {
            get;
            set;
        } = Color.White;

        private Scene Scene
        {
            get;
            set;
        }
        public GameWindow(IntPtr handle) : base(handle)
        {
        }

        public GameWindow(VideoMode mode, string title) : base(mode, title)
        {
        }

        public GameWindow(IntPtr handle, ContextSettings settings) : base(handle, settings)
        {
        }

        public GameWindow(VideoMode mode, string title, Styles style) : base(mode, title, style)
        {
        }

        public GameWindow(VideoMode mode, string title, Styles style, ContextSettings settings) : base(mode, title, style, settings)
        {
        }

        public void Open()
        {
            SetActive();

            Closed += ((object sender, EventArgs e) =>
             {
                 DestroyScene();
                 Close();
             });

            while (IsOpen)
            {
                Loop();
            }
        }

        public void SetScene(Scene scene)
        {
            if (Scene != null)
            {
                DestroyScene();
            }

            this.Scene = scene;
            this.Scene.OnCreate(this);
        }
        public void DestroyScene()
        {
            this.Scene?.OnDestroy(this);
            this.Scene = null;
        }
        public T GetScene<T>() where T : Scene
        {
            return (T)Scene;
        }

        private void Loop()
        {
            Clear(ClearColor);
            DispatchEvents();
            Scene?.Draw(this);
            Display();
        }
    }
}
