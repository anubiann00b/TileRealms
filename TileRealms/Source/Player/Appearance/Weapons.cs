using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics.Tracing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileRealms.Source.Player;
using TileRealms.Source.Items;
using TileRealms.Source.Health;

namespace TileRealms.Source.Player.Appearance
{
    class Weapons
    {
        Viewport viewport;

        Sprite sprite;  
        public Vector2 location;
        Vector2 size;

        public Weapons(Viewport vp)
        {
            viewport = vp;
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

        public void Update(Vector2 playerLocation)
        {
            location.X = playerLocation.X;
            location.Y = playerLocation.Y;
        }

        public void Draw(SpriteBatch spriteBatch, double time)
        {
            sprite.Draw(spriteBatch, time, location);
        }
    }
}
