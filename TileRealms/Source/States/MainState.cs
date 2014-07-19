using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics.Tracing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileRealms.Source.Enemy;
using TileRealms.Source.Health;
using TileRealms.Source.Items;
using TileRealms.Source.World.Dungeon;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace TileRealms
{
    public class GameState : State
    {
        Player player;
        Random r;

        World world;
        
        Vector2 camera;
        Vector2 worldSize;

        Texture2D mouseTexture;

        List<Enemy> enemies;
        List<Projectile> projectiles;
        List<Items> items;

        Texture2D CollisionBox;
        GenerateDungeon dungeonGenerator;

        double ttime;

        public GameState(GraphicsDeviceManager g, ContentManager c, Viewport v) : base(g, c, v)
        {
            camera = new Vector2();
            worldSize = new Vector2(10000, 10000);
            world = new World(worldSize);
            enemies = new List<Enemy>();
            projectiles = new List<Projectile>();
            items = new List<Items>();
            r = new Random();
        }

        public override void Initialize()
        {
            TextureLibrary.LoadLibraryContent(content);

            r = new Random();

            player = new Player();
            player.Initialize(viewport);

            Enemy e = new Enemy();
            e.Initialize(new RandomWalk(), new Vector2(500, 500));
            enemies.Add(e);

            ttime = 0f;

            dungeonGenerator = new GenerateDungeon();
            dungeonGenerator.Initialize();
        }

        public override void LoadContent()
        {
            Tile.LoadTiles(content);

            mouseTexture = content.Load<Texture2D>("Random_warrior");
            CollisionBox = content.Load<Texture2D>("DetectionBox");

        }

        public override State Update(GameTime gameTime)
        {
            camera.X = MathHelper.Clamp(player.location.X - viewport.Width / 2, 0, worldSize.X - viewport.Width);
            camera.Y = MathHelper.Clamp(player.location.Y - viewport.Height / 2, 0, worldSize.Y - viewport.Height);

            double frameTime = gameTime.ElapsedGameTime.TotalMilliseconds * 60 / 1000.0;

            player.Update(frameTime, projectiles);

            //PROJECTILE SYSTEM
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                ttime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (ttime > 300)
                {
                    Projectile p = new Projectile(player.location);
                    int dx = (int)(mouseState.X - (player.location.X - camera.X + 32));
                    int dy = (int)(mouseState.Y - (player.location.Y - camera.Y + 32));
                    double dir = Math.Atan2(dy, dx);
                    p.Initialize(new MovementLinear(dir, 10));
                    projectiles.Add(p);
                    ttime = 0;
                }
            }

            else if (mouseState.LeftButton == ButtonState.Released)
            {
                ttime = 300;
            }
            //PROJECTILE SYSTEM

            if ((r.Next(100) == 0) && enemies.Count < 1000)
            {
                Enemy e = new Enemy();
                e.Initialize(new RandomWalk(), new Vector2(r.Next(1000, viewport.Width), r.Next(100, viewport.Height)));
                enemies.Add(e);
            }

            for (int i = 0; i < projectiles.Count; i++)
            {
                Projectile p = projectiles.ElementAt(i);
                p.Update(frameTime);
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy e = enemies.ElementAt(i);
                e.Update(frameTime);
            }

            for (int i = 0; i < projectiles.Count; i++)
            {
                Projectile p = projectiles.ElementAt(i);
                if (Math.Pow(player.location.X - p.location.X, 2) + Math.Pow(player.location.Y - p.location.Y, 2) > 250000)
                {
                    projectiles.RemoveAt(i);
                    i--;
                }

                if (projectiles.Count > 0)
                {
                    for (int j = 0; j < enemies.Count; j++)
                    {
                        Enemy e = enemies.ElementAt(j);
                        if (e.Destroy(p.location))
                        {
                            
                            projectiles.RemoveAt(i);
                            i--;

                            if (e.dead)
                            {
                                Items item = new Items();
                                item.Initialize(e.location);
                                items.Add(item);
                                enemies.RemoveAt(j);
                                j--;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy e = enemies.ElementAt(i);
                if (Math.Pow(player.location.X - e.location.X, 2) + Math.Pow(player.location.Y - e.location.Y, 2) > 10000000)
                {
                    enemies.RemoveAt(i);
                    i--;
                }

                if (enemies.Count > 0)
                { 
                    if (player.Hit(e))
                    {
                        player.Damage();
                    }
                }
            }

            for (int i = 0; i < items.Count; i++)
            {
                Items item = items.ElementAt(i);
                item.Update(gameTime);
                if (item.expired)
                {
                    items.RemoveAt(i);
                    i--;
                }
            }

                return this;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Vector2 translation = new Vector2(-camera.X, -camera.Y);
            Matrix cameraMatrix = Matrix.CreateTranslation(translation.X, translation.Y, 0);

            //draws sprite to game
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None,
                    RasterizerState.CullCounterClockwise, null, cameraMatrix);
            //spriteBatch.Begin();
            //spriteBatch.Draw(mouseTexture, mouseLocation, Color.White);

            world.Draw(spriteBatch, camera, viewport);

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

           

            for (int i = 0; i < items.Count; i++)
            {
                Items item = items.ElementAt(i);
                item.Draw(spriteBatch, frameTime);
            }

            player.Draw(spriteBatch, frameTime, camera);
            spriteBatch.End();
        }
    }
}
