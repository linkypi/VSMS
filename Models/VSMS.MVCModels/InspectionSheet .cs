using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.MVCModels
{
    /// <summary>
    /// 检货单实体
    /// </summary>
    public class InspectionSheet
    {
        private string eName;
        private string dName;
        private string vName;
        private int orderCount;
        private int eID;
        private int dID;
        private List<int> dpCount = new List<int>();

        /// <summary>
        /// 企业拥有的部门数量
        /// </summary>
        public List<int> DpCount
        {
            get { return dpCount; }
            set { dpCount = value; }
        }

        public int DID
        {
          get { return dID; }
          set { dID = value; }
        }

        public int EID
        {
          get { return eID; }
          set { eID = value; }
        }
        public string VName
        {
            get { return vName; }
            set { vName = value; }
        }

        public int OrderCount
        {
            get { return orderCount; }
            set { orderCount = value; }
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

    }
}
