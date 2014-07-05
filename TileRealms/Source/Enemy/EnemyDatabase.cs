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
using Windows.Storage;

namespace TileRealms.Source.Enemy
{
    class EnemyDatabase
    {
        public List<string> names;
        public List<int> health;
        public List<int> attack;
        public List<int> exp;

        public EnemyDatabase()
        {
            names = new List<string>();
            health = new List<int>();
            attack = new List<int>();
            exp = new List<int>();
            Initialize();
        }

        private void Initialize()
        {
            /* SOMEHOW FIND THE FOLDER
            var _Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            _Folder = await _Folder.GetFolderAsync("Source");

             * 
             *THEN READ THE FILE
             * 
            // acquire file
            var _File = await _Folder.GetFileAsync("names.txt");
            Debug.WriteLine(_File.OpenReadAsync());
             * 
                USE UNITEDJAYMO.COM/[RANDOMHASH]/NAMES.TXT
             */
            int limit = 1; ; //Just scrap
            for (int i = 0; i < limit; i++)
            {
                string monster_name = "";
                names.Add(monster_name);
            }

            for (int i = 0; i < limit; i++)
            {
                int monster_health = 100;
                health.Add(monster_health);
            }

            for (int i = 0; i < limit; i++)
            {
                int monster_attack = 0;
                attack.Add(monster_attack);
            }

            for (int i = 0; i < limit; i++)
            {
                int monster_exp = 1;
                exp.Add(monster_exp);
            }
        }
    }
}
