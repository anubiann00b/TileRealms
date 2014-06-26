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
    class Sprite
    {
        Animation[] animations;
        int currentAnim;

        public Sprite(Animation[] anims)
        {
            animations = anims;
        }

        public void LoadContent(ContentManager content)
        {
            foreach (Animation a in animations)
            {
                a.LoadContent(content);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Vector2 location)
        {
            animations[currentAnim].Draw(spriteBatch, gameTime, location);
        }
    }
}
