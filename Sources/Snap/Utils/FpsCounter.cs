using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Utils
{
    public class FpsCounter
    {
        public float FPS
        {
            get;
            private set;
        }
        private Clock Clock
        {
            get;
            set;
        }
        public FpsCounter()
        {
            this.Clock = new Clock();
        }

        public void Update()
        {
            this.FPS = 1.0f / Clock.Restart().AsSeconds();
            this.Clock.Restart();
        }
    }
}
