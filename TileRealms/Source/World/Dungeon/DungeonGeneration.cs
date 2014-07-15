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

            }
        }
    }
}