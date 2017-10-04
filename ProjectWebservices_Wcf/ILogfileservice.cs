using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjectWebservices_Wcf
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface ILogfileService
	{
		//[OperationContract]
		//CompositeType Log(CompositeType composite);

		[OperationContract]
		List<Logfile> ReadLogfiles();

		[OperationContract]
		bool DisposeAlarm(string id);

		[OperationContract]
		Logfile SendLogString(string txt);

        [OperationContract]
        List<Logfile> ReadPendingAlarms();

        [OperationContract]
        bool Log(string id, string alarm, string name, string department, string apartment);
	}

	// Use a data contract as illustrated in the sample below to add composite types to service operations.
	// You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ProjectWebservices.ContractType".
	[DataContract]
	public class CompositeType
	{
		string _ID;
		string _Alarm;
		string _Navn;
		string _Afdeling;
		string _Bolig;

        

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
	}
}
