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
using TileRealms.Source.Health;

namespace TileRealms
{
    class Enemy
    {
        public Sprite sprite;
        public Vector2 location;
        EnemyController controller;
        EnemyDatabase ed;
        Health enemyHealth;

        public void Initialize(EnemyController e, Vector2 _location)
        {
            ed = new EnemyDatabase();
            enemyHealth = new Health(10);

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


            //enemyHealth = new Health(ed.enemyData.ElementAt(1).hp);
        }

        public void Update(double time)
        {
            controller.Update(this,time);
            
        }

        public Boolean Destroy(Vector2 projectile)
        {
            if (controller.Attacked(location, new Vector2(16, 16), projectile))
            {
                return true;
            }

            else 
                return false;
        }

        public void Draw(SpriteBatch spriteBatch, double time)
        {
            sprite.Draw(spriteBatch, time, location);
            enemyHealth.Draw(spriteBatch, time, location, new Vector2(16, 16));
        }
    }
}
