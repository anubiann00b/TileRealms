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

        public Sprite(String[] files, int frames, Vector2 newSize, int speed, ContentManager content)
        {
            animations = new Animation[files.GetLength(0)];
            for (int i = 0; i < files.GetLength(0); i++)
            {
                animations[i] = new Animation(files[i], frames, newSize, speed, content);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Vector2 location)
        {
            animations[currentAnim].Draw(spriteBatch, gameTime, location);
        }
    }
}
