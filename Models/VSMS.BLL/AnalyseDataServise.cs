using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSMS.Models.MVCModels;
using VSMS.Models.DAL;
using VSMS.Models.Model;

namespace VSMS.Models.BLL
{
    public class AnalyseDataServise
    {
        AnalyseDataDao analyseDataDao = new AnalyseDataDao();
        EnterpriseService enterpriseService = new EnterpriseService();
        public string msg = "";
        /// <summary>
        /// 根据年月份获取总成本，总售价，总利润
        /// </summary>
        /// <param name="time">查询的年月份</param>
        /// <returns>AnalyseDataModel</returns>
        public AnalyseDataModel GetAnalyseDataModel(string time)
        {
            AnalyseDataModel adModel = null;
            List<AnalyseData> analyseDatas = analyseDataDao.DealAnalyseData(time);

            if (analyseDatas != null)
            {
                adModel = new AnalyseDataModel();
                adModel.MonthData = new List<AnalyseData>();
                adModel.DayData = new List<AnalyseData>();

                adModel.Enterpreses = enterpriseService.GetEnterpriseList();
                adModel.AnalyseDatas = analyseDatas;
                AnalyseData monthData =null;
                AnalyseData dayData = null;
                //计算所有客户当月的总成本和总售价
                foreach (AnalyseData ad in analyseDatas)
                {
                    adModel.TotolIncome += ad.Amount;
                    adModel.TotolCost += ad.TotalCost;
                }
                //计算各个客户当月的总成本，总售价
                foreach (Enterprise e in enterpriseService.GetEnterpriseList())
                {
                    monthData = new AnalyseData();
                    foreach (AnalyseData ad in analyseDatas)
                    {
                        if (ad.EID == e.EID)
                        {
                            monthData.TotalCost += ad.TotalCost;
                            monthData.Amount += ad.Amount;
                            monthData.EID = ad.EID;
                            monthData.OID = ad.OID;
                        }
                    }
                    adModel.MonthData.Add(monthData);
                }
                //获取所有订单的日期,无重复
                HashSet<string> dayTime = new HashSet<string>();
                foreach (AnalyseData data in analyseDatas)
                {
                    dayTime.Add(data.OID.Substring(0, 8));
                }

                //计算当月所有客户同一天的总售价和总成本
                foreach (string str in dayTime)
                {
                    dayData = new AnalyseData();

                    foreach (AnalyseData ad in analyseDatas)
                    {
                        if (ad.OID.Contains(str))
                        {
                            dayData.TotalCost += ad.TotalCost;
                            dayData.Amount += ad.Amount;
                            dayData.EID = ad.EID;
                            dayData.OID = ad.OID;
                        }
                    }
                    
                    adModel.DayData.Add(dayData);
                }

                adModel.TotolProfit = adModel.TotolIncome - adModel.TotolCost;
            }
            else
            {
                msg = "没有该月的订单信息，请重新查询！";
            }

            if (adModel.AnalyseDatas.Count == 0) msg = "没有该月的订单信息，请重新查询！";

            return adModel;
        }
    }
}
