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
            map = new Tile[(int)(worldSize.X / 64), (int)(worldSize.Y / 64)];
            for (int i = 0; i < (int)(worldSize.X / 64); i++)
            {
                for (int j = 0; j < (int)(worldSize.Y / 64); j++)
                {
                    map[i, j] = Tile.TILE_GRASS;
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
                    map[i, j].Draw(spriteBatch, new Vector2(i * 64 - view.Width / 2, j * 64 - view.Height / 2));
                }
            }
        }
    }
}
