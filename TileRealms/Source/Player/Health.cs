using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;
using System.Diagnostics;
using TileRealms.Source.Health;

namespace TileRealms.Source.Player
{
    class Health
    {
        TextureLibrary tl;
        Animation HB;
        Animation healthP;
        Vector2 barPos;
        Vector2 hPos;
        public double ha = 1;
        public int hp;
        int maxhp;
        public bool dead = false;
        int originalWidth;
        
        public Health()
        {
            Initialize(100);
        }

        private void Initialize(int health)
        {
            hp = health;
            maxhp = health;
            HB = new Animation(TextureLibrary.HealthBar, 1, new Vector2(160, 20), 100000);
            healthP = new Animation(TextureLibrary.Health, 1, new Vector2(160, 20), 100000);
            barPos = new Vector2(0, 0);
            hPos = new Vector2(0, 0);
            originalWidth = healthP.destRect.X;
        }


        public void Update(double perc)
        {
            ha -= perc;
            hp = Convert.ToInt32(maxhp * ha);
            healthP.SetWidth(ha, originalWidth);
            dead = hp < 0;
        }


        public void Draw(SpriteBatch spriteBatch, double GameTime, Vector2 camera)
        {
            HB.Draw(spriteBatch, GameTime, new Vector2(barPos.X + camera.X, barPos.Y + camera.Y));
            healthP.Draw(spriteBatch, GameTime, new Vector2(hPos.X + camera.X, hPos.Y + camera.Y));
        }
    }
}
