using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSMS.Common.DataHelper;
using VSMS.Common.XphpTool;
using VSMS.Models.Model;
using VSMS.Models.MVCModels;

namespace VSMS.DAL
{
    public class ProfitDao
    {
        /// <summary>
        /// 修改利润
        /// </summary>
        /// <param name="profit">利润参数</param>
        /// <param name="spid">售价表id</param>
        /// <returns>修改利润成功返回true，否则返回false</returns>
        public bool ChangeProfit(double profit, int spid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" update  Profit set ");
                strSql.Append(" profit = @Profit");
                strSql.Append(" where PID=@PID");

                Dictionary<string, object> paraDic = new Dictionary<string, object>();
                paraDic.Add("@PID", spid);
                paraDic.Add("@Profit", profit);

                int rows = (int)SqlHelper.ExecuteNonQuery(strSql.ToString(), paraDic);

                return rows > 0;
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return false;
            }
        }


        /// <summary>
        /// 获得利润管理列表
        /// </summary>
        /// <param name="spid">售价表id</param>
        /// <returns>返回利润管理列表</returns>
        public List<ProfitMessageModels> ChangeMessage(int did)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select d.DID,p.Profit,v.VName,v.Keys,v.VID,p.PID from Vegetable as v");
                strSql.Append(" join Profit as p on p.VID=v.VID");
                strSql.Append(" join Department as d on p.DID=d.DID");
                strSql.Append(" where p.DID=@DID");

                Dictionary<string, object> inputDic = new Dictionary<string, object>();

                inputDic.Add("DID", did);
                Dictionary<string, string> outDic = new Dictionary<string, string>();
                outDic.Add("PID", "PID");
                outDic.Add("Profit", "Profit");
                outDic.Add("VName", "VName");
                outDic.Add("Keys", "Keys");
                outDic.Add("VID", "VID");

                List<ProfitMessageModels> list = SqlHelper.GetDataListByString<ProfitMessageModels>(strSql.ToString(), inputDic, outDic);
             
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
