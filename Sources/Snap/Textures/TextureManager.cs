using System.Collections.Generic;
using System.IO;
using Snap.Core.Exceptions;

namespace Snap.Textures
{
	public class TextureManager
	{
		private static readonly Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

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
				Texture2D sprite = new Texture2D(file);
				string name = Path.GetFileNameWithoutExtension(file);
				Textures.Add(name, sprite);
			}
		}

		public static IEnumerable<Texture2D> FindAll()
		{
			return Textures.Values;
		}

		public static Texture2D Get(string name)
		{
			if (!Textures.TryGetValue(name, out var texture))
			{
				throw new ElementNotFoundException("Texture", name);
			}

			return texture;
		}

		public static bool Unload(string name)
		{
			if (Textures.TryGetValue(name, out var texture))
			{
				texture.Dispose();
				return true;
			}

			return false;
		}
	}
}
