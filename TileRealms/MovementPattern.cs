using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms
{
    abstract class MovementPattern
    {
        public abstract void Update(Projectile p, GameTime time);
    }
}
