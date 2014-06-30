﻿using System;
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

        KeyboardState oldState;
        int direction;
        int speed = 8;

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

            if (oldState == null)
                oldState = state;

            bool[] pr = new bool[4];
            bool[] hl = new bool[4];

            pr[1] = state.IsKeyDown(Keys.W) && !oldState.IsKeyDown(Keys.W);
            pr[2] = state.IsKeyDown(Keys.A) && !oldState.IsKeyDown(Keys.A);
            pr[0] = state.IsKeyDown(Keys.D) && !oldState.IsKeyDown(Keys.D);
            pr[3] = state.IsKeyDown(Keys.S) && !oldState.IsKeyDown(Keys.S);

            hl[0] = state.IsKeyDown(Keys.D);
            hl[1] = state.IsKeyDown(Keys.W);
            hl[2] = state.IsKeyDown(Keys.A);
            hl[3] = state.IsKeyDown(Keys.S);

            for (int i = 0; i < 2; i++)
            {
                if ((hl[i] || pr[i]) && (hl[i + 2] || pr[i + 2]))
                {
                    hl[i] = false;
                    hl[i + 2] = false;
                }
            }

            int dx = 0;
            int dy = 0;

            for (int i = 0; i < 4; i++)
            {
                if (pr[i])
                    sprite.SetCurrentDirection(i);
                else
                    sprite.Stop(i);
                if (hl[i])
                {
                    sprite.Start(i);
                    dx += i % 2 == 0 ? 1 - i : 0;
                    dy += i % 2 == 1 ? i - 2 : 0;
                    if (!hl[(i + 1) % 4] && !hl[(i + 2) % 4] && !hl[(i + 3) % 4])
                        sprite.SetCurrentDirection(i);
                }
                else
                    sprite.SetCurrentFrame(i, 1);
            }

            location.X += dx * speed;
            location.Y += dy * speed;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime time)
        {
            sprite.Draw(spriteBatch, time, location);
        }
    }
}
