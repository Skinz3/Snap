using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Core.Exceptions
{
    public class TextureNotFoundException : Exception
    {
        public TextureNotFoundException(string name) : base("The texture '" + name + "' could not be found.")
        {

        }
    }
}
