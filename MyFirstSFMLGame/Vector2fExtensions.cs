using SFML.System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstSFMLGame
{
    public static class Vector2fExtensions
    {
        public static float Length(this Vector2f v)
          => (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);

        public static Vector2f Normalize(this Vector2f v)
        {
            float length = v.Length();
            if (length != 0)
            {
                v.X /= length;
                v.Y /= length;
            }
            return v;
        }

        public static Vector2f Zero => new Vector2f(0, 0);
    }
}
