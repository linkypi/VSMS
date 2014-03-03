using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using VSMS.Models.Model;
using VSMS.Common.DataHelper;
using System.Reflection;
using VSMS.Common.XphpTool;
using VSMS.Models.MVCModels;

namespace VSMS.Models.DAL
{
    public class OrdersDao
    {
        private OrderDetailDao oddao = new OrderDetailDao();
        private DepartmentDao ddao = new DepartmentDao();
        private EnterpriseDao edao = new EnterpriseDao();

        /// <summary>
        /// 获取查询结构集是数据笔数
        /// </summary>
        /// <param name="search">查询语句</param>
        /// <returns>影响行数</returns>
        public int GetCountBySearch(string search)
        {
            List<Orders> orders =SqlHelper.GetDataListByString<Orders>(search, new Dictionary<string ,object>(),new Dictionary<string ,string>());
            if (orders == null) return 0;
            int count = orders.Count;
            return count;
        }

        /// <summary>
        /// 根据查询语句获取订单列表
        /// </summary>
        /// <param name="search">查询语句</param>
        /// <returns></returns>
        public List<Orders> GetListBySearch(string search)
        {
            List<Orders> orders = null;
            try
            {
                orders = SqlHelper.GetDataListByString<Orders>(search, new Dictionary<string,object>(), GetOutDic());

                foreach (Orders o in orders)
                {
                    //o.OrderDetailList = oddao.GetList(o.OID);
                    Department d = ddao.GetDepartmentByID(o.DID);
                    o.DName = d.DName;
                    o.EName = edao.GetModel(d.EID).EName;
                    decimal prices = 0;
                    decimal realprices = 0;
                    //if (o.OrderDetailList != null)
                    //{
                    //    foreach (OrderDetail od in o.OrderDetailList)
                    //    {
                    //        prices += od.OrderCount * (decimal)od.ActualPrice;
                    //        realprices += od.RealCount * (decimal)od.ActualPrice;
                    //    }
                    //    o.Prices = prices;
                    //    o.RealPrices = realprices;
                    //}
                }
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }

            return orders;
        }


        /// <summary>
        /// 获取将要添加的订单编号 
        /// </summary>
        /// <returns>返回最新订单编号  </returns>
        private string GetOID()
        {
            try
            {
                DateTime time = DateTime.Now;
                string month = time.Month.ToString();
                if (month.Length == 1)
                {
                    month = "0" + month;
                }
                string preID = time.Year.ToString() + month + time.Day.ToString();

                StringBuilder strSql = new StringBuilder();
                strSql.Append("select max(OID) from Orders");
                string maxOid = SqlHelper.ExecuteScalarByString(strSql.ToString(), new Dictionary<string,object>()).ToString();
                if (maxOid == "")
                {
                    maxOid = "2012071700000";//前8位随意值
                }
                int num = int.Parse(maxOid.Substring(8,5))+ 1;
                string oid = "0000" + num.ToString();
                 oid = oid.Substring(oid.Length-5,5);

                 return preID+oid;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="model">订单实体</param>
        /// <returns>添加成功返回true  否则返回false</returns>
        public bool Add(Orders model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Orders(");
                strSql.Append("OID,CID,Remarks)");
                strSql.Append(" values (");
                strSql.Append("@OID,@CID,@Remarks)");

                int ret = (int)SqlHelper.ExecuteNonQuery(strSql.ToString(), GetInputDic(model));
                return ret > 0;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 生成订单
        /// </summary>
        /// <param name="ShopingCartList">同部门购物车列表</param>
        /// <returns>是否成功</returns>
        public bool Add(List<ShopingCart> ShopingCartList)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                StringBuilder remarks = new StringBuilder();
                Dictionary<string, object> paramsValue = new Dictionary<string, object>();

                int i = 0;
                string oid = GetOID();
                strSql.Append("insert into Orders(");
                strSql.Append("OID,DID,OrderState,Remarks)");
                strSql.Append(" values (");
                strSql.Append("@OID,@DID,@OrderState,@Remarks);");

                foreach (ShopingCart sc in ShopingCartList)
                {
                    StringBuilder strSubSql = new StringBuilder();
                    strSubSql.Append("insert into OrderDetail(");
                    strSubSql.Append("OID,VID,OrderCount,Remarks)");
                    strSubSql.Append(" values (");
                    strSubSql.Append("@OID" + ",@VID" + i + ",@OrderCount" + i + ",@Remarks" + i + ");");
                    paramsValue.Add("VID" + i, sc.VID);
                    paramsValue.Add("OrderCount" + i, sc.VCount);
                    paramsValue.Add("Remarks" + i, sc.Remarks);

                    strSql.Append(strSubSql);
                    i++;
                    if (sc.Remarks != "")
                    {
                        remarks.Append(sc.VName);
                        remarks.Append("：");
                        remarks.Append(sc.Remarks);
                        remarks.Append("\n");
                    }

                }
                strSql.Append("DELETE FROM ShopingCart WHERE DID=@DID;");
                paramsValue.Add("OID", oid);
                paramsValue.Add("DID", ShopingCartList[0].DID);
                paramsValue.Add("OrderState", 0);
                paramsValue.Add("Remarks", remarks.ToString());
                return ((int)SqlHelper.ExecuteNonQuery(strSql.ToString(), paramsValue)) > 0;
            }
            catch (System.Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 更新订单
        /// </summary>
        /// <param name="model">订单实体</param>
        /// <returns>更新成功返回true  否则返回false</returns>
        public bool Update(Orders model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Orders set ");
                strSql.Append("OrderState=@OrderState,");
                strSql.Append("Upaid=@Upaid,");
                strSql.Append("UpaidTime=@UpaidTime,");
                strSql.Append("Wpaid=@Wpaid,");
                strSql.Append("WpaidTime=@WpaidTime,");
                strSql.Append("Remarks=@Remarks,");
                strSql.Append(" Recipient = @Recipient , ");
                strSql.Append(" HandledBy = @HandledBy , ");
                strSql.Append("DeliveryDate=@DeliveryDate");
                strSql.Append(" where OID=@OID ");

                int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(),  GetInputDic(model));
                return rows > 0;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 根据订单编号获取订单信息
        /// </summary>
        /// <param name="oid">订单编号</param>
        /// <returns></returns>
        public Orders GetModel(string oid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  top 1 * from Orders ");
                strSql.Append(" where OID=@OID ");
                Dictionary<string, object> inputDic = new Dictionary<string, object>();
                inputDic.Add("OID",oid);

                List<Orders> orders = SqlHelper.GetDataListByString<Orders>(strSql.ToString(),inputDic, GetOutDic());
                if (orders == null) return null;

                orders[0].OrderDetailList = oddao.GetList(orders[0].OID);
                decimal prices = 0;
                decimal realprices = 0;
                if (orders[0].OrderDetailList != null)
                {
                    foreach (OrderDetail od in orders[0].OrderDetailList)
                    {
                        prices += od.OrderCount * (decimal)od.ActualPrice;
                        realprices += od.RealCount * (decimal)od.ActualPrice;
                    }
                    orders[0].Prices = prices;
                    orders[0].RealPrices = realprices;
                }
                return orders[0];
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 根据订单编号删除一条订单，同时删除订单明细
        /// </summary>
        /// <param name="oid">订单编号</param>
        /// <returns></returns>
        public bool Delete(int oid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from Orders ");
                strSql.Append(" where OID=@OID");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@OID", oid);

                int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), paraDic);

                return rows > 0;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }
     
        /// <summary>
        /// 根据订单编号获取送货单        送货单
        /// </summary>
        /// <param name="oid">订单编号</param>
        /// <returns></returns>
        public List<DeliveryNote> GetDeliveryNoteByOID(string oid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@" select Keys,VCode,VName,OrderCount,ActualPrice,RealCount,
                                            od.VID,o.OID,e.EName,d.DName,o.OrderTime,o.Recipient,
                                            o.HandledBy,d.Fax,d.Addr,d.Phone,d.MobilePhone ");
                strSql.Append(@" from  Orders as o
                                            join OrderDetail as od on od.OID=o.OID  
                                            join Vegetable as v on  v.VID=od.VID
                                            join Department as d on d.DID=o.DID 
                                            join Enterprise as e on e.EID=d.EID  ");
                strSql.Append(@" group by Keys,VCode,VName,OrderCount,ActualPrice,RealCount,
                                            od.VID,o.OID,e.EName,d.DName,o.OrderTime,o.Recipient,
                                            o.HandledBy,d.Fax,d.Addr,d.Phone,d.MobilePhone,o.OrderState ");
                strSql.Append(@" having  --DATEDIFF(DAY,o.OrderTime,GETDATE())=0 and
                                            OrderState=2  and o.OID =" + oid);
                strSql.Append("  order by od.VID,Keys ");

                Dictionary<string, string> outDic = new Dictionary<string, string>();

                outDic.Add("Keys", "Keys");
                outDic.Add("OID", "OID");
                outDic.Add("VID", "VID");
                outDic.Add("EName", "EName");
                outDic.Add("DName", "DName");
                outDic.Add("VCode", "VCode");
                outDic.Add("VName", "VName");
                outDic.Add("OrderCount", "OrderCount");
                outDic.Add("ActualPrice", "ActualPrice");
                outDic.Add("RealCount", "RealCount");
                outDic.Add("OrderTime", "OrderTime");
                outDic.Add("Recipient", "Recipient");
                outDic.Add("HandledBy", "HandledBy");
                outDic.Add("Fax", "Fax");
                outDic.Add("Addr", "Addr");
                outDic.Add("Phone", "Phone");
                outDic.Add("MobilePhone", "MobilePhone");
                List<DeliveryNote> list = SqlHelper.GetDataListByString<DeliveryNote>(strSql.ToString(), null, outDic);
                if (list==null) return null;
                return list;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获取所有送货单列表
        /// </summary>
        /// <returns></returns>
        public List<DeliveryNote> GetAllDeliveryNote()
        {
            try
            {
                StringBuilder strbd = new StringBuilder();
                strbd.Append(@"  select o.OID,e.EName,e.EID,d.DName
                                        from  Orders as o
                                        join OrderDetail as od on od.OID=o.OID  
                                        join Vegetable as v on  v.VID=od.VID
                                        join Department as d on d.DID=o.DID 
                                        join Enterprise as e on e.EID=d.EID  
                                        group by o.OID,e.EName,d.DName,o.OrderState,OrderTime,e.EID
                                        having  DATEDIFF(DAY,o.OrderTime,GETDATE())=0 and
                                        OrderState=1 ");
                Dictionary<string, string> outDic = new Dictionary<string, string>();

                outDic.Add("OID", "OID");
                outDic.Add("DName", "DName");
                outDic.Add("EName", "EName");
                outDic.Add("EID","EID");

                List<DeliveryNote> list = SqlHelper.GetDataListByString<DeliveryNote>(strbd.ToString(), null, outDic);
                if (list == null) return null;
                return list;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获取采购单列表                   采购单
        /// </summary>
        /// <param name="pageIndex">第几页（每页20条数据）</param>
        /// <returns></returns>
        public List<PurchaseNote> GetPurchaseNote(int pageIndex )
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@" select ");
                if (pageIndex != 0)
                {
                    strSql.Append("  top 50 ");
                }
                if(pageIndex==0)
                {
                    pageIndex = 1;
                }
//                strSql.Append(@" VName,sum(OrderCount)as OrderCount,v.VID
//                                            ,od.Remarks from  Orders as o
//                                            join OrderDetail as od on od.OID = o.OID
//                                            join Vegetable as v on v.VID = od.VID
//                                            group by VName ,OrderTime,v.VID,od.Remarks,OrderState
//                                            having datediff(day,o.OrderTime,GETDATE())=0 
//                                            and OrderState=0 and v.VID not in( select top ");
//                strSql.Append(50 * (pageIndex - 1) + @" v.VID from Orders as o
//	                                        join OrderDetail as od on od.OID = o.OID
//	                                        join Vegetable as v on v.VID = od.VID
//	                                        group by VName ,OrderTime,v.VID,OrderState
//	                                        having datediff(day,o.OrderTime,GETDATE())=0
//	                                        and OrderState=0  order by v.VID asc
//                                           )order by v.VID asc ");    --,dbo.JoinStr( case when od.Remarks is null then '' else od.Remarks end) as Remarks 

                strSql.Append(@" VName,sum(OrderCount)as OrderCount,v.VID
                                        
                                            from  Orders as o
                                            join OrderDetail as od on od.OID = o.OID
                                            join Vegetable as v on v.VID = od.VID
                                            where datediff(day,o.OrderTime,GETDATE())=0 
                                            and OrderState=0 and v.VID not in(  select top ");
                strSql.Append(50 * (pageIndex - 1) + @" v.VID from Orders as o
	                                            join OrderDetail as od on od.OID = o.OID
	                                            join Vegetable as v on v.VID = od.VID
	                                            where datediff(day,o.OrderTime,GETDATE())=0
	                                            and OrderState=0
	                                            group by VName ,v.VID 
	                                            order by v.VID asc
                                            )
                                            group by VName ,v.VID  
                                            order by v.VID asc");

                Dictionary<string, string> outDic = new Dictionary<string, string>();
                outDic.Add("VName", "VName");
              //  outDic.Add("Remarks", "Remarks");
                outDic.Add("OrderCount", "OrderCount");
                outDic.Add("VID","VID");

                List<PurchaseNote> list = SqlHelper.GetDataListByString<PurchaseNote>(strSql.ToString(), null, outDic);
                if (list==null) return null;
                return list;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获取检货单数据列表            检货单
        /// </summary>
        /// <returns></returns>
        public List<InspectionSheet> GetInspectionSheet()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@" select EName,DName,VName,OrderCount,od.OID,od.VID
                                            from Orders as o 
                                            join OrderDetail as od on od.OID = o.OID
                                            join Department as d on d.DID=o.DID
                                            join Enterprise as e on e.EID = d.EID
                                            join Vegetable as v on v.VID =od.VID
                                            where datediff(day,o.OrderTime,getdate())=0
                                            group by EName,DName,VName,OrderCount,od.OID,od.VID ");
                Dictionary<string, string> outDic = new Dictionary<string, string>();
                outDic.Add("VName", "VName");
                outDic.Add("DName", "DName");
                outDic.Add("EName", "EName");
                outDic.Add("OrderCount", "OrderCount");
                List<InspectionSheet> list = SqlHelper.GetDataListByString<InspectionSheet>(strSql.ToString(), null, outDic);
                if (list == null) return null;
                return list;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 执行命令   返回受影响的行数
        /// </summary>
        /// <param name="cmd">sql 语句</param>
        /// <param name="dic">参数字典</param>
        /// <returns></returns>
        public int ExecuteNoQurey(string cmd,Dictionary<string,object> dic)
        {
           return  SqlHelper.ExecuteNonQuery(cmd,dic);
        }

       
        /// <summary>
        /// 执行命令   返回结果的第一行第一列
        /// </summary>
        /// <param name="cmd">查询语句</param>
        /// <param name="inputDic">输入参数字典</param>
        /// <returns></returns>
        public object ExecuteScalar(string cmd ,Dictionary<string,object> inputDic)
        {
           return  SqlHelper.ExecuteScalarByString(cmd, inputDic);
        }

        /// <summary>
        /// 获取当天所有交易的企业
        /// </summary>
        /// <returns></returns>
        public List<Enterprise> GetAllEnterpriceDayTrading()
        {
            try
            {
                StringBuilder strbd = new StringBuilder();
                strbd.Append(@"  select distinct EName,e.EID
                                        from Enterprise as e
                                        join Department as d on e.EID = d.EID
                                        join Orders as o on d.DID = o.DID 
                                        where datediff(day,o.OrderTime,getdate())=0
                                        order by e.EID ");
                Dictionary<string, string> outDic = new Dictionary<string, string>();
                outDic.Add("EID", "EID");
                outDic.Add("EName", "EName");
                List<Enterprise> list = SqlHelper.GetDataListByString<Enterprise>(strbd.ToString(), null, outDic);
                if (list == null) return null;
                return list;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }
        #region 私有方法

        /// <summary>
        /// 获取输入参数字典
        /// </summary>
        /// <param name="model">订单实体</param>
        /// <returns></returns>
        private Dictionary<string, object> GetInputDic(Orders model)
        {
            Dictionary<string, object> paraDic = new Dictionary<string, object>();
            paraDic.Add("@OrderState", model.OrderState);
            paraDic.Add("@Recipient", model.Recipient);
            paraDic.Add("@HandledBy", model.HandledBy);
            paraDic.Add("@Remarks", model.Remarks);
            paraDic.Add("@DeliveryDate", model.DeliveryDate);
            paraDic.Add("@OID", GetOID());
            return paraDic;
        }

        /// <summary>
        /// 获取输出参数字典
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> GetOutDic()
        {
            Dictionary<string, string> paraDic = new Dictionary<string, string>();
            paraDic.Add("DID", "DID");
            paraDic.Add("OrderTime", "OrderTime");
            paraDic.Add("OrderState", "OrderState");
            paraDic.Add("Recipient", "Recipient");
            paraDic.Add("HandledBy", "HandledBy");
            paraDic.Add("Remarks", "Remarks");
            paraDic.Add("DeliveryDate", "DeliveryDate");
            paraDic.Add("OID", "OID");
            paraDic.Add("TotalCost", "TotalCost");
            paraDic.Add("Amount", "Amount");
            return paraDic;
        }

        #endregion

        
    }
}
