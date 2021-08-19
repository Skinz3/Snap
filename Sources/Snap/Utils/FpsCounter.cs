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
        private float LastTime
        {
            get;
            set;
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
            float currentTime = Clock.Restart().AsSeconds();
            this.FPS = 1.0f / (currentTime - LastTime);
            LastTime = currentTime;
            this.Clock.Restart();
        }
    }
}
