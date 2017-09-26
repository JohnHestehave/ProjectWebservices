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
		static List<Logfile> logs = new List<Logfile>();

		public string ReadLogfiles()
		{
			if (logs.Count > 0)
			{
				string list = string.Empty;
				foreach (Logfile log in logs)
				{
					list += log.ToString() + "\n";
				}
				return list;
			}
			else
			{
				return "No logfiles to read.";
			}
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
