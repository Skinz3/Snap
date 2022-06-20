using System;
using System.Collections.Generic;
using SFML.System;
using Snap.Grids;
using Snap.Textures;

namespace Snap.Maps
{
	public class Map : IDrawable
	{
		public Grid Grid
		{
			get;
			set;
		}
		public Dictionary<LayerEnum, Layer> Layers
		{
			get;
			set;
		}

		public Map(Grid grid)
		{
			this.Grid = grid;

			if (!Grid.Built)
			{
				Grid.Build();
			}

			this.Layers = new Dictionary<LayerEnum, Layer>();

			foreach (LayerEnum value in Enum.GetValues(typeof(LayerEnum)))
			{
				this.Layers.Add(value, new Layer());
			}
		}

		public void Draw(GameWindow window)
		{
			foreach (var layer in Layers.Values)
			{
				layer.Draw(window);
			}

			Grid.Draw(window);
		}

		public void AddElement(LayerEnum layer, Cell cell, Texture2D texture)
		{
			Vector2f position = cell.Center - new Vector2f(texture.Size.X / 2, texture.Size.Y / 2);
			Element element = new Element(position, texture, new Vector2f(1, 1));
			Layers[layer].AddElement(cell, element);
		}
		public void AddElement(LayerEnum layer, int cellId, string textureName)
		{
			var texture = TextureManager.Get(textureName);
			var cell = Grid.GetCell(cellId);
			Vector2f position = cell.Center - new Vector2f(texture.Size.X / 2, texture.Size.Y / 2);
			Element element = new Element(position, texture, new Vector2f(1, 1));
			Layers[layer].AddElement(cell, element);
		}
	}
}
