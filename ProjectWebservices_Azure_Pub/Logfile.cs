using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProjectWebservices_Azure_Pub
{
    [DataContract]
    public class Logfile
    {

        #region variables
        private DateTime _Time;
        private string _ID;
        private string _Alarm;
        private string _Name;
        private string _Department;
        private string _Apartment;
        private DateTime _Disposed;
        #endregion

        #region properties
        [DataMember]
        public DateTime Time
        {
            get { return _Time; }
            set { _Time = value; }
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
            get { return _Name; }
            set { _Name = value; }
        }
        [DataMember]
        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }
        [DataMember]
        public string Apartment
        {
            get { return _Apartment; }
            set { _Apartment = value; }
        }
        [DataMember]
        public DateTime Disposed
        {
            get { return _Disposed; }
            set { _Disposed = value; }
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
            if (Disposed == DateTime.MinValue)
            {
                Disposed = DateTime.Now;
                return true;
            }
            return false;
        }
        #endregion
    }
}
