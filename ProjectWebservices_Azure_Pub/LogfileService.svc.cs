using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProjectWebservices_Azure_Pub
{
    public class LogfileService : ILogfileService
    {
        static List<Logfile> logs = new List<Logfile>();
        static List<Logfile> pending = new List<Logfile>();

        static List<string> NameCriteria = new List<string>() { "else", "hans", "tommy", "michael" };
        
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
            foreach (Logfile log in logs)
            {
                if (log.ID == id)
                {
                    if (log.Dispose())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Log(string id, string alarm, string name, string department, string apartment)
        {
            if (id != "" && alarm != "" && name != "" && department != "" && apartment != "")
            {
                Logfile log = new Logfile(id, alarm, name, department, apartment);
                logs.Add(log);
                UpdateLogTxt(log);
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
            foreach (var item in pending)
            {
                item.Disposed = DateTime.Now;
            }
            List<Logfile> list = new List<Logfile>(pending);
            pending.Clear();
            return (list.Count > 0 ? list : null);
        }

        private void CheckAlarm(Logfile log)
        {
            foreach (var person in NameCriteria)
            {
                if (log.Name.ToLower() == person)
                {
                    pending.Add(log);
                    return;
                }
            }
            DateTime dt22 = new DateTime();
            dt22.AddHours(22);

            DateTime dt6 = new DateTime();
            dt6.AddHours(6);
            
            if (log.Time.Hour > dt22.Hour || log.Time.Hour < dt6.Hour)
            {
                pending.Add(log);
                return;
            }
            
        }
        void UpdateLogTxt(Logfile log)
        {
            return; // ingen skriverettigheder
            StreamWriter sw = new StreamWriter("logdata.txt");
            sw.WriteLine(log.ToString());
            sw.Close();
        }
    }
}
