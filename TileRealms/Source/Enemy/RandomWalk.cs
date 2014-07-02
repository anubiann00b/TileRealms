using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms
{
    class RandomWalk : EnemyController
    {
        int direction;
        Random r;

        public RandomWalk()
        {
            r = new Random();
            direction = r.Next(4); // 0 through 3.
        }

        public override void Update(Enemy e, double time)
        {
            if (r.Next(15) == 0)
            {
                e.sprite.Stop(direction);
                direction = r.Next(4);
                e.sprite.SetCurrentDirection(direction);
                e.sprite.Start(direction);
            }

            UpdatePosition(direction, 3, time, e);
        }
    }
}
