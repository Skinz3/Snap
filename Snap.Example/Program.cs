using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Snap.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoMode mode = new VideoMode(1920, 1080);
            RenderWindow window = new RenderWindow(mode, "SFML.NET");

            window.Closed += (obj, e) => { window.Close(); };
            window.KeyPressed +=
                (sender, e) =>
                {
                    Window window = (Window)sender;
                    if (e.Code == Keyboard.Key.Escape)
                    {
                        window.Close();
                    }
                };

            Clock clock = new Clock();
            float delta = 0f;
            float angle = 0f;
            float angleSpeed = 90f;

            while (window.IsOpen)
            {
                delta = clock.Restart().AsSeconds();
                angle += angleSpeed * delta;
                window.DispatchEvents();
                window.Clear(Color.White);
                window.Display();
            }
        }
    }
}
