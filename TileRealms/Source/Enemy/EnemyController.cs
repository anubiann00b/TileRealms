using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms
{
    abstract class EnemyController
    {
        Random r = new Random();

        public abstract void Update(Enemy e, double time);

        int x;
        int y;

        public Boolean Attacked(Vector2 position, Vector2 size, Vector2 projectile)
        {
            //VERY SUCKISH PROGRAMMING
            if (new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y).Contains(new Rectangle((int)projectile.X, (int)projectile.Y, (int)16, (int)16)))
            {
                return true;
            }

            return false;
        }

        public void UpdatePosition(int dir, int speed, double time, Enemy e)
        {
            // Directions are basically radians. Start right, CCW.
            // 0 -> Right
            // 1 -> Up
            // 2 -> Left
            // 3 -> Down

            if (dir % 2 == 0)
                e.location.X -= (int)((dir - 1) * speed * time);
            if (dir % 2 == 1)
                e.location.Y += (int)((dir - 2) * speed * time);
        }
    }
}
