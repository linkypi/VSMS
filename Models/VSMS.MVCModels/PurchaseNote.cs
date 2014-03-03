using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.MVCModels
{
   public class PurchaseNote
    {
       private string vName;
       private int orderCount;
       private double actualPrice;
       private string remarks;
       private DateTime updateTime;
       private string vID;

       public string VID
       {
           get { return vID; }
           set { vID = value; }
       }

       public DateTime UpdateTime
       {
           get { return updateTime; }
           set { updateTime = value; }
       }

       public string Remarks
       {
           get {
               if (String.IsNullOrEmpty(remarks))
               { return "无"; }
               return remarks;
           }
           set { remarks = value; }
       }

        public double ActualPrice
        {
            get { return actualPrice; }
            set { actualPrice = value; }
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

    }
}
