using Snap.Grids;
using Snap.Paths;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Example
{
    public class CellMetaProvider : ICellMetaProvider
    {
        public bool IsWalkable(Cell cell)
        {
            return true;
        }
    }
}
