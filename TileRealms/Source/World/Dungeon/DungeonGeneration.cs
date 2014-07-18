﻿using System;
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
using TileRealms.Source.World.Dungeon;


namespace TileRealms.Source.World.Dungeon
{
    class DungeonGeneration
    {
        private static Random rnd = new Random();



        public static void main(String[] args)
        {
            List<Rectangle> rectangles = new List<Rectangle>(); // flat rectangle store to help pick a random one
            Rectangle root = new Rectangle(0, 0, 60, 120); //
            rectangles.add(root); //populate rectangle store with root area
            while (rectangles.size() < 19)
            { // this will give us 10 leaf areas
                int splitIdx = rnd.nextInt(rectangles.size()); // choose a random element
                Rectangle toSplit = rectangles.get(splitIdx);
                if (toSplit.split())
                { //attempt to split
                    rectangles.add(toSplit.leftChild);
                    rectangles.add(toSplit.rightChild);
                }

            }
            root.generateDungeon(); //generate dungeons

            printDungeons(rectangles); //this is just to test the output

        }



        private static void printDungeons(ArrayList<Rectangle> rectangles) {
        byte [][] lines = new byte[60][];
        for( int i = 0; i < 60; i++ ) {
            lines[ i ] = new byte[120];
            for( int j = 0; j < 120; j++ )
                lines[ i ][ j ] =  -1;
        }
        byte dungeonCount = -1;
        for( Rectangle r : rectangles ) {
            if( r.dungeon == null )
                continue;
            Rectangle d = r.dungeon;
            dungeonCount++;
            for( int i = 0; i < d.height; i++ ) {
                for( int j = 0; j < d.width; j++ )

                    lines[ d.top + i ][ d.left+ j ] = dungeonCount;
            }
        }
        for( int i = 0; i < 60; i++ ) {
            for( int j = 0; j < 120; j++ ) {
                if( lines[ i ][ j ] == -1 )
                    System.out.print( '.');
                else
                    System.out.print( lines[ i ][ j ] );
            }
            System.out.println();
        }
    }
    }
}