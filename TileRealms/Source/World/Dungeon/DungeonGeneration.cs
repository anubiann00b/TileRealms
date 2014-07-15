using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using System.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Xml;


namespace TileRealms.Source.World.Dungeon
{
    class DungeonGeneration
    {
        List<Rectangle> rooms;
        List<Tile[,]> Dungeon;
        Random r;
        Viewport viewport;
        Vector2 world;

        public DungeonGeneration(Viewport vp, Vector2 wrld)
        {
            r = new Random();
            int scrap = r.Next();
            viewport = vp;
            world = wrld;
            Initialize();
        }

        private void Initialize()
        {
            Rectangle room = new Rectangle(r.Next(0, (int)world.X), r.Next(0, (int)world.Y), r.Next(viewport.Width / 5, viewport.Width * 4), r.Next(viewport.Height / 5, viewport.Height * 4));
            rooms.Add(room);
        }

        public void CreateRooms()
        {
            int max =  r.Next(5, 15);
            while (rooms.Count < max)
            {
                Rectangle room = new Rectangle(r.Next(0, (int)world.X), r.Next(0, (int)world.Y), r.Next(viewport.Width / 5, viewport.Width * 4), r.Next(viewport.Height / 5, viewport.Height * 4));

                bool isBreakable = false;
                for (int x = 0; x < rooms.Count; x++)
                {
                    if (rooms.ElementAt(x).Intersects(room))
                    {
                        isBreakable = true;
                    }
                    if (isBreakable) break;
                }
                if (isBreakable) continue;

                else
                {
                    rooms.Add(room);
                }
            }
        }

        public void DisplayRooms()
        {  
            for (int i = 0; i < rooms.Count; i++)
            {
                Dungeon[i] = new Tile[(rooms.ElementAt(i).Width / 64) + 1, rooms.ElementAt(i).Height + 1];
                for (int x = 0; x < rooms.ElementAt(i).Width + 1; x++)
                {
                    for (int y = 0; y < rooms.ElementAt(i).Height + 1; y++)
                    {
                        Dungeon.ElementAt(i)[x, y] = Tile.TILE_WATER;
                    }
                }
            }
        }

        public void DrawRooms(SpriteBatch spriteBatch, Vector2 camera, Viewport view)
        {
            for (int a = ; a < Dungeon.Count; a++)
            {
                for (int i = (int)(camera.X / 64); i < (int)((camera.X + view.Width) / 64) + 1; i++)
                {
                    for (int j = (int)(camera.Y / 64); j < (int)((camera.Y + view.Height) / 64) + 1; j++)
                    {
                        if (i >= Dungeon[a].GetLength(0) || j >= Dungeon[a].GetLength(1))
                            continue;
                        Dungeon[a][i, j].Draw(spriteBatch, new Vector2(i * 64, j * 64));
                    }
                }
            }
        }
    }
}