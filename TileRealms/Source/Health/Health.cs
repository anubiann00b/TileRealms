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
using TileRealms.Source.Enemy;

namespace TileRealms.Source.Health
{
    class Health
    {
        TextureLibrary tl;
        Animation HB;
        Animation healthP;
        Vector2 barPos;
        Vector2 hPos;

        int hp;

        public Health(int health)
	    {
            Initialize(health);
	    }

        private void Initialize(int health)
        {
            hp = health;
            HB = new Animation(TextureLibrary.HealthBar, 1, new Vector2(16, 2), 100000);
            healthP = new Animation(TextureLibrary.Health, 1, new Vector2(16, 2), 100000);
            barPos = new Vector2(0, 0);
            hPos = new Vector2(0, 0);
        }

        double ha = 1;

        public void Update()
        {
            if (true)
            {
                ha -= 0.01;
                healthP.SetWidth(ha);
            }
        }


        public void Draw(SpriteBatch spriteBatch, double GameTime, Vector2 pmLocation, Vector2 pmSize)
        {
            barPos.X = pmLocation.X;
            barPos.Y = pmLocation.Y + pmSize.Y + 60;
            hPos.X = barPos.X + 1;
            hPos.Y = barPos.Y + 1;

            HB.Draw(spriteBatch, GameTime, barPos);
            healthP.Draw(spriteBatch, GameTime, hPos);
        }
    }
}
