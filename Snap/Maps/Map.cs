using SFML.Graphics;
using SFML.System;
using Snap.Grids;
using Snap.Textures;
using System;
using System.Collections.Generic;
using System.Text;

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
            this.Layers = new Dictionary<LayerEnum, Layer>();

            foreach (LayerEnum value in Enum.GetValues(typeof(LayerEnum)))
            {
                this.Layers.Add(value, new Layer());
            }
        }

        public void Draw(RenderWindow window)
        {
            Grid.Draw(window);

            foreach (var layer in Layers.Values)
            {
                layer.Draw(window);
            }
        }

        public void AddElement(LayerEnum layer, Cell cell, TextureRecord textureRecord)
        {
            Vector2f position = cell.Center - new Vector2f(textureRecord.Texture.Size.X / 2, textureRecord.Texture.Size.Y / 2);

            Element element = new Element(position, textureRecord, new Vector2f(1, 1));

            Layers[layer].AddElement(cell, element);
        }
    }
}
