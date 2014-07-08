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


namespace TileRealms.Source.World
{

    class Map
    {
        Vector2 pointvariable = new Vector2();
        private readonly bool[,] cells;

        public Map(int width, int height)
        {
            cells = new bool[width, height];
        }

        public void MarkCellsUnvisited()
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    cells[x, y] = false;
        }

        public bool this[int x, int y]
        {
            get { return cells[x, y]; }
        }

        public int Width
        {
            get { return cells.GetUpperBound(0) + 1; }
        }

        public int Height
        {
            get { return cells.GetUpperBound(1) + 1; }
        }

        public void PickRandomCellAndMarkItVisited()
        {

            Random rnd1 = new Random();
            Random rnd2 = new Random();
            pointvariable.X = rnd1.Next(Width - 1);
            pointvariable.Y = rnd2.Next(Height - 1);
            cells[(int)pointvariable.X, (int)pointvariable.Y] = true;

        }

        public Map Generate()
        {
            Map map = new Map(10, 10);
            map.MarkCellsUnvisited();
            map.PickRandomCellAndMarkItVisited();

            return map;
        }

        public bool HasAdjacentCellInDirection(Point location, int direction)
        {

            // Check that the location falls within the bounds of the map
            if ((location.X < 0) || (location.X >= Width) || (location.Y < 0) || (location.Y >= Height)) return false;

            // Check if there is an adjacent cell in the direction
            switch (direction)
            {
                case 1://North
                    return location.Y > 0;
                case 2://West
                    return location.Y < (Height - 1);
                case 3://South
                    return location.X > 0;
                case 4://East
                    return location.X < (Width - 1);
                default:
                    return false;
            }
        }

        public bool AdjacentCellInDirectionIsVisited(Point location, int direction)
        {
            if (!HasAdjacentCellInDirection(location, direction)) throw new InvalidOperationException("No adjacent cell exists for the location and direction provided");

            switch (direction)
            {
                case 1://same as above
                    return this[location.X, location.Y - 1];
                case 2:
                    return this[location.X - 1, location.Y];
                case 3:
                    return this[location.X, location.Y + 1];
                case 4:
                    return this[location.X + 1, location.Y];
                default:
                    throw new InvalidOperationException();
            }
        }






    }
}
