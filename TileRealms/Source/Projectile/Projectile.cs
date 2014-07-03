using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms
{
    class Projectile
    {
        public Vector2 location;
        Animation sprite;
        MovementPattern pattern;

        public Projectile(Vector2 loc)
        {
            location = loc;
        }

        public void Initialize(MovementPattern pat)
        {
            pattern = pat;
            sprite = new Animation(TextureLibrary.PLAYER_RIGHT, 4, new Vector2(16, 9), 166);
        }

        public void Update(double time)
        {
            pattern.Update(this, time);
        }

        public void Draw(SpriteBatch spriteBatch, double time)
        {
            sprite.Draw(spriteBatch, time, location);
        }
    }
}
