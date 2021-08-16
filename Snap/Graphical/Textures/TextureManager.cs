using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Snap.Graphical.Textures
{
    public class TextureManager
    {
        private static readonly Dictionary<string, TextureRecord> Textures = new Dictionary<string, TextureRecord>();

        public static void Initialize(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories))
            {
                AddTexture(file);
            }
        }
        private static void AddTexture(string filePath)
        {
            TextureRecord sprite = new TextureRecord(filePath);
            string name = Path.GetFileNameWithoutExtension(filePath);
            Textures.Add(name, sprite);
        }
        public static IEnumerable<TextureRecord> GetTextureRecords()
        {
            return Textures.Values;
        }
        public static TextureRecord GetTextureRecord(string name)
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
    }
}
