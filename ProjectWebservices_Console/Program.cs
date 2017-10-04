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
            while (true)
            {
                LogfileService.Logfile[] logs = client.ReadPendingAlarms();
                foreach (LogfileService.Logfile log in logs)
                {
                    Console.WriteLine($"Tid={log.Time}  ID={log.ID}  Alarm={log.Alarm}  Navn={log.Name}  Afdeling={log.Department}  Bolig={log.Apartment}  Afmeldt={(log.Disposed == null ? DateTime.MinValue : log.Disposed)}");
                }
                Thread.Sleep(5000);
            }
		}
	}
}
