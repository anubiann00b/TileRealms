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
        ServerManager manager;

        public void Start(ServerManager m)
        {
            manager = m;
            socket = new DatagramSocket();
            IAsyncAction bindAction = socket.BindServiceNameAsync("9998");
            Task.WaitAny(bindAction.AsTask());
            socket.MessageReceived += HandlePacketRecieved;

            Task.Run(() => UpdateAllClients());
        }

        private void HandlePacketRecieved(DatagramSocket socket, DatagramSocketMessageReceivedEventArgs eventArgs)
        {
            DataReader dataIn = eventArgs.GetDataReader();
            HostName ip = eventArgs.RemoteAddress;
            string port = eventArgs.RemotePort;

            for (int i = 0; i < manager.clients.Count; i++)
            {
                Client c = manager.clients.ElementAt(i);

                if (c.Equals(ip, port))
                {
                    UpdateClient(c, dataIn);
                    return;
                }
            }

            // Ignore unknown sources.
        }

        private void UpdateClient(Client c, DataReader data)
        {
            c.ally.location.X = data.ReadSingle();
            c.ally.location.Y = data.ReadSingle();
        }

        public async void UpdateAllClients()
        {
            for (int i = 0; i < manager.clients.Count; i++)
            {
                Client c = manager.clients.ElementAt(i);

                IOutputStream o = await socket.GetOutputStreamAsync(c.ip, c.port);
                DataWriter dataOut = new DataWriter(o);

                dataOut.WriteSingle(manager.player.location.X);
                dataOut.WriteSingle(manager.player.location.Y);

                dataOut.FlushAsync();
            }
        }
    }
}
