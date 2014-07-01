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

        public MainGame()
        {
            camera = new Vector2();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            worldSize = new Vector2(1600, 1600);
            world = new World(worldSize);
            enemies = new List<Enemy>();
        }

        protected override void Initialize()
        {
            viewport = GraphicsDevice.Viewport;

            player = new Player();
            player.Initialize(viewport);

            Enemy e = new Enemy();
            e.Initialize(new RandomWalk());
            enemies.Add(e);

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
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            camera.X = MathHelper.Clamp(player.location.X, 0, worldSize.X - viewport.Width);
            camera.Y = MathHelper.Clamp(player.location.Y, 0, worldSize.Y - viewport.Height);

            double frameTime = gameTime.ElapsedGameTime.TotalMilliseconds * 60 / 1000.0;

            player.Update(frameTime);

            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy e = enemies.ElementAt(i);
                e.Update(frameTime);
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

            player.Draw(spriteBatch, frameTime);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
