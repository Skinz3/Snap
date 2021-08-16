using Snap.Graphical.Grids;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Graphical.Maps
{
    public class Map
    {
        private SortedDictionary<Cell, Element> Elements
        {
            get;
            set;
        }

        public Grid Grid
        {
            get;
            set;
        }
    }
}
