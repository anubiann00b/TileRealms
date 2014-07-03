using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms
{
    class MovementLinear : MovementPattern
    {
        double direction;
        int speed;

        public MovementLinear(double dir, int spd)
        {
            direction = dir;
            speed = spd;
        }

        public override void Update(Projectile p, double time)
        {
            p.location.X += (float)(speed * Math.Cos(direction));
            p.location.Y += (float)(speed * Math.Sin(direction));
        }
    }
}
