using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectWebservices_Console
{
	class Program
	{
		static void Main(string[] args)
		{
			LogfileService.LogfileServiceClient client = new LogfileService.LogfileServiceClient();
			LogfileService.Logfile[] logs = client.ReadLogfiles();
			Console.WriteLine("Logfiles:");
			Console.WriteLine("---------");
			foreach (var log in logs)
			{
				Console.WriteLine(log.ID);
			}
			Console.WriteLine("---------");
			Console.WriteLine();
			Console.WriteLine("Nye logs:");
			Console.WriteLine("---------");

			TcpListener listener = new TcpListener(IPAddress.Any, 1200);
			listener.Start();
			while (true)
			{
				Socket socket = listener.AcceptSocket();
				NetworkStream stream = new NetworkStream(socket);
				StreamReader sr = new StreamReader(stream);
				StreamWriter sw = new StreamWriter(stream);
				sw.AutoFlush = true;
				try
				{
					while (true)
					{
						string request = sr.ReadLine();
						Console.WriteLine("Request: "+request);
					}
				}catch(Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}
		}
	}
}
