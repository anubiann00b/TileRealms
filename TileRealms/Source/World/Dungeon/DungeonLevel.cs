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
    class DungeonLevel
    {


/*
    1.Fill the whole map with solid earth
    2.Dig out a single room in the centre of the map
    3.Pick a wall of any room
    4.Decide upon a new feature to build
    5.See if there is room to add the new feature through the chosen wall
    6.If yes, continue. If no, go back to step 3
    7.Add the feature through the chosen wall
    8.Go back to step 3, until the dungeon is complete
    9.Add the up and down staircases at random points in map
    10.Finally, sprinkle some monsters and items liberally over dungeon 
*/


        //stores rooms that are created
        List<Rectangle> rectangleCollection = new List<Rectangle>();

        public int height;//height of rectangle
        public int width;//width of rectangle
        public int x;//x position of rectangle
        public int y;//y position of rectangle

        public void fillMap() { }

        public void createCenterRoom() { }
                
        public void PickWall() { }

        public void CheckIfRoomsOverlap() { }

        public void ConnectRooms() { }

        public void AddStairsAndAccessories() { }

        


       
    }
}