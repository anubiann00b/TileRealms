using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Sockets;

namespace TileRealms
{
    class Client
    {
        StreamSocket socket;
        string ip;
        string port;
        Ally ally;

        public Client(StreamSocket s, string i, string p, Ally a)
        {
            socket = s;
            ip = i;
            port = p;
            ally = a;
        }

        public bool Equals(string i, string p)
        {
            return ip.Equals(i) && port.Equals(p);
        }
    }
}
