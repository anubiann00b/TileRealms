using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Diagnostics.Tracing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Windows.Storage;

namespace TileRealms.Source.Items
{
    class Items
    {
        public Sprite sprite;
        public Vector2 location;
        EnemyController controller;
        public bool expired = false;
        float totalTime = 0f;
        float expirationTime = 10;
        public void Initialize(Vector2 _location)
        {
            location = _location;

            sprite = new Sprite(new TextureLibrary[] 
                {
                    TextureLibrary.MAGIC_BALL_RED
                },
                1, new Vector2(16, 16), 166
            );
        }

        public void Update(GameTime gameTime)
        {
            totalTime += gameTime.ElapsedGameTime.Seconds; //just for demonstratino purposes    
            expired = totalTime > expirationTime;
        }

        public void Draw(SpriteBatch spriteBatch, double time)
        {
            sprite.Draw(spriteBatch, time, location);
        }
    }
}
