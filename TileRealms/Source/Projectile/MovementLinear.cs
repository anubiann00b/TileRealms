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
        int direction;
        int speed;

        public MovementLinear(int dir, int spd)
        {
            direction = dir;
            speed = spd;
        }

        public override void Update(Projectile p, double time)
        {
            p.location.X += (float)(speed * Math.Cos(Math.PI * direction / 180));
            p.location.Y += (float)(speed * Math.Sin(Math.PI * direction / 180));
        }
    }
}
