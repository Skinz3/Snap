using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Utils
{
    public class KeyboardCamera
    {
        private Camera2D Camera2D
        {
            get;
            set;
        }

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

        public KeyboardCamera(RenderWindow window, float speed)
        {
            this.Camera2D = new Camera2D(window);
            this.KeysMapping = new Dictionary<Keyboard.Key, Vector2f>()
            {
                { Keyboard.Key.Z,new Vector2f(0,-1) },
                { Keyboard.Key.Q,new Vector2f(-1,0) },
                { Keyboard.Key.S,new Vector2f(0,1) },
                { Keyboard.Key.D,new Vector2f(1,0) },
            };

            this.Speed = speed;


        }


        public void Update()
        {
            Camera2D.Update();

            foreach (var pair in KeysMapping)
            {
                if (Keyboard.IsKeyPressed(pair.Key))
                {
                    Camera2D.Move(pair.Value * Speed);
                }
            }
        }
    }
}
