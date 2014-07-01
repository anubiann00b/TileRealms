using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms
{
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Viewport viewport;
        Player player;

        World world;

        Vector2 camera;
        Vector2 worldSize;

        List<Enemy> enemies;
        List<Projectile> projectiles;

        public MainGame()
        {
            camera = new Vector2();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            worldSize = new Vector2(1600, 1600);
            world = new World(worldSize);
            enemies = new List<Enemy>();
            projectiles = new List<Projectile>();
        }

        protected override void Initialize()
        {
            viewport = GraphicsDevice.Viewport;

            player = new Player();
            player.Initialize(viewport);

            Enemy e = new Enemy();
            e.Initialize(new RandomWalk());
            enemies.Add(e);

            Projectile p = new Projectile(new Vector2(0,0));
            p.Initialize(new MovementLinear(245,1));
            projectiles.Add(p);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Tile.LoadTiles(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadContent(Content);
            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy e = enemies.ElementAt(i);
                e.LoadContent(Content);
            }
            for (int i = 0; i < projectiles.Count; i++)
            {
                Projectile p = projectiles.ElementAt(i);
                p.LoadContent(Content);
            }
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            camera.X = MathHelper.Clamp(player.location.X, 0, worldSize.X - viewport.Width);
            camera.Y = MathHelper.Clamp(player.location.Y, 0, worldSize.Y - viewport.Height);

            double frameTime = gameTime.ElapsedGameTime.TotalMilliseconds * 60 / 1000.0;

            player.Update(frameTime, projectiles);

            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy e = enemies.ElementAt(i);
                e.Update(frameTime);
            }
            for (int i = 0; i < projectiles.Count; i++)
            {
                Projectile p = projectiles.ElementAt(i);
                p.Update(frameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            Vector2 translation = new Vector2(viewport.Width / 2 - camera.X, viewport.Height / 2 - camera.Y);
            Matrix cameraMatrix = Matrix.CreateTranslation(translation.X, translation.Y, 0);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None,
                    RasterizerState.CullCounterClockwise, null, cameraMatrix);
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

            player.Draw(spriteBatch, frameTime);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
