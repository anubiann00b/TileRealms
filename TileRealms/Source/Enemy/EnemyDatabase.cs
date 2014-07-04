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
        List<string> names;
        List<int> health;
        List<int> strength;
        List<int> exp;

        public EnemyDatabase()
        {
            Initialize();
        }

        private async void Initialize()
        {
            // settings
            // same as (ms-appx:///MyFolder/MyFile.txt)
            var _Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            _Folder = await _Folder.GetFolderAsync("Source");

            // acquire file
            var _File = await _Folder.GetFileAsync("names.txt");
            Debug.WriteLine(_File.OpenReadAsync());
        }
    }
}
