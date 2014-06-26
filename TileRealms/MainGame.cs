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


        Player MainPlayer;

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
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            viewport = GraphicsDevice.Viewport;

            MainPlayer = new Player();
            MainPlayer.Initialize(viewport);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            MainPlayer.LoadContent(Content);
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            MainPlayer.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            MainPlayer.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
