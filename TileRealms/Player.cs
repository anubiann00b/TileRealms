using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TileRealms
{
    class Player
    {
        //Class for the main player
        Viewport viewport;
        Texture2D texture;
        Rectangle destRect;
        Rectangle srcRect; //48 x 48
        Vector2 frames;
        Vector2 location;
        int size;

        public void Initialize(Viewport _vp)
        {
            // TODO: Add your initialization logic here
            viewport = _vp; //Viewport is the screen resolution. You can get height / width properties.
            
            if (viewport.Width > viewport.Height)
                size = viewport.Height / 10;

            else
                size = viewport.Height / 10;

            frames = new Vector2(0, 0);
            destRect = new Rectangle((int)location.X, (int)location.Y, size, size);
            srcRect = new Rectangle((int)frames.X, (int)frames.Y, 48, 48);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public void LoadContent(ContentManager Content)
        {
            // TODO: use this.Content to load your game content here
            texture = Content.Load<Texture2D>("Basic-spritesheet");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        public void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // TODO: Add your drawing code here
            spriteBatch.Draw(texture, destRect, srcRect, Color.White);
        }
    }
}
