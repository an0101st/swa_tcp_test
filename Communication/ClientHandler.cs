using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace example_8_server.Communication {
	class ClientHandler {
		private Socket clientSocket;
		byte[] buffer = new byte[512];
		private Action<string> Updater;

		public ClientHandler(Socket socket, Action<string> guiUpdater) {
			this.clientSocket = socket;
			this.Updater = guiUpdater;

			Task.Factory.StartNew(Receive);
		}

		private void Receive() {
			while (true) {
				int len = clientSocket.Receive(buffer);
				Updater(Encoding.UTF8.GetString(buffer, 0, len));
			}
		}
	}
}
