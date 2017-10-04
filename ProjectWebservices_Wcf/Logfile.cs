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
		public DateTime Time
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
		public string Name
		{
			get { return _Navn; }
			set { _Navn = value; }
		}
		[DataMember]
		public string Department
		{
			get { return _Afdeling; }
			set { _Afdeling = value; }
		}
		[DataMember]
		public string Apartment
		{
			get { return _Bolig; }
			set { _Bolig = value; }
		}
		[DataMember]
		public DateTime Disposed
		{
			get { return _Afmeldt; }
			set { _Afmeldt = value; }
		}
		#endregion

		#region constructor
		public Logfile(string id, string alarm, string navn, string afdeling, string bolig)
		{
			Time = DateTime.Now;
			ID = id;
			Alarm = alarm;
			Name = navn;
			Department = afdeling;
			Apartment = bolig;
		}
		#endregion

		#region methods
		public override string ToString()
		{
			return $"Tid={Time};ID={ID};Alarm={Alarm};Navn={Name};Afdeling={Department};Bolig={Apartment};Afmeldt={(Disposed == null ? DateTime.MinValue : Disposed)}";
		}

		public bool Dispose()
		{
			if(Disposed == DateTime.MinValue)
			{
				Disposed = DateTime.Now;
				return true;
			}
			return false;
		}
		#endregion
	}
}
