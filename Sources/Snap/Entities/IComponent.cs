using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Entities
{
    public interface IComponent
    {
        Entity Parent
        {
            get;
        }
    }
}
