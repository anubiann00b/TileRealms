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
        int currentDir;

        public Sprite(TextureLibrary[] textures, int frames, Vector2 newSize, int speed)
        {
            currentDir = 0;
            animations = new Animation[textures.GetLength(0)];
            for (int i = 0; i < textures.GetLength(0); i++)
            {
                animations[i] = new Animation(textures[i], frames, newSize, speed);
            }
        }

        public void Draw(SpriteBatch spriteBatch, double gameTime, Vector2 location)
        {
            animations[currentDir].Draw(spriteBatch, gameTime, location);
        }

        public void SetCurrentDirection(int dir)
        {
            currentDir = dir;
        }

        public void Stop(int i)
        {
            animations[i].Stop();
        }

        public void Start(int i)
        {
            animations[i].Start();
        }

        public void SetCurrentFrame(int i, int frame)
        {
            animations[i].SetCurrentFrame(frame);
        }
    }
}
