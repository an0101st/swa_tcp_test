using example_8_client_console.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace example_8_client_console {
	class Program {
		private static Random rand = new Random();
		static void Main(string[] args) {
			Client client = new Client();

			while (true) {
				//ShipId@recorder,20000,25000|DVDPlayer,10000,20000|PCs,50000,200000
				string[] names = { "recorder", "muster", "test", "beds" };
				string msg = rand.Next(1, 100) + "@" + names[rand.Next(0, 3)] + "," + rand.Next(100, 30000) + "," + rand.Next(100, 500);
				Console.WriteLine(msg);
				client.Send(msg);
				Thread.Sleep(1000);
			}
		}
	}
}
