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
            ContextSettings settings = new ContextSettings();
            settings.AntialiasingLevel = 7;

            MyRenderer renderer = new MyRenderer(mode, "MyRenderer", settings);

            renderer.Display();
        }
    }
}
