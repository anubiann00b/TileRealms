using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace TileRealms
{
    class ServerUDP
    {
        DatagramSocket socket;

        public void Start()
        {
            socket = new DatagramSocket();
            IAsyncAction bindAction = socket.BindServiceNameAsync("9999");
            Task.WaitAny(bindAction.AsTask());
            Task.Run(() => Write());

            socket.MessageReceived += HandlePacketRecieved;
        }

        private void HandlePacketRecieved(DatagramSocket socket, DatagramSocketMessageReceivedEventArgs eventArgs)
        {
            DataReader dataIn = eventArgs.GetDataReader();
        }

        public void Write()
        {
            DataWriter dataOut = new DataWriter(socket.OutputStream);

            dataOut.WriteInt32(42);
        }
    }
}
