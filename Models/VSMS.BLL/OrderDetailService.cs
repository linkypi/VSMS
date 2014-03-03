using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSMS.Models.DAL;
using VSMS.Models.Model;

namespace VSMS.Models.BLL
{
    public class OrderDetailService
    {
        private readonly OrderDetailDao odDao = new OrderDetailDao();
        private readonly VegetableDao vDao = new VegetableDao();

        /// <summary>
        /// 获取指定订单明细列表
        /// </summary>
        /// <param name="oid">订单编号</param>
        /// <returns></returns>
        public List<OrderDetail> GetList(string oid)
        {
            List<OrderDetail> orderDetailList = new List<OrderDetail>();
            orderDetailList = odDao.GetList(oid);
            foreach (OrderDetail od in orderDetailList)
            {
                od.VName = vDao.GetNameByID(od.VID);
            }
            return orderDetailList;
        }

        /// <summary>
        /// 执行sql语句   返回受影响的行数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="inputDic"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmd,Dictionary<string,object> inputDic)
        {
            return odDao.ExecuteNonQuery(cmd,inputDic);
        }
    }
}
