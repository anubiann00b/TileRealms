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
        public double health;
        EnemyController controller;

        public void Initialize(EnemyController e, Vector2 _location)
        {
            controller = e;
            location = _location;

            sprite = new Sprite(new TextureLibrary[] 
                {
                    TextureLibrary.MUTANT_RIGHT,
                    TextureLibrary.MUTANT_UP,
                    TextureLibrary.MUTANT_LEFT,
                    TextureLibrary.MUTANT_DOWN 
                },
                4, new Vector2(16, 16), 166
            );
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
