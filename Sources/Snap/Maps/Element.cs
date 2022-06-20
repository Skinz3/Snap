using System;
using SFML.Graphics;
using SFML.System;
using Snap.Textures;

namespace Snap.Maps
{
	public class Element : IDisposable, IDrawable
	{
		private Texture2D Texture
		{
			get;
			set;
		}
		public string SpriteName
		{
			get
			{
				return Texture.Name;
			}
		}
		public Sprite Sprite
		{
			get;
			private set;
		}

		public Vector2f Position => Sprite.Position;

		public Element(Vector2f position, Texture2D record, Vector2f scale)
		{
			Texture = record;
			Sprite = Texture.CreateSprite();
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

		public void Draw(GameWindow window)
		{
			window.Draw(Sprite);
		}
	}
}
