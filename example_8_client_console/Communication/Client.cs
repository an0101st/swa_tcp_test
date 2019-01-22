using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace example_8_client_console.Communication {
	public class Client {
		Socket clientSocket;
		
		public Client() {
			TcpClient client = new TcpClient();
			client.Connect(new IPEndPoint(IPAddress.Loopback, 10100));
			clientSocket = client.Client;
		}

		public void Send(string msg) {
			clientSocket.Send(Encoding.UTF8.GetBytes(msg));
		}
	}
}
