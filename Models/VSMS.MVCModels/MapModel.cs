using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.MVCModels
{
    /// <summary>
    /// 映射实体
    /// </summary>
   public class MapModel
    {
        private int vid;
        private int eid;

        public int EID
        {
            get { return eid; }
            set { eid = value; }
        }

        public int VID
        {
            get { return vid; }
            set { vid = value; }
        }
    }
}
