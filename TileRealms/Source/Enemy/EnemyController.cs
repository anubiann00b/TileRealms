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

        public void SpawnEnemy()
        {
            if (r.Next(100) == 0)
            {
                x = r.Next();
            }
        }

        public void UpdatePosition(int dir, int speed, double time, Enemy e)
        {
            //Direction
            //1 -> Up
            //2 -> Left
            //3 -> Down
            //4 -> Right
            //Something like that

            if (dir % 2 == 0)
                e.location.X -= (int)((dir - 1) * speed * time);
            if (dir % 2 == 1)
                e.location.Y += (int)((dir - 2) * speed * time);
        }
    }
}
