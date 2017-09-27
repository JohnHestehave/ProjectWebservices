using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjectWebservices_Wcf
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
	public class LogfileService : ILogfileService
	{
		static List<Logfile> logs = new List<Logfile>() {	new Logfile("id1", "al1", "navn1", "af1", "b1"),
															new Logfile("id2", "al2", "navn2", "af2", "b2")};

		public List<Logfile> ReadLogfiles()
		{
			if (logs.Count > 0)
			{
				return logs;
			}
			else
			{
				return null;
			}
		}
		/*public List<string> ReadLogfiles()
		{
			if (logs.Count > 0)
			{
				List<string> list = new List<string>();
				foreach (Logfile log in logs)
				{	
					list.Add(log.ToString());
				}
				return list;
			}
			else
			{
				return new List<string>() { "No logfiles to read." };
			}
		}*/

		public bool DisposeAlarm(string id)
		{
			if (logs.Count == 0) return false;
			foreach(Logfile log in logs)
			{
				if(log.ID == id)
				{
					if (log.Dispose()) {
						return true;
					}
				}
			}
			return false;
		}

		public CompositeType Log(CompositeType composite)
		{
			if (composite == null)
			{
				throw new ArgumentNullException("composite");
			}
			if (composite.ID != "" && composite.Alarm != "" && composite.Navn != "" && composite.Afdeling != "" && composite.Bolig != "")
			{
				logs.Add(new Logfile(composite.ID, composite.Alarm, composite.Navn, composite.Afdeling, composite.Bolig));
			}
			return composite;
		}
	}
}
