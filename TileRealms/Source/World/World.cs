using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms
{
    class World
    {
        private Tile[,] map;

        public World(Vector2 worldSize)
        {
            map = new Tile[(int)(worldSize.X / 64) + 1, (int)(worldSize.Y / 64) + 1];
            for (int i = 0; i < (int)(worldSize.X / 64) + 1; i++)
            {
                for (int j = 0; j < (int)(worldSize.Y / 64) + 1; j++)
                {
                    //change this line to create biomes
                    map[i, j] = Tile.TILE_WATER;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 camera, Viewport view)
        {
            for (int i = (int)(camera.X / 64); i < (int)((camera.X + view.Width) / 64) + 1; i++)
            {
                for (int j = (int)(camera.Y / 64); j < (int)((camera.Y + view.Height) / 64) + 1; j++)
                {
                    if (i >= map.GetLength(0) || j >= map.GetLength(1))
                        continue;
                    map[i, j].Draw(spriteBatch, new Vector2(i * 64, j * 64));
                }
            }
        }
    }
}
