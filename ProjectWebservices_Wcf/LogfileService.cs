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

        static List<Logfile> pending = new List<Logfile>() { new Logfile("id1", "al1", "navn1", "af1", "b1") };
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

		public Logfile SendLogString(string txt)
		{
			string[] split = txt.Split('	');
			string tid = split[0];
			string id = split[1];
			string alarm = split[2];
			string navn = split[3];
			string afdeling = split[4];
			string bolig = split[5];
			string afmeldt = split[7];
			Logfile l = new Logfile(id, alarm, navn, afdeling, bolig);
			l.Time = Convert.ToDateTime(tid);
			l.Disposed = Convert.ToDateTime(afmeldt);
			logs.Add(l);
			return l;
		}

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

        public bool Log(string id, string alarm, string name, string department, string apartment)
        {
            if(id != "" && alarm != "" && name != "" && department != "" && apartment != "")
            {
                Logfile log = new Logfile(id, alarm, name, department, apartment);
                logs.Add(log);

                CheckAlarm(log);
                return true;
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
                Logfile log = new Logfile(composite.ID, composite.Alarm, composite.Navn, composite.Afdeling, composite.Bolig);
                logs.Add(log);

                CheckAlarm(log);
			}
			return composite;
		}

        public List<Logfile> ReadPendingAlarms()
        {
            List<Logfile> list = new List<Logfile>(pending);
            pending.Clear();
            return (list ?? null);
        }

        private void CheckAlarm(Logfile log)
        {
            if (log.Name.ToLower() == "else")
            {
                pending.Add(log);
                return;
            }
        }
    }
}
