using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;

namespace TileRealms
{
    class Client
    {
        public Ally ally;
        public HostName ip;
        public string port;
        StreamSocket socket;

        public Client(StreamSocket s, HostName i, string p, Ally a)
        {
            socket = s;
            ip = i;
            port = p;
            ally = a;
        }

        public bool Equals(HostName i, string p)
        {
            return ip.Equals(i) && port.Equals(p);
        }
    }
}
