using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace TileRealms
{
    class Player
    {
        Viewport viewport;
        Texture2D texture;
        Texture2D up;
        Texture2D down;
        Texture2D right;
        Texture2D left;

        Rectangle destRect;
        Rectangle srcRect;
        int frames;
        public Vector2 location;

        float time = 0f;

        public void Initialize(Viewport _vp)
        {
            viewport = _vp;

            destRect = new Rectangle((int)location.X, (int)location.Y, 64, 64);
            srcRect = new Rectangle((int)frames, (int)0, 16, 16);
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("player_up");
            up = content.Load<Texture2D>("player_up");
            down = content.Load<Texture2D>("player_down");
            right = content.Load<Texture2D>("player_right");
            left = content.Load<Texture2D>("player_left");
        }

        public void UnloadContent()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (time > 200)
            {
                frames++;
                if (frames >= 4)
                    frames = 0;
                time = 0f;
            }

            srcRect.X = frames * 16;
            destRect.X = (int)location.X;
            destRect.Y = (int)location.Y;

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.W))
            {
                texture = up;
                location.Y -= 10;
            }
            if (state.IsKeyDown(Keys.S))
            {
                texture = down;
                location.Y += 10;
            }
            if (state.IsKeyDown(Keys.A))
            {
                texture = left;
                location.X -= 10;
            }
            if (state.IsKeyDown(Keys.D))
            {
                texture = right;
                location.X += 10;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destRect, srcRect, Color.White);
        }
    }
}
