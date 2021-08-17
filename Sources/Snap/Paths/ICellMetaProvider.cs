using Snap.Grids;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Paths
{
    public interface ICellMetaProvider
    {
        bool IsWalkable(Cell cell);
    }
}
