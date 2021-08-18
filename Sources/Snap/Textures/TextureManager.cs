using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Snap.Textures
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
                TextureRecord sprite = new TextureRecord(file);
                string name =  Path.GetFileNameWithoutExtension(file);
                Textures.Add(name, sprite);
            }
        }
        public static IEnumerable<TextureRecord> GetRecords()
        {
            return Textures.Values;
        }
        public static TextureRecord GetRecord(string name)
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
