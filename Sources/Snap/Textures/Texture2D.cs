using System;
using System.IO;
using SFML.Graphics;

namespace Snap.Textures
{
	public class Texture2D : Texture, IDisposable
	{
		public string FilePath { get; }

		public string Name => Path.GetFileNameWithoutExtension(FilePath);

		public Texture2D(string filePath) : base(filePath)
		{
			FilePath = filePath;
			Smooth = TextureManager.UsePixelInterpolation;
		}

		public Texture2D(string filePath, IntRect area) : base(filePath, area)
		{
			FilePath = filePath;
			Smooth = TextureManager.UsePixelInterpolation;
		}

		public Sprite CreateSprite()
		{
			return new Sprite(this);
		}
	}
}
