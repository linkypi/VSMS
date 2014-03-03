using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.Model
{
    /// <summary>
    /// ShopingCart:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ShopingCart
    {
    
        #region Model

        private string _scid;
        private int _did;
        private int _vid;
        private string _vName;
        private decimal _vCount;
        private string _remarks;

        /// <summary>
        /// 蔬菜单位编号
        /// </summary>
        public string SCID
        {
            set { _scid = value; }
            get { return _scid; }
        }
        /// <summary>
        /// 客户编号
        /// </summary>
        public int DID
        {
            set { _did = value; }
            get { return _did; }
        }
        /// <summary>
        /// 蔬菜编号
        /// </summary>
        public int VID
        {
            set { _vid = value; }
            get { return _vid; }
        }

        /// <summary>
        /// 蔬菜名称
        /// </summary>
        public string VName 
        {
            set { _vName = value; }
            get { return _vName; }
        }
        /// <summary>
        /// 购物车蔬菜数量
        /// </summary>
        public decimal VCount
        {
            set { _vCount = value; }
            get { return _vCount; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        #endregion Model

    }
}
