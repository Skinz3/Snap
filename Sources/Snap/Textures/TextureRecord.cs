using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Snap.Textures
{
    public class TextureRecord
    {
        public string FilePath
        {
            get;
            set;
        }
        public string Name => Path.GetFileNameWithoutExtension(FilePath);

        public bool Loaded => Texture != null;

        public Texture Texture
        {
            get;
            private set;
        }

        public TextureRecord(string path)
        {
            this.FilePath = path;
        }

        public void Load()
        {
            Texture = new Texture(FilePath);
            Texture.Smooth = TextureManager.UsePixelInterpolation;
        }
        public void Unload()
        {
            Texture.Dispose();
            Texture = null;
        }
        public Sprite CreateSprite()
        {
            Sprite result = new Sprite(Texture);
            return result;
        }
    }
}
