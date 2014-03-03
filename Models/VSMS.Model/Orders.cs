using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.Model
{
    public class Orders
    {
        #region model
        private string _oid;
        private int _did;
        private OrderState _orderstate;
        private string _remarks;
        private DateTime _ordertime;
        private string _recipient;
        private string _handledby;
        private DateTime _deliverydate;
        private decimal totalCost=0;
        private decimal amount=0;

        /// <summary>
        /// 总成本
        /// </summary>
        public decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }
        /// <summary>
        /// 总额
        /// </summary>
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }
       
      
        /// <summary>
        /// 订单id
        /// </summary>		
        public string OID
        {
            get { return _oid; }
            set { _oid = value; }
        }


        /// <summary>
        /// 用户id
        /// </summary>		   
        public int DID
        {
            get { return _did; }
            set { _did = value; }
        }


        /// <summary>
        /// 订单状态,默认为0,
        /// 0:初始状态：无单价；操作：等待录入单价-----------Init
        /// 1:发货状态：已录入单价；操作：可打印发货单、采购单 && 待录入实际收货量和库存-----HadDelivery 
        ///	2:完成状态：已完成（已录入实际收货量和库存）--------Finished                                         
        /// </summary>
        public OrderState OrderState
        {
            get { return _orderstate; }
            set { _orderstate = value; }
        }


        /// <summary>
        /// 备注
        /// </summary>		 
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }


        /// <summary>
        /// 订购时间
        /// </summary>		    
        public DateTime OrderTime
        {
            get { return _ordertime; }
            set { _ordertime = value; }
        }


        /// <summary>
        /// 接收人 
        /// </summary>		
        public string Recipient
        {
            get { return _recipient; }
            set { _recipient = value; }
        }


        /// <summary>
        /// 经手人
        /// </summary>		
        public string HandledBy
        {
            get { return _handledby; }
            set { _handledby = value; }
        }


        /// <summary>
        /// 送货日期
        /// </summary>		
        public DateTime DeliveryDate
        {
            get { return _deliverydate; }
            set { _deliverydate = value; }
        }
#endregion

        #region 扩展属性
        private string eName;
        /// <summary>
        /// 所属企业（酒店）名称
        /// </summary>
        public string EName
        {
            get { return eName; }
            set { eName = value; }
        }
        private string dName;
        /// <summary>
        /// 所属部门名称
        /// </summary>
        public string DName
        {
            get { return dName; }
            set { dName = value; }
        }
        private List<OrderDetail> orderDetailList = null;
        /// <summary>
        /// 订单详细列表
        /// </summary>
        public List<OrderDetail> OrderDetailList
        {
            get { return orderDetailList; }
            set { orderDetailList = value; }
        }
        private decimal prices= 0;
        /// <summary>
        /// 理论总价格
        /// </summary>
        public decimal Prices
        {
            get { return prices; }
            set { prices = value; }
        }
        private decimal realPrices = 0 ;
        /// <summary>
        /// 实际总价格
        /// </summary>
        public decimal RealPrices
        {
            get { return realPrices; }
            set { realPrices = value; }
        }
        #endregion
    }
}
