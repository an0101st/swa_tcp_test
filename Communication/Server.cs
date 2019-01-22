using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace example_8_server.Communication {
	public class Server {
		Socket serverSocket;
		List<ClientHandler> Clients;
		Action<string> GuiUpdater;

		public Server(Action<string> guiUpdater) {
			Clients = new List<ClientHandler>();
			GuiUpdater = guiUpdater;
			serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			serverSocket.Bind(new IPEndPoint(IPAddress.Loopback, 10100));
			serverSocket.Listen(10);

			Task.Factory.StartNew(StartAccepting);
		}

		private void StartAccepting() {
			while (true) {
				Clients.Add(new ClientHandler(serverSocket.Accept(), GuiUpdater));
			}
		}
	}
}
