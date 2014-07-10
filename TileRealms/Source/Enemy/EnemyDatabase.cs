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

namespace TileRealms.Source.Enemy
{
    class EnemyDatabase
    {
        public List<EnemyAttributes> enemyData;

        public EnemyDatabase()
        {
            enemyData = new List<EnemyAttributes>();
            Initialize();
        }

        private void Initialize()
        {
            LoadList();
        }

        private async void LoadList()
        {
            var path = @"Assets\Data\enemyProfile.txt";
            var InstalledLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var file = await InstalledLocation.GetFileAsync(path);
            var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
            foreach (var line in readFile)
            {
                EnemyAttributes ea = new EnemyAttributes(line.Split(',')[0], Convert.ToInt32(line.Split(',')[1]), Convert.ToInt32(line.Split(',')[2]), Convert.ToInt32(line.Split(',')[3]), Convert.ToInt32(line.Split(',')[4]), Convert.ToInt32(line.Split(',')[5]));
            }
        }
    }
}
