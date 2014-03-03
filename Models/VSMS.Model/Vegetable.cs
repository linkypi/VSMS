using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.Model
{
    /// <summary>
	///蔬菜实体类
	/// </summary>
    [Serializable]
    public  class Vegetable
    {
        #region Model

        private int _vid;
        private string _vcode;
        private int _cid;
        private string _keys;
        private string _vname;
        private double  _specification = 1;
        private bool _deleted = false;
        private DateTime _createtime = DateTime.Now;
        private DateTime  _modifytime;
        private int _vorder = 0;

        /// <summary>
        /// 蔬菜顺序
        /// </summary>
        public int VOrder
        {
            set { _vorder = value; }
            get { return _vorder; }
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
        /// 蔬菜代码
        /// </summary>
        public string VCode
        {
            set { _vcode = value; }
            get { return _vcode; }
        }

        /// <summary>
        /// 蔬菜所属类别
        /// </summary>
        public int CID
        {
            set { _cid = value; }
            get { return _cid; }
        }
        /// <summary>
        /// 蔬菜关键字
        /// </summary>
        public string Keys
        {
            set { _keys = value; }
            get { return _keys; }
        }
        /// <summary>
        /// 蔬菜名称
        /// </summary>
        public string VName
        {
            set { _vname = value; }
            get { return _vname; }
        }

        /// <summary>
        /// 规格
        /// </summary>
        public double Specification
        {
            set { _specification = value; }
            get { return _specification; }
        }

        /// <summary>
        ///  删除标志   1表示删除  0表示不删除
        /// </summary>
        public bool Deleted
        {
            set { _deleted = value; }
            get { return _deleted; }
        }
    
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
     
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime  ModifyTime
        {
            set { _modifytime = value; }
            get { return _modifytime; }
        }
        #endregion Model

        #region  扩展属性
        
        private bool isFrequentUse;
        private string remarks;
        private double wholesalePrice;

        /// <summary>
        /// 成本价
        /// </summary>
        public double WholesalePrice
        {
            get { return wholesalePrice; }
            set { wholesalePrice = value; }
        }


        /// <summary>
        /// 备注，如果IsFrequentUse等于true是有值
        /// </summary>
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        

  
        /// <summary>
        /// 是否是常用列表，对于莫用户来说，xpeng 添加
        /// </summary>
        public bool IsFrequentUse
        {
            get { return isFrequentUse; }
            set { isFrequentUse = value; }
        }
      

        #endregion 
    }
}
