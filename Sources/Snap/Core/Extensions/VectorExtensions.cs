using SFML.System;
using Snap.Paths;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Core.Extensions
{
    public static class VectorExtensions
    {
        public static Vector2f Normalize(this Vector2f vector)
        {
            float length = vector.Length();

            if (length != 0)
            {
                return new Vector2f(vector.X / length, vector.Y / length);
            }
            else
            {
                return vector;
            }
        }
        /*
         * The square root of the sum of the squares of the horizontal and vertical components
         */
        public static float Length(this Vector2f vector)
        {
            return (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }
        public static float Distance(this Vector2f v1, Vector2f v2)
        {
            return (float)Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2));
        }
        /*
         * Compute the direction from a directional vector
         */
        public static DirectionsEnum GetDirectionEnum(this Vector2f vector)
        {
            double angle = Math.Atan2(vector.Y, vector.X);

            if (angle >= (-Math.PI / 8) && angle <= (Math.PI / 8))
            {
                return DirectionsEnum.East;
            }
            else if (angle >= (3 * Math.PI / 8) && angle <= (5 * Math.PI / 8))
            {
                return DirectionsEnum.South;
            }
            else if (angle >= (Math.PI / 8) && angle <= (3 * Math.PI / 8))
            {
                return DirectionsEnum.SouthEast;
            }
            else if (angle >= (5 * Math.PI / 8) && angle <= (7 * Math.PI / 8))
            {
                return DirectionsEnum.SouthWest;
            }
            else if (angle >= (7 * Math.PI / 8) && angle <= Math.PI || (angle >= -Math.PI && angle <= (-7 * Math.PI / 8)))
            {
                return DirectionsEnum.West;
            }
            else if (angle >= (-7 * Math.PI / 8) && angle <= (-5 * Math.PI / 8))
            {
                return DirectionsEnum.NorthWest;
            }
            else if (angle >= (-5 * Math.PI / 8) && angle <= (-3 * Math.PI / 8))
            {
                return DirectionsEnum.North;
            }
            else if (angle >= (-3 * Math.PI / 8) && angle <= (-Math.PI / 8))
            {
                return DirectionsEnum.NorthEast;
            }
            else
            {
                throw new ArgumentOutOfRangeException(angle + " is out of range");
            }

        }
    }
}
