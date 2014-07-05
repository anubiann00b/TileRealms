using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Networking.Sockets;

namespace TileRealms
{
    class ServerTCP
    {
        StreamSocketListener socketListener;

        public void Start()
        {
            socketListener = new StreamSocketListener();
            IAsyncAction bindAction = socketListener.BindServiceNameAsync("9999");
            Task.WaitAny(bindAction.AsTask());
            socketListener.ConnectionReceived += ClientConnectionRecieved;
        }

        private void ClientConnectionRecieved(StreamSocketListener sl, StreamSocketListenerConnectionReceivedEventArgs eventArgs)
        {
            
        }

        private void HandleClientConnection()
        {
            
        }
    }
}
