using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using System.Windows;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Xml;
using Windows.Storage;


namespace TileRealms.Source.World.Dungeon
{
    //fix code time
    class GenerateDungeon
    {

        private static Random rnd = new Random(); 

        public void Initialize() 
        {
            List<Rectangle> rectangles = new List<Rectangle>(); // flat rectangle store to help pick a random one

            Rectangle root = new Rectangle( 0, 0, 60, 120 ); //
            rectangles.Add(root); //populate rectangle store with root area

            while(rectangles.Count < 19) //10 leaf areas
            { 
                int splitIdx = rnd.Next(rectangles.Count); // choose a random element
                Rectangle toSplit = rectangles.ElementAt(splitIdx); 

                if(toSplit.split()) 
                {
                    rectangles.Add(toSplit.leftChild);
                    rectangles.Add(toSplit.rightChild);
                } 

            }

            root.generateDungeon();
            printDungeons(rectangles); ///I fixed everything it runs, but i can't see the rooms
        }


        private async static void printDungeons(List<Rectangle> rectangles) {
            int [,] lines = new int[60, 120];
        
            for (int i = 0; i < 60; i++) // i think thi'll work hopefully if it doesn't we can revert//I'll fix it if it doesn't work
            { 
                for(int j = 0; j < 120; j++) // no no no i dont undrstand this line wtf ^
                    lines[i, j] =  -1;
        
            }
            int dungeonCount = -1;//why is this an error? //wait hodl on byte cant have negative number//wait yea
            foreach (Rectangle r in rectangles) //okay but pleaes let's get the spacings correct omg this is horrible//copy paste straight from eclipse
            {
                if (r.dungeon == null) //yo let's remove all the comments so we look legitimate LOL okay //lets not the important stuff, cuase Shreyas might need to understand stuff//THis isn't usaco
                    continue;
                Rectangle d = r.dungeon;
                dungeonCount++;
                for (int i = 0; i < d.height; i++) 
                {
                    for (int j = 0; j < d.width; j++)
                        lines[d.top + i, d.left+ j] = dungeonCount;
                }
            }

            var path = @"dungeonGenerate.txt";
            var InstalledLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var file = await InstalledLocation.GetFileAsync(path);

            if ((file.Attributes & FileAttributes.ReadOnly) > 0)
                Debug.WriteLine("IT'S READ ONLY THE WORLD IS NOW OVER");

            for (int i = 0; i < 60; i++) 
            {
                string line = "";
                for (int j = 0; j < 120; j++) 
                {
                    if (lines[i, j] == -1)
                        line += ".";
                    else
                        line += lines[i, j];
                }
                Debug.WriteLine(line);
            }
        }
    }
}
