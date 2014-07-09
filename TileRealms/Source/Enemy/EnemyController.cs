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
        Rectangle enemyRect = new Rectangle(0, 0, 16, 16);
        Rectangle projRect = new Rectangle(0, 0, 16, 16);
        public abstract void Update(Enemy e, double time);

        int x;
        int y;

        public Boolean Attacked(Vector2 position, Vector2 size, Vector2 projectile)
        {                
            enemyRect.X = (int)position.X;
            enemyRect.Y = (int)position.Y;
            projRect.X = (int)projectile.X;
            projRect.Y = (int)projectile.Y;

            if (enemyRect.Intersects(projRect))
            {
                System.Diagnostics.Debug.WriteLine("HIT");
                return true;
            }

            System.Diagnostics.Debug.WriteLine("failure");
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
