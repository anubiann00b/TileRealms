using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileRealms
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch; //Draw
        Viewport viewport; //The screen 


        Player MainPlayer; //The Main Character

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
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            viewport = GraphicsDevice.Viewport; //Viewport is the screen resolution. You can get height / width properties.

            MainPlayer = new Player();
            MainPlayer.Initialize(viewport);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            MainPlayer.LoadContent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            MainPlayer.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            MainPlayer.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
