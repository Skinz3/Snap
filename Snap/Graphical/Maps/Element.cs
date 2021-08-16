using SFML.Graphics;
using SFML.System;
using Snap.Graphical.Textures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Graphical.Maps
{
    public class Element : IDisposable, IDrawable
    {
        private TextureRecord TextureRecord
        {
            get;
            set;
        }
        public string SpriteName
        {
            get
            {
                return TextureRecord.Name;
            }
        }
        public Sprite Sprite
        {
            get;
            private set;
        }

        public Vector2f Position => Sprite.Position;

        public Element(Vector2f position, TextureRecord record, Vector2f scale)
        {
            TextureRecord = record;
            Sprite = TextureRecord.CreateSprite();
            Sprite.Position = position;
            Sprite.Scale = scale;
        }
        public Element()
        {

        }

        public void Dispose()
        {
            Sprite.Dispose();
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(Sprite);
        }
    }
}
