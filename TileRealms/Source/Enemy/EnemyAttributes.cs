using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms.Source.Enemy
{
    class EnemyAttributes
    {
        public string name;
        public int hp;
        public int ap;
        public int dp;
        public int exp;
        public int speed;

        public EnemyAttributes(string Name, int health, int attack, int defense, int experience, int Speed)
        {
            name = Name;
            hp = health;
            dp = defense;
            exp = experience;
            speed = Speed;
        }
    }
}
