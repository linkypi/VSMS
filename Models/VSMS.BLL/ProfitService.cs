using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSMS.DAL;
using VSMS.Common.XphpTool;
using VSMS.Models.Model;
using VSMS.Models.MVCModels;

namespace VSMS.Models.BLL
{
    public class ProfitService
    {
        private readonly ProfitDao pDao = new ProfitDao();

        /// <summary>
        /// 更改利润
        /// </summary>
        /// <param name="profit">利润字段</param>
        /// <param name="spid">售价表id</param>
        /// <returns>修改利润成功返回true，否则返回false</returns>
        public bool GetChangeProfit(double profit, int spid)
        {
            try
            {
                return pDao.ChangeProfit(profit,spid);
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
        public List<ProfitMessageModels> GetChangeMessage(int spid)
        {
            try
            {
                return pDao.ChangeMessage(spid);
            }
            catch (Exception ex)
            {
                XphpTool.CreateErrorLog(ex.ToString());
                return null;
            }
        }
    }
}
