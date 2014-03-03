using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.MVCModels
{
    public class ProfitMessageModels
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public int DID { get; set; }

        /// <summary>
        /// 利润
        /// </summary>
        public double Profit { get; set; }

        /// <summary>
        /// 蔬菜名称
        /// </summary>
        public string VName { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keys { get; set; }

        /// <summary>
        /// 蔬菜编号
        /// </summary>
        public int VID { get; set; }

        /// <summary>
        /// 销售编号
        /// </summary>
        public int PID { get; set; }
    }
}
