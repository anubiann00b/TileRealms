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

        public World(Vector2 worldSize)
        {
            map = new Tile[(int)(worldSize.X / 64), (int)(worldSize.Y / 64)];
            for (int i = 0; i < (int)(worldSize.X / 64); i++)
            {
                for (int j = 0; j < (int)(worldSize.Y / 64); j++)
                {
                    map[i, j] = Tile.TILE_GRASS;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, int camX, int camY, int screenWidth, int screenHeight)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j].Draw(spriteBatch, new Vector2(i * 64, j * 64));
                }
            }
        }
    }
}
