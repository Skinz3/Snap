using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Utils.Cameras
{
    public class KeyboardCamera : Camera2D
    {
        public Dictionary<Keyboard.Key, Vector2f> KeysMapping
        {
            get;
            set;
        }

        public float Speed
        {
            get;
            set;
        }

        public KeyboardCamera(RenderWindow window, float speed) : base(window)
        {
            this.KeysMapping = new Dictionary<Keyboard.Key, Vector2f>()
            {
                { Keyboard.Key.Z,new Vector2f(0,-1) },
                { Keyboard.Key.Q,new Vector2f(-1,0) },
                { Keyboard.Key.S,new Vector2f(0,1) },
                { Keyboard.Key.D,new Vector2f(1,0) },
            };

            this.Window.MouseWheelScrolled += Window_MouseWheelScrolled; 
            this.Speed = speed;
        }

        private void Window_MouseWheelScrolled(object sender, MouseWheelScrollEventArgs e)
        {
            base.Zoom(1 - (e.Delta / 10));
        }

        public override void Update()
        {
            base.Update();

            foreach (var pair in KeysMapping)
            {
                if (Keyboard.IsKeyPressed(pair.Key))
                {
                    base.Move(pair.Value * Speed);
                }
            }
        }
    }
}
