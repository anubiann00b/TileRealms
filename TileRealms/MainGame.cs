using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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


        /// <summary>
        /// A concise explanation for Shreyas
        /// 
        /// SpriteBatch: Important
        ///     - Mainly drawing items
        ///     - To draw: spriteBatch.Draw(_Texture2D, Vector2, Color);
        ///     - To draw: spriteBatch.Draw(_Texture2D, Rectangle, Color);
        ///     - Those are basic drawing. You can specify source and destination also.
        /// 
        /// Texture2D: 2D Images to draw
        ///     - Load it on Load method
        ///     - Unload if Texture is unnecessary
        /// Vector2: Important
        ///     - Simple Coordinate variable
        /// 
        /// Rectangle
        ///     - Basically Vector2 with Height + Width
        ///     
        /// Viewport
        ///     = Screen
        ///     
        /// 
        /// </summary>
        
        public MainGame()
        {
            camera = new Vector2();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            worldSize = new Vector2(1600,1600);
            world = new World(worldSize);
        }

        protected override void Initialize()
        {
            viewport = GraphicsDevice.Viewport;

            player = new Player();
            player.Initialize(viewport);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Tile.LoadTiles(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadContent(Content);
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            player.Update(gameTime);

            camera.X = MathHelper.Clamp(player.location.X, 0, worldSize.X - viewport.Width);
            camera.Y = MathHelper.Clamp(player.location.Y, 0, worldSize.Y - viewport.Height);
            
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
            player.Draw(spriteBatch, gameTime);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
