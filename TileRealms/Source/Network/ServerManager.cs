using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms
{
    class ServerManager : NetworkManager
    {
        List<Projectile> projectiles;
        List<Enemy> enemies;
        List<Ally> allies;
        Player player;
        World world;

        ServerTCP tcp;

        public ServerManager(List<Projectile> p, List<Enemy> e, List<Ally> a, Player pl, World w)
        {
            projectiles = p;
            enemies = e;
            allies = a;
            player = pl;
            world = w;
        }

        public void Update()
        {
            
        }

        public void Recieve()
        {
            
        }

        public void Send()
        {

        }
    }
}
