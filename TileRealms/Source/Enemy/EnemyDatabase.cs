using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Diagnostics.Tracing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void Initialize()
        {
            //read names
            /*
            for (int i = 0; i < //length//; i++)
            {
                string name = //file.read or something
                names.Add(name);
            }
            */
        }
    }
}
