using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSMS.Models.Model;
using VSMS.Common.DataHelper;
using VSMS.Common.XphpTool;
using VSMS.Models.MVCModels;

namespace VSMS.Models.DAL
{
    public class AnalyseDataDao
    {
        /// <summary>
        /// 根据企业编号和时间获取总成本，总售价，总利润
        /// </summary>
        /// <param name="eid">企业编号</param>
        /// <param name="time">查询的年月份</param>
        /// <returns>AnalyseDataModel</returns>
        //public AnalyseDataModel GetAnalyseData(int eid, string time) 
        //{
        //    AnalyseDataModel analyseDataModel = new AnalyseDataModel(); ;

        //    try
        //    {
        //        List<AnalyseData> analyseDatas= GetListBySearch(eid,time);
        //        if (analyseDatas == null) return null;
        //        foreach(AnalyseData analyseData in analyseDatas)
        //        {
                    
        //            analyseDataModel.TotolIncome += analyseData.Income;
        //            analyseDataModel.TotolCost += analyseData.Cost;
        //            analyseDataModel.TotolProfit += analyseData.Profit;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        XphpTool.CreateErrorLog(ex.ToString());
        //        return null;
        //    }
        //    return analyseDataModel;
        //}

        /// <summary>
        /// 处理AnalyseData集合返回“同一客户，不同部门，同一天”的数据
        /// </summary>
        /// <param name="time">查询的年月份</param>
        /// <returns>AnalyseData集合</returns>
        public List<AnalyseData> DealAnalyseData(string time)
        {
            List<AnalyseData> analyseDatas = GetListBySearch(time);
            if (analyseDatas == null) return null;

            List<AnalyseData> dealAnalyseData = new List<AnalyseData>();
            AnalyseData aData = null;
            //string[] dayTime = new string[analyseDatas.Count];
            HashSet<string> dayTime = new HashSet<string>();
            //获取所有订单的日期,无重复
            foreach (AnalyseData data in analyseDatas)
            {
                dayTime.Add(data.OID.Substring(0,8));
            }

            foreach (string str in dayTime)
            {
                foreach (Enterprise e in new EnterpriseDao().GetEnterpriseList())
                {
                    aData = new AnalyseData();
                    foreach (AnalyseData ad in analyseDatas)
                    {
                        if(ad.OID.Contains(str) && e.EID==ad.EID)
                        {
                            
                            aData.TotalCost += ad.TotalCost;
                            aData.Amount += ad.Amount;
                            aData.EID = ad.EID;
                            aData.OID = ad.OID;
                        }
                    }
                    if(aData.OID!=null) dealAnalyseData.Add(aData);
                }
            }
            return dealAnalyseData;
        }

        /// <summary>
        /// 根据年月份获取所有AnalyseData集合
        /// </summary>
        /// <param name="time">查询的年月份</param>
        /// <returns>AnalyseData集合</returns>
        public List<AnalyseData> GetListBySearch(string time)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select o.OID ,d.EID ,o.Amount,o.TotalCost ");
            sql.Append(" from Orders as o,Department as d");
            sql.Append(" where o.DID in(select DID from Department) and o.DID=d.DID and OID like '" + time + "%'");

//            string sql = @"select od.OID as 订单编号, o.DID as 部门编号, d.EID as 企业编号, od.VID as 蔬菜编号, up.MarketPrice as 市场价, od.RealCount as 实收量,od.ActualPrice as 实际售价 
//	                        from OrderDetail as od ,UnitPrice as up ,Orders as o , Department as d
//	                        where 1=1 and od.VID=up.VID and o.OID=od.OID and d.DID=o.DID
//	                        and od.OID in (select OID from Orders where DID in(select DID from Department where EID="+eid+") and OID like '"+time+"%' )";

            List<AnalyseData> analyseData =  SqlHelper.GetDataListByString<AnalyseData>(sql.ToString(), null, GetOutDic());

            return analyseData;
        }

        /// <summary>
        /// 获取输出参数字典
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> GetOutDic()
        {
            Dictionary<string, string> paraDic = new Dictionary<string, string>();
            paraDic.Add("OID", "OID");
            paraDic.Add("EID", "EID");
            paraDic.Add("Amount", "Amount");
            paraDic.Add("TotalCost", "TotalCost");
            return paraDic;
        }
    }
}
