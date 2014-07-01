﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms
{
    abstract class EnemyController
    {
        public abstract void Update(Enemy e, double time);

        public void UpdatePosition(int dir, int speed, double time, Enemy e)
        {
            if (dir % 2 == 0)
                e.location.X -= (int)((dir - 1) * speed * time);
            if (dir % 2 == 1)
                e.location.Y += (int)((dir - 2) * speed * time);
        }
    }
}