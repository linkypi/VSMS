using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.MVCModels
{
    public class DeliveryNote
    {
        private string keys;
        private string oid;
        private int eid;
        private string vid;
        private string eName;
        private string dName;
        private string vCode;
        private string vName;
        private int orderCount;
        private int realCount;
        private double actualPrice;
        private DateTime orderTime;
        private string recipient;
        private string handledBy;
        private string fax;
        private string addr;
        private string phone;
        private string mobilePhone;

        public int EID
        {
            get { return eid; }
            set { eid = value; }
        }
        public string VID
        {
            get { return vid; }
            set { vid = value; }
        }
        public string MobilePhone
        {
            get { return mobilePhone; }
            set { mobilePhone = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Addr
        {
            get { return addr; }
            set { addr = value; }
        }
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        public string HandledBy
        {
            get { return handledBy; }
            set { handledBy = value; }
        }
        public string Recipient
        {
            get { return recipient; }
            set { recipient = value; }
        }
        public DateTime OrderTime
        {
            get { return orderTime; }
            set { orderTime = value; }
        }
        public double ActualPrice
        {
            get { return actualPrice; }
            set { actualPrice = value; }
        }
        public int RealCount
        {
            get { return realCount; }
            set { realCount = value; }
        }
        public int OrderCount
        {
            get { return orderCount; }
            set { orderCount = value; }
        }
        public string VName
        {
            get { return vName; }
            set { vName = value; }
        }


        public string VCode
        {
            get { return vCode; }
            set { vCode = value; }
        }
        public string DName
        {
            get { return dName; }
            set { dName = value; }
        }

        public string EName
        {
            get { return eName; }
            set { eName = value; }
        }
        public string OID
        {
            get { return oid; }
            set { oid = value; }
        }
        public string Keys
        {
            get { return keys; }
            set { keys = value; }
        }
    }
}
