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

        public void Initialize(EnemyController e)
        {
            controller = e;
        }

        public void LoadContent(ContentManager content)
        {
            sprite = new Sprite(new String[] { "player_right", "player_up", "player_left", "player_down" }, 4, new Vector2(16, 16), 166, content);
        }

        public void Update(double time)
        {
            controller.Update(this,time);
        }

        public void Draw(SpriteBatch spriteBatch, double time)
        {
            sprite.Draw(spriteBatch, time, location);
        }
    }
}
