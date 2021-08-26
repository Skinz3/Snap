using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.GUI.Widgets
{
    public class Button : UIWidget
    {
        private static Vector2f DefaultSize = new Vector2f(100, 50);

        public override Vector2f Position => Rectangle.Position;

        public RectangleShape Rectangle
        {
            get;
            set;
        }
        public Text Text
        {
            get;
            private set;
        }

        public Button(Vector2f position)
        {
            this.Rectangle = new RectangleShape(DefaultSize);
            this.Rectangle.Position = position;

            this.Text = new Text();
            this.Text.Position = Position;
        }

        public override void Draw(RenderWindow window)
        {

            window.Draw(Rectangle);
            window.Draw(Text);
        }
    }
}
