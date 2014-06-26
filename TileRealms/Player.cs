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
        Sprite sprite;
        public Vector2 location;

        public void Initialize(Viewport vp)
        {
            viewport = vp;
        }

        public void LoadContent(ContentManager content)
        {
            sprite = new Sprite(new String[] { "player_right", "player_up", "player_left", "player_down" }, 4, new Vector2(16, 16), 166, content);
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

        public void Draw(SpriteBatch spriteBatch, GameTime time)
        {
            sprite.Draw(spriteBatch, time, location);
        }
    }
}
