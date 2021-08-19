using SFML.Graphics;
using SFML.System;
using Snap.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Snap.Grids
{
    public abstract class Cell : IComparable<Cell>
    {
        public int Id
        {
            get;
            private set;
        }

        public abstract Vector2f Center
        {
            get;
        }

        public abstract Vector2f Position
        {
            get;
        }

        public int X
        {
            get;
            private set;
        }
        public int Y
        {
            get;
            private set;
        }
        public Cell(int id, int x, int y)
        {
            this.Id = id;
            this.X = x;
            this.Y = y;
        }

        public abstract bool Contains(Vector2f position);

        public int Distance4D(Cell end)
        {
            return (int)(Math.Abs(this.X - end.X) + Math.Abs(this.Y - end.Y)); ;
        }
        public int Distance8D(Cell end)
        {
            return (int)Math.Sqrt(Math.Pow(this.X - end.X, 2) + Math.Pow(this.Y - end.Y, 2));
        }

        public override string ToString()
        {
            return "Cell (" + X + "," + Y + ")";
        }

        public int CompareTo(Cell other)
        {
            return Id - other.Id;
        }
    }
}
