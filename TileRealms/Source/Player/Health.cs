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
        }


        public void Update(double perc)
        {
            ha -= perc;
            hp = Convert.ToInt32(maxhp * ha);
            healthP.SetWidth(ha);
            dead = ha < 0;
        }


        public void Draw(SpriteBatch spriteBatch, double GameTime)
        {
            HB.Draw(spriteBatch, GameTime, barPos);
            healthP.Draw(spriteBatch, GameTime, hPos);
        }
    }
}
