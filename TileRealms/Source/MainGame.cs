using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics.Tracing;
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
        Random r;

        World world;

        Vector2 camera;
        Vector2 worldSize;

        Texture2D mouseTexture;
        Vector2 mouseLocation;

        List<Enemy> enemies;
        List<Projectile> projectiles;
        EnemyController spawner;

        double ttime;

        public MainGame()
        {
            camera = new Vector2();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            worldSize = new Vector2(3600, 3600);
            world = new World(worldSize);
            enemies = new List<Enemy>();
            projectiles = new List<Projectile>();
            r = new Random();
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;

            TextureLibrary.LoadLibraryContent(Content);

            r = new Random();

            viewport = GraphicsDevice.Viewport;

            player = new Player();
            player.Initialize(viewport);

            Enemy e = new Enemy();
            e.Initialize(new RandomWalk(), new Vector2(0, 0));
            enemies.Add(e);

            Projectile p = new Projectile(new Vector2(0,0));
            p.Initialize(new MovementLinear(245,1));
            projectiles.Add(p);

            ttime = 0f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Tile.LoadTiles(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);

            mouseTexture = Content.Load<Texture2D>("Random_warrior");
            
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

            //PROJECTILE SYSTEM
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                ttime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (ttime > 300)
                {
                    Projectile p = new Projectile(player.location);
                    System.Diagnostics.Debug.WriteLine(mouseState.X + " " + mouseState.Y));
                    double dir = Math.Atan2(viewport.Width / 2 - mouseState.Y, viewport.Height / 2 - mouseState.X);
                    p.Initialize(new MovementLinear(dir, 5));
                    projectiles.Add(p);
                    ttime = 0;
                }

            }

            else if (mouseState.LeftButton == ButtonState.Released)
            { ttime = 300; }
            //PROJECTILE SYSTEM

            if ((r.Next(100) == 0) && enemies.Count < 1000)
            {
                Enemy e = new Enemy();
                e.Initialize(new RandomWalk(), new Vector2(r.Next(viewport.Width), r.Next(viewport.Height)));
                enemies.Add(e);
            }

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

            //draws sprite to game
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None,
                    RasterizerState.CullCounterClockwise, null, cameraMatrix);
            spriteBatch.Draw(mouseTexture, mouseLocation, Color.White);

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
