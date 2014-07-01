using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TileRealms
{
    abstract class EnemyController
    {
        public abstract void Update(Enemy e, GameTime time);

        public void UpdatePosition(int dir, int speed, GameTime time, Enemy e)
        {
            speed *= (int)(time.ElapsedGameTime.Milliseconds/16.0);
            if (dir % 2 == 0)
                e.location.X -= (dir - 1)*speed;
            if (dir % 2 == 1)
                e.location.Y += (dir - 2)*speed;
        }
    }
}
