using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;

namespace TileRealms
{
    class ServerManager : NetworkManager
    {
        public Player player;
        List<Projectile> projectiles;
        List<Enemy> enemies;
        List<Ally> allies;
        World world;

        public List<Client> clients;

        ServerTCP tcp;

        public ServerManager(List<Projectile> p, List<Enemy> e, List<Ally> a, Player pl, World w)
        {
            projectiles = p;
            enemies = e;
            allies = a;
            player = pl;
            world = w;
        }

        public void AddClient(StreamSocket s, HostName ip, string port)
        {
            Ally a = new Ally();
            a.Initialize(new Vector2());
            Client c = new Client(s, ip, port, a);
            clients.Add(c);
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
