using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms
{
    class GameManager
    {
        Viewport view;

        World world;

        List<Enemy> enemies;
        List<Projectile> projectiles;

        Player player;

        public GameManager(Vector2 worldSize, Viewport v)
        {
            view = v;
            world = new World(worldSize);
            enemies = new List<Enemy>();
            projectiles = new List<Projectile>();
        }

        public void Initialize()
        {
            player = new Player();
            player.Initialize(view);
        }

        public void Update(GameTime gameTime, Vector2 camera)
        {
            double frameTime = gameTime.ElapsedGameTime.TotalMilliseconds * 60 / 1000.0;

            player.Update(frameTime, projectiles, camera);

            for (int i = 0; i < projectiles.Count; i++)
            {
                Projectile p = projectiles.ElementAt(i);
                p.Update(frameTime);
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy e = enemies.ElementAt(i);
                e.Update(frameTime);

                for (int x = 0; x < projectiles.Count; x++)
                {
                    if (e.Destroy(projectiles.ElementAt(x).location))
                    {
                        enemies.Remove(enemies.ElementAt(i));
                    }
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 camera)
        {
            world.Draw(spriteBatch, camera, view);

            double frameTime = gameTime.ElapsedGameTime.TotalMilliseconds * 60 / 1000.0;

            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy e = enemies.ElementAt(i);
                e.Draw(spriteBatch, frameTime);
            }
            for (int i = 0; i < projectiles.Count; i++)
            {
                Projectile p = projectiles.ElementAt(i);
                p.Draw(spriteBatch, frameTime);
            }

            player.Draw(spriteBatch, frameTime);
        }
    }
}
