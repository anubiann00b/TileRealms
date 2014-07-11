using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Diagnostics.Tracing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Windows.Storage;

namespace TileRealms.Source.Items
{
    class ItemProfile
    {
        public string Name;
        public string Attribute;
        public int Amount;
        public double DropRate;

        public ItemProfile(string name, string attr, int attramt, int droprate)
        {
            Name = name;
            Attribute = attr;
            Amount = attramt;
            DropRate = droprate;
        }
    }
}

