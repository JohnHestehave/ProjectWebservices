using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ProjectWebservices_Wcf
{
	[DataContract]
	public class Logfile
	{

		#region variables
		private DateTime _Tid;
		private string _ID;
		private string _Alarm;
		private string _Navn;
		private string _Afdeling;
		private string _Bolig;
		private DateTime _Afmeldt;
		#endregion

		#region properties
		[DataMember]
		public DateTime Tid
		{
			get { return _Tid; }
			set { _Tid = value; }
		}
		[DataMember]
		public string ID
		{
			get { return _ID; }
			set { _ID = value; }
		}
		[DataMember]
		public string Alarm
		{
			get { return _Alarm; }
			set { _Alarm = value; }
		}
		[DataMember]
		public string Navn
		{
			get { return _Navn; }
			set { _Navn = value; }
		}
		[DataMember]
		public string Afdeling
		{
			get { return _Afdeling; }
			set { _Afdeling = value; }
		}
		[DataMember]
		public string Bolig
		{
			get { return _Bolig; }
			set { _Bolig = value; }
		}
		[DataMember]
		public DateTime Afmeldt
		{
			get { return _Afmeldt; }
			set { _Afmeldt = value; }
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
			return $"Tid={Tid};ID={ID};Alarm={Alarm};Navn={Navn};Afdeling={Afdeling};Bolig={Bolig};Afmeldt={(Afmeldt == null ? DateTime.MinValue : Afmeldt)}";
		}

		public bool Dispose()
		{
			if(Afmeldt == DateTime.MinValue)
			{
				Afmeldt = DateTime.Now;
				return true;
			}
			return false;
		}
		#endregion
	}
}
