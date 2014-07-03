using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms
{
    class Enemy
    {
        public Sprite sprite;
        public Vector2 location;
        EnemyController controller;

        public void Initialize(EnemyController e, Vector2 l)
        {
            controller = e;
            location = l;
        }

        public void LoadContent(ContentManager content)
        {
            sprite = new Sprite(new String[] { "right", "up", "left", "down" }, 4, new Vector2(16, 16), 166, content);
        }

        public void Update(double time)
        {
            controller.Update(this,time);
        }

        public void Draw(SpriteBatch spriteBatch, double time)
        {
            //The line below is giving me NULLREFERENCEEXCEPTIONS
            sprite.Draw(spriteBatch, time, location);
        }
    }
}
