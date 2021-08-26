using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Core.Exceptions
{
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(string elementType, string name) : base("The " + elementType + " '" + name + "' could not be found.")
        {

        }
    }
}
