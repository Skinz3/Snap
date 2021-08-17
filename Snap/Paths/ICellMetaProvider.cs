using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Paths
{
    public interface ICellMetaProvider
    {
        bool IsWalkable(int cellId);
    }
}
