using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Snap.Core.Serialization
{
    public interface ISerializable
    {
        void Serialize(BinaryWriter writer);

        void Deserialize(BinaryReader reader);
    }
}
