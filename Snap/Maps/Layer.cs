using SFML.Graphics;
using SFML.System;
using Snap.Grids;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Maps
{
    public class Layer : IDrawable
    {
        private SortedDictionary<Cell, Element> Elements
        {
            get;
            set;
        }

        public Layer()
        {
            this.Elements = new SortedDictionary<Cell, Element>();
        }
        public void Draw(RenderWindow window)
        {
            foreach (var element in Elements.Values)
            {
                element.Draw(window);
            }
        }

        public void AddElement(Cell cell,Element element)
        {
            this.Elements.Add(cell, element);
        }
    }
}
