using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms
{
    class Animation
    {
        Texture2D texture;
        TextureLibrary textureSource;
        int numFrames;
        int currentFrame;

        Rectangle destRect;
        Rectangle srcRect;

        Vector2 size;
        double timer = 0;
        bool stopped = false;
        int duration;

        public Animation(TextureLibrary file, int frames, Vector2 newSize, int speed)
        {
            duration = speed;
            textureSource = file;

            texture = textureSource.GetTexture();

            size = newSize;
            numFrames = frames;

            srcRect = new Rectangle(frames * 16, 0, (int)size.X, (int)size.Y);
            destRect = new Rectangle(0, 0, (int)(size.X * 4), (int)(size.Y * 4));
        }

        public void Draw(SpriteBatch spriteBatch, double gameTime, Vector2 location)
        {
            if (!stopped)
                timer += gameTime * 1000 / 60;

            if (timer > duration)
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
