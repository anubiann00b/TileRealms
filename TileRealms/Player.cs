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
        Rectangle destRect;
        Rectangle srcRect;
        Vector2 frames;
        public Vector2 location;
        public int size;

        public void Initialize(Viewport _vp)
        {
            viewport = _vp;
            
            if (viewport.Width > viewport.Height)
                size = viewport.Height / 10;
            else
                size = viewport.Width / 10;

            frames = new Vector2(0, 0);
            destRect = new Rectangle((int)location.X, (int)location.Y, size, size);
            srcRect = new Rectangle((int)frames.X, (int)frames.Y, 48, 48);
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Random_warrior");
        }

        public void UnloadContent()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.W))
            {
                location.Y -= 10;
            }
            if (state.IsKeyDown(Keys.S))
            {
                location.Y += 10;
            }
            if (state.IsKeyDown(Keys.A))
            {
                location.X -= 10;
            }
            if (state.IsKeyDown(Keys.D))
            {
                location.X += 10;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, srcRect, Color.White);
        }
    }
}
