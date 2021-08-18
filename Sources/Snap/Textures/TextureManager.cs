using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Snap.Textures
{
    public class TextureManager
    {
        private static readonly Dictionary<string, TextureRecord> Textures = new Dictionary<string, TextureRecord>();

        public static bool UsePixelInterpolation;

        public static void Initialize(string path, bool usePixelInterpolation = false)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            UsePixelInterpolation = usePixelInterpolation;

            foreach (var file in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories))
            {
                TextureRecord sprite = new TextureRecord(file);
                string name = Path.GetFileNameWithoutExtension(file);
                Textures.Add(name, sprite);
            }
        }
        public static IEnumerable<TextureRecord> FindAll()
        {
            return Textures.Values;
        }
        public static TextureRecord Get(string name)
        {
            TextureRecord textureRecord = null;

            if (!Textures.TryGetValue(name, out textureRecord))
            {
                return null;
            }
            else
            {
                if (!textureRecord.Loaded)
                {
                    textureRecord.Load();
                }

                return textureRecord;
            }
        }
        public static bool Unload(string name)
        {
            if (Textures.ContainsKey(name))
            {
                TextureRecord texture = Textures[name];

                if (texture.Loaded)
                {
                    texture.Unload();
                    return true;
                }
            }
            return false;
        }
    }
}
