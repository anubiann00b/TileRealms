using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms
{
    class MenuState : State
    {
        public MenuState(GraphicsDeviceManager g, ContentManager c, Viewport v)
        {
            super(g, c, v);
        }

        public override State Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Space))
                return new MainState(graphics, content, viewport);

            return this;
        }

        public override void Draw(GameTime gameTime, SpriteBatch s)
        {

        }
    }
}
