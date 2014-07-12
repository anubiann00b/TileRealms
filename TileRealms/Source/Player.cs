using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileRealms.Source.Player;

namespace TileRealms
{
    class Player
    {
        Viewport viewport;
        Sprite sprite;
        public Vector2 location;

        Health playerHealth;

        KeyboardState oldState;
        int speed = 8;
        public bool dead = false;

        Rectangle playerRect;
        Rectangle enemyRect;

        public void Initialize(Viewport vp)
        {
            viewport = vp;

            playerHealth = new Health();

            sprite = new Sprite(new TextureLibrary[] 
                {
                    TextureLibrary.PLAYER_RIGHT,
                    TextureLibrary.PLAYER_UP,
                    TextureLibrary.PLAYER_LEFT,
                    TextureLibrary.PLAYER_DOWN 
                },
                4, new Vector2(16, 16), 166
            );

            playerRect = new Rectangle(0, 0, 64, 64);
            enemyRect = new Rectangle(0, 0, 64, 64);
        }

        public void UnloadContent()
        {
        
        }
       
        public void Update(double time, List<Projectile> projectiles)
        {
            KeyboardState state = Keyboard.GetState();

            if (oldState == null)
                oldState = state;

            bool[] pr = new bool[4];
            bool[] hl = new bool[4];

            pr[0] = state.IsKeyDown(Keys.D) && !oldState.IsKeyDown(Keys.D);
            pr[1] = state.IsKeyDown(Keys.W) && !oldState.IsKeyDown(Keys.W);
            pr[2] = state.IsKeyDown(Keys.A) && !oldState.IsKeyDown(Keys.A);
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

            //location.X += 1;
            location.X += (int)(dx * speed * time);
            location.Y += (int)(dy * speed * time);
        }

        public void Draw(SpriteBatch spriteBatch, double time)
        {
            sprite.Draw(spriteBatch, time, location);
            playerHealth.Draw(spriteBatch, time);
        }

        public bool Hit(Enemy e)
        {
            enemyRect.X = (int)e.location.X;
            enemyRect.Y = (int)e.location.Y;
            playerRect.X = (int)location.X;
            playerRect.Y = (int)location.Y;

            return playerRect.Intersects(enemyRect);
        }

        public void Damage()
        {
            playerHealth.Update(0.02);
            dead = playerHealth.hp < 0;
        }
    }
}
