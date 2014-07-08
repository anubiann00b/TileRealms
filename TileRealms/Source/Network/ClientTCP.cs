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
    class ClientTCP
    {
        StreamSocket socket;
        int id;

        public void Start()
        {
            socket = new StreamSocket();
            IAsyncAction bindAction = socket.ConnectAsync(new HostName("127.0.0.1"), "9998"); ;
            Task.WaitAny(bindAction.AsTask());
            Task.Run(() => Read());
        }

        public void Read()
        {
            DataWriter dataOut = new DataWriter(socket.OutputStream);
            DataReader dataIn = new DataReader(socket.InputStream);

            id = dataIn.ReadInt32();

            dataOut.WriteInt32(id);
        }
    }
}
