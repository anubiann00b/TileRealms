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
        private List<int> defense;
        private List<int> experience;
        private List<int> speed;

        public EnemyDatabase()
        {
            enemyData = new List<EnemyAttributes>();
            names = new List<string>();
            health = new List<int>();
            attack = new List<int>();
            defense = new List<int>();
            experience = new List<int>();
            speed = new List<int>();

            Initialize();
        }

        private void Initialize()
        {    
            LoadNames();
            LoadHealth();
            LoadAttack();
            LoadDefense();
            LoadEXP();
            LoadSpeed();

            MergeLists();
        }

        private void MergeLists()
        {
            for (int i = 0; i < names.Count; i++)
            {
                EnemyAttributes ea = new EnemyAttributes(names[i], health[i], attack[i], defense[i], experience[i], speed[i]);
                enemyData.Add(ea);
                Debug.WriteLine("Name:" + names[i] + "|| Attack:" + attack[i] + "|| Defense:" + defense[i] + "|| EXP:" + experience[i] + "|| speed:" + speed[i]);
            }
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
            var path = @"Assets\Data\attack.txt";
            var InstalledLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var file = await InstalledLocation.GetFileAsync(path);
            var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
            foreach (var line in readFile)
            {
                attack.Add(Convert.ToInt32(line));
            }
        }

        private async void LoadDefense()
        {
            var path = @"Assets\Data\defense.txt";
            var InstalledLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var file = await InstalledLocation.GetFileAsync(path);
            var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
            foreach (var line in readFile)
            {
                defense.Add(Convert.ToInt32(line));
            }
        }

        private async void LoadEXP()
        {
            var path = @"Assets\Data\exp.txt";
            var InstalledLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var file = await InstalledLocation.GetFileAsync(path);
            var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
            foreach (var line in readFile)
            {
                experience.Add(Convert.ToInt32(line));
            }
        }

        private async void LoadSpeed()
        {
            var path = @"Assets\Data\speed.txt";
            var InstalledLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var file = await InstalledLocation.GetFileAsync(path);
            var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
            foreach (var line in readFile)
            {
                speed.Add(Convert.ToInt32(line));
            }
        }

    }
}
