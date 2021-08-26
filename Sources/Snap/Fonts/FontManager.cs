using SFML.Graphics;
using Snap.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Snap.Fonts
{
    public class FontManager
    {
        private static readonly Dictionary<string, Font> m_fonts = new Dictionary<string, Font>();

        public static void Initialize(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in Directory.GetFiles(path))
            {
                m_fonts.Add(Path.GetFileNameWithoutExtension(file), new Font(file));
            }
        }
        public static Font GetFont(string name)
        {
            if (!m_fonts.ContainsKey(name))
            {
                throw new ElementNotFoundException("Font", name);
            }
            return m_fonts[name];
        }

    }
}
