using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSMS.Models.Model;

namespace VSMS.Models.MVCModels
{
    public class AnalyseDataModel
    {
        //总售价
        private double totolIncome;

        public double TotolIncome
        {
            get { return totolIncome; }
            set { totolIncome = value; }
        }
        //总成本
        private double totolCost;

        public double TotolCost
        {
            get { return totolCost; }
            set { totolCost = value; }
        }
        //总利润
        private double totolProfit;

        public double TotolProfit
        {
            get { return totolProfit; }
            set { totolProfit = value; }
        }
        //所有订单的集合
        private List<AnalyseData> analyseDatas;

        public List<AnalyseData> AnalyseDatas
        {
            get { return analyseDatas; }
            set { analyseDatas = value; }
        }
        //所有客户的集合
        private List<Enterprise> enterpreses;

        public List<Enterprise> Enterpreses
        {
            get { return enterpreses; }
            set { enterpreses = value; }
        }
        //获取企业当月的数据
        private List<AnalyseData> monthData;

        public List<AnalyseData> MonthData
        {
            get { return monthData; }
            set { monthData = value; }
        }
        //获取所有企业当天的数据
        private List<AnalyseData> dayData;

        public List<AnalyseData> DayData
        {
            get { return dayData; }
            set { dayData = value; }
        }
    }
}
