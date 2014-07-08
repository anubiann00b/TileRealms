using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRealms
{
    interface NetworkManager
    {
        void Update();
        void Recieve();
        void Send();
    }
}
