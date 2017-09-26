using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWebservices_Wcf
{
	public class Logfile
	{

		#region variables
		private DateTime _Tid;
		private string _ID;
		private string _Alarm;
		private string _Navn;
		private string _Afdeling;
		private string _Bolig;
		#endregion

		#region properties
		public DateTime Tid
		{
			get { return _Tid; }
			set { _Tid = value; }
		}
		public string ID
		{
			get { return _ID; }
			set { _ID = value; }
		}
		public string Alarm
		{
			get { return _Alarm; }
			set { _Alarm = value; }
		}
		public string Navn
		{
			get { return _Navn; }
			set { _Navn = value; }
		}
		public string Afdeling
		{
			get { return _Afdeling; }
			set { _Afdeling = value; }
		}
		public string Bolig
		{
			get { return _Bolig; }
			set { _Bolig = value; }
		}
		#endregion

		#region constructor
		public Logfile(string id, string alarm, string navn, string afdeling, string bolig)
		{
			Tid = DateTime.Now;
			ID = id;
			Alarm = alarm;
			Navn = navn;
			Afdeling = afdeling;
			Bolig = bolig;
		}
		#endregion

		#region methods
		public override string ToString()
		{
			return $"Tid={Tid};ID={ID};Alarm={Alarm};Navn={Navn};Afdeling={Afdeling};Bolig={Bolig}";
		}
		#endregion
	}
}
