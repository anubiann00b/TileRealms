using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace TileRealms
{
    class ServerTCP
    {
        StreamSocketListener socketListener;
        ServerManager manager;
        int clientCounter;

        public void Start(ServerManager m)
        {
            clientCounter = 0;
            manager = m;
            socketListener = new StreamSocketListener();
            IAsyncAction bindAction = socketListener.BindServiceNameAsync("9999");
            Task.WaitAny(bindAction.AsTask());
            socketListener.ConnectionReceived += ClientConnectionRecieved;

            Task.Run(() => MonitorAndUpdate());
        }

        private void MonitorAndUpdate()
        {
            
        }

        private void ClientConnectionRecieved(StreamSocketListener server, StreamSocketListenerConnectionReceivedEventArgs eventArgs)
        {
            StreamSocket client = eventArgs.Socket;
            DataWriter dataOut = new DataWriter(client.OutputStream);
            DataReader dataIn = new DataReader(client.InputStream);

            Interlocked.Increment(ref clientCounter);
            dataOut.WriteInt32(Interlocked.Increment(ref clientCounter));

            // For testing, echo.
            Debug.WriteLine(dataIn.ReadInt32());

            string ip = eventArgs.Socket.Information.RemoteAddress.CanonicalName;
            string port = client.Information.RemotePort;

            manager.AddClient(client, ip, port);
        }
    }
}
