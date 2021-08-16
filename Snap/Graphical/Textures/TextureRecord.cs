using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Graphical.Textures
{
    public class TextureRecord
    {
        private const bool PixelInterpolation = false;

        public string Path
        {
            get;
            set;
        }
        public string Name
        {
            get
            {
                return System.IO.Path.GetFileNameWithoutExtension(Path);
            }
        }
        public bool Loaded
        {
            get
            {
                return Texture != null;
            }
        }
        public Texture Texture
        {
            get;
            private set;
        }

        public TextureRecord(string path)
        {
            this.Path = path;
        }

        public void Load()
        {
            Texture = new Texture(Path);
            Texture.Smooth = PixelInterpolation;
        }

        public Sprite CreateSprite()
        {
            Sprite result = new Sprite(Texture);
            return result;
        }
    }
}
