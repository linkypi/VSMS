using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

using VSMS.Models.Model;
using VSMS.Common.DataHelper;
using VSMS.Common.XphpTool;

namespace VSMS.Models.DAL
{
    public class OrderDetailDao
    {

       /// <summary>
       /// 添加订单明细
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        public bool Add(OrderDetail model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into OrderDetail(");
                strSql.Append("OID,VID,OrderCount,RealCount,Remarks");
                strSql.Append(") values (");
                strSql.Append("@OID,@VID,@OrderCount,@RealCount,@Remarks");
                strSql.Append(") ");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@OID", model.OID);
                paraDic.Add("@VID", model.VID);
                paraDic.Add("@OrderCount", model.OrderCount);
                paraDic.Add("@RealCount", model.RealCount);
                paraDic.Add("@Remarks", model.Remarks);

                object obj = SqlHelper.ExecuteNonQuery(strSql.ToString(), paraDic);
                if (obj == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false; 
            }

        }

       /// <summary>
        ///  更新一条数据
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        public bool Update(OrderDetail model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update OrderDetail set ");
                strSql.Append(" OID = @OID , ");
                strSql.Append(" VID = @VID , ");
                strSql.Append(" OrderCount = @OrderCount , ");
                strSql.Append(" RealCount = @RealCount ,");
                strSql.Append(" Remarks = @Remarks  ");
                strSql.Append(" where OID=@OID  ");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@OID", model.OID);
                paraDic.Add("@VID", model.VID);
                paraDic.Add("@OrderCount", model.OrderCount);
                paraDic.Add("@RealCount", model.RealCount);
                paraDic.Add("@Remarks", model.Remarks);

                int ret = int.Parse(SqlHelper.ExecuteScalarByString(strSql.ToString(), paraDic).ToString());
                return ret > 0;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }

      /// <summary>
      /// 执行非查询的sql语句  返回受影响的行数
      /// </summary>
      /// <param name="cmd"></param>
      /// <param name="inputDic"></param>
      /// <returns></returns>
        public int ExecuteNonQuery(string cmd,Dictionary<string,object> inputDic)
        {
            return SqlHelper.ExecuteNonQuery(cmd,inputDic);
        }

       /// <summary>
        ///  根据订单编号删除一条数据
       /// </summary>
        /// <param name="oid">订单编号</param>
       /// <returns></returns>
        public bool DeleteByOID(int oid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from OrderDetail ");
                strSql.Append(" where OID=@OID ");
                
                //删除订单的同时要删除订单明细
                strSql.Append(" delete from Orders where OID=@OID ");
                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("OID", oid);
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
        /// 获取指定订单明细列表
        /// </summary>
        /// <param name="oid">订单编号</param>
        /// <returns></returns>
        public List<OrderDetail> GetList(string  oid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ODID, OID, VID, OrderCount, RealCount,Remarks,ActualPrice ");
                strSql.Append("  from OrderDetail ");
                strSql.Append(" where OID=@OID ");

                Dictionary<string, object> inputDic = new Dictionary<string, object>();

                inputDic.Add("OID",oid);
                Dictionary<string, string> outDic = new Dictionary<string, string>();
                outDic.Add("ODID","ODID");
                outDic.Add("OID", "OID");
                outDic.Add("VID", "VID");
                outDic.Add("OrderCount", "OrderCount");
                outDic.Add("RealCount", "RealCount");
                outDic.Add("Remarks", "Remarks");
                outDic.Add("ActualPrice", "ActualPrice");

                List<OrderDetail> list = SqlHelper.GetDataListByString<OrderDetail>(strSql.ToString(),inputDic,outDic);

                if (list == null) return null;
                return list;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }

    }
}
