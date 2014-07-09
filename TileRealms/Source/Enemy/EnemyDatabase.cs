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
        private List<string> names;
        private List<int> health;
        private List<int> attack;
        //private List<int> defense;
        //   NOT USABLE YET
        //private List<int> experience;
        private List<int> speed; //FOR NOW IT'S DEFAULT
        //WON'T BE USED FOR A WHILE

        public EnemyDatabase()
        {
            enemyData = new List<EnemyAttributes>();
            Initialize();
        }

        private void Initialize()
        {
            /*
            LoadNames();
            LoadHealth();
            LoadAttack();
             * */
        }

        private async void LoadNames()
        {
            var path = @"Assets\Data\names.txt";
            var InstalledLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var file = await InstalledLocation.GetFileAsync(path);
            var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
            foreach (var line in readFile)
            {
                names.Add(line);
            }
        }

        private async void LoadHealth()
        {
            var path = @"Assets\Data\health.txt";
            var InstalledLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var file = await InstalledLocation.GetFileAsync(path);
            var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
            foreach (var line in readFile)
            {
                health.Add(Convert.ToInt32(line));
            }
        }

        private async void LoadAttack()
        {
            var path = @"Assets\Data\names.txt";
            var InstalledLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var file = await InstalledLocation.GetFileAsync(path);
            var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
            foreach (var line in readFile)
            {
                attack.Add(Convert.ToInt32(line));
            }
        }

        //NO DEFENSE OR EXPERIENCE METHOD YET
    }
}
