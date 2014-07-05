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
            IAsyncAction bindAction = socket.ConnectAsync(new HostName("127.0.0.1"), "9999"); ;
            Task.WaitAny(bindAction.AsTask());



            Task.Run(() => Read());
        }

        public void Read()
        {
            IInputStream clientIn = socket.InputStream;
            IOutputStream clientOut = socket.OutputStream;

            DataWriter dataOut = new DataWriter(clientOut);
            DataReader dataIn = new DataReader(clientIn);

            id = dataIn.ReadInt32();

            dataOut.WriteInt32(id);
        }
    }
}
