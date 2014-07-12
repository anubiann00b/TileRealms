using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms
{
    class Ally
    {
        public Sprite sprite;
        public Vector2 location;

        public void Initialize(Vector2 l)
        {
            location = l;

            sprite = new Sprite(new TextureLibrary[] 
                {
                    TextureLibrary.PLAYER_RIGHT,
                    TextureLibrary.PLAYER_UP,
                    TextureLibrary.PLAYER_LEFT,
                    TextureLibrary.PLAYER_DOWN 
                },
                4, new Vector2(16, 16), 166
            );
        }

        public void Update(double time)
        {

        }

        public void Draw(SpriteBatch spriteBatch, double time)
        {
            sprite.Draw(spriteBatch, time, location);
        }
    }
}
