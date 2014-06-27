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
    class Enemy
    {
        Viewport viewport;
        Sprite sprite;
        public Vector2 location;
        Vector2 destination;
        Vector2 difference;
        Random r = new Random();
        int size = 64;
        int direction;
        int speed = 8;

        public void Initialize(Viewport vp)
        {
            r = new Random();
        }

        public Vector2 BehaviorUpdate()
        {
            if (r.Next(0, 1) < 0.01) //so the enemy doesn't go running around
            {
               if (r.Next(0, 1) < 0.1) //so the enemy doesn't go running around
               {
                    location.X -= 1;
               }

               else if (r.Next(0, 1) > 0.9) //so the enemy doesn't go running around
               {
                   location.X += 1;
               }
            }

            else if (r.Next(0, 1) > 0.9) //so the enemy doesn't go running around
            {
               if (r.Next(0, 1) < 0.1) //so the enemy doesn't go running around
               {
                    location.Y -= 1;
               }

               else if (r.Next(0, 1) > 0.9) //so the enemy doesn't go running around
               {
                   location.Y += 1;
               }
            }


            //THIS IS VERY CRAPPY BUT DON'T TOUCH IT SHREYAS I GOT THIS
            return location;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime time)
        {
            sprite.Draw(spriteBatch, time, location);
        }
    }
}
