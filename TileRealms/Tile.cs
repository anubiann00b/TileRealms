using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms
{
    class Tile
    {
        public static Tile TILE_GRASS = new Tile("grass_basic");
        //public static Tile TILE_WATER = new Tile("grass_water");
        //public static Tile TILE_WOOD = new Tile("grass_wood");

        private static Rectangle srcRect = new Rectangle(0, 0, 16, 16);
        private String file;
        private Texture2D texture;

        private Tile(String filename)
        {
            file = filename;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(texture, new Rectangle((int)location.X, (int)location.Y, 64, 64), srcRect, Color.White);
        }

        public static void LoadTiles(ContentManager content)
        {
            TILE_GRASS.LoadContent(content);
        }

        private void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(file);
        }
    }
}
