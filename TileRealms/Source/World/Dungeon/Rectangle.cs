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
    class Rectangle
    {
        private static int MIN_SIZE = 5;
        private static Random rnd = new Random();

        public int top;
        public int left;
        public int width;
        public int height;
        public Rectangle leftChild;
        public Rectangle rightChild;
        public Rectangle dungeon;

        public Rectangle(int top, int left, int height, int width)
        {
            this.top = top;
            this.left = left;
            this.width = width;
            this.height = height;
        }

        public bool split()
        {
            if (leftChild != null) //if already split, bail out
                return false;
            int number = rnd.Next();
            bool horizontal = (number % 2 == 0); //direction of split
            int max = (horizontal ? height : width) - MIN_SIZE; //maximum height/width we can split off
            if (max <= MIN_SIZE) // area too small to split, bail out
                return false;
            int split = rnd.Next(max); // generate split point 
            if (split < MIN_SIZE)  // adjust split point so there's at least MIN_SIZE in both partitions
                split = MIN_SIZE;
            if (horizontal)
            { //populate child areas
                leftChild = new Rectangle(top, left, split, width);
                rightChild = new Rectangle(top + split, left, height - split, width);
            }
            else
            {
                leftChild = new Rectangle(top, left, height, split);
                rightChild = new Rectangle(top, left + split, height, width - split);
            }
            return true; //split successful
        }

        public void generateDungeon()
        {
            if (leftChild != null)
            { //if current are has child areas, propagate the call
                leftChild.generateDungeon();
                rightChild.generateDungeon();
            }
            else
            { // if leaf node, create a dungeon within the minimum size constraints
                int dungeonTop = (height - MIN_SIZE <= 0) ? 0 : rnd.Next(height - MIN_SIZE);
                int dungeonLeft = (width - MIN_SIZE <= 0) ? 0 : rnd.Next(width - MIN_SIZE);
                int dungeonHeight = Math.Max(rnd.Next(height - dungeonTop), MIN_SIZE); ;
                int dungeonWidth = Math.Max(rnd.Next(width - dungeonLeft), MIN_SIZE); ;
                dungeon = new Rectangle(top + dungeonTop, left + dungeonLeft, dungeonHeight, dungeonWidth);
            }
        }
    
        


       
    }
}