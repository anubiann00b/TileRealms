using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TileRealms
{
    class World
    {
        private Tile[,] map;

        public World(int w, int h)
        {
            map = new Tile[w,h];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    map[i, j] = Tile.TILE_GRASS;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, int camX, int camY, int screenWidth, int screenHeight)
        {
            for (int i = camX / 64; i < (camX - screenWidth) / 64; i++)
            {
                for (int j = camY / 64; j < (camY - screenHeight) / 64; j++)
                {
                    map[i, j].Draw(spriteBatch, new Vector2(i * 64, j * 64));
                }
            }
        }
    }
}
