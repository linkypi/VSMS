using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.Model
{
    public class AnalyseData
    {
        //订单编号OID
        private string oID;

        public string OID
        {
            get { return oID; }
            set { oID = value; }
        }
        //企业编号EID
        private int eID;

        public int EID
        {
            get { return eID; }
            set { eID = value; }
        }

        //订单总售价
        private double amount;

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        //订单总成本
        private double totalCost;

        public double TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }


    }
}
