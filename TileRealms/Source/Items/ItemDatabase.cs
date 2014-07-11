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
    class ItemDatabase
    {
        public List<ItemProfile> itemData;

        public ItemDatabase()
        {
            itemData = new List<ItemProfile>();
            Initialize();
        }

        private void Initialize()
        {
            LoadList();
        }

        private async void LoadList()
        {
            var path = @"Assets\Data\items.txt";
            var InstalledLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var file = await InstalledLocation.GetFileAsync(path);
            var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
            foreach (var line in readFile)
            {
                ItemProfile ip = new ItemProfile("","", 0, 0);
            }
        }
    }
}

