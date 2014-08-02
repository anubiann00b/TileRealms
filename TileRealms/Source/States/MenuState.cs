﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TileRealms
{
    class MenuState : State
    {
        Texture2D btnPlay;
        Texture2D btnOptions;
        Vector2 playLocation;
        Vector2 optionsLocation;
        Vector2 buttonSize;

        Texture2D TileRealmsLogo;
        Rectangle TRLOL;

        public MenuState(GraphicsDeviceManager g, ContentManager c, Viewport v) : base(g, c, v)
        {
            buttonSize = new Vector2(viewport.Width * 0.2f, viewport.Width * 0.2f * 0.5555555f);
            
            playLocation = new Vector2((viewport.Width - buttonSize.X) / 2, viewport.Height * 0.6f);
            optionsLocation = new Vector2((buttonSize.X * 1.2f) + (viewport.Width - buttonSize.X) / 2, viewport.Height * 0.6f);

            TRLOL = new Rectangle((int)((viewport.Width - (viewport.Width * .35f)) / 2), (int)(viewport.Height * 0.2), (int)(viewport.Width * .35f), (int)(viewport.Width * .35f * 0.48387f));

            TileRealmsLogo = c.Load<Texture2D>(@"Buttons/TileRealms");
            btnPlay = c.Load<Texture2D>(@"Buttons/PhonePlay");
            btnOptions = c.Load<Texture2D>(@"Buttons/PhoneOptions");
        }

        public override State Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Enter))
                return new GameState(graphics, content, viewport);

            return this;
        }

        public override void Draw(GameTime gameTime, SpriteBatch s)
        {
            s.Begin();
            s.Draw(TileRealmsLogo, TRLOL, Color.White);
            s.Draw(btnPlay, new Rectangle((int)playLocation.X, (int)playLocation.Y, (int)buttonSize.X, (int)buttonSize.Y), Color.White);
            s.Draw(btnOptions, new Rectangle((int)optionsLocation.X, (int)optionsLocation.Y, (int)buttonSize.X, (int)buttonSize.Y), Color.White);
            s.End();
        }
    }
}
