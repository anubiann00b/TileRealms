using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TileRealms
{
    class Animation
    {
        Texture2D texture;
        String fileName;
        int numFrames;
        int currentFrame;

        Rectangle destRect;
        Rectangle srcRect;

        Vector2 size;
        float timer = 0f;
        bool stopped = false;

        public Animation(String file, int frames, Vector2 newSize, int speed, ContentManager content)
        {
            fileName = file;

            texture = content.Load<Texture2D>(fileName);

            size = newSize;
            numFrames = frames;

            srcRect = new Rectangle(frames * 16, 0, (int)size.X, (int)size.Y);
            destRect = new Rectangle(0, 0, (int)(size.X * 4), (int)(size.Y * 4));
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Vector2 location)
        {
            if (!stopped)
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > 100)
            {
                currentFrame++;
                if (currentFrame >= numFrames)
                    currentFrame = 0;
                timer = 0;
            }

            destRect.X = (int)location.X;
            destRect.Y = (int)location.Y;
            srcRect.X = currentFrame * 16;

            spriteBatch.Draw(texture, destRect, srcRect, Color.White);
        }

        public void Stop()
        {
            stopped = true;
            timer = 0;
        }

        public void Start()
        {
            stopped = false;
            //timer = 0;
        }

        public void SetCurrentFrame(int frame)
        {
            currentFrame = frame;
        }
    }
}
