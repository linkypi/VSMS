using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.Model
{
    /// <summary>
    /// 订单状态枚举
    /// 订单状态,默认为0,
    /// 0:初始状态：无单价；操作：可打印采购单，等待录入单价-----------Init
    /// 1:             : 已录入成本价  待录入售价
    /// 2:发货状态：已录入售价；操作：可打印发货单 && 待录入实际收货量和库存-----HadDelivery 
    /// 3:完成状态：已完成（已录入实际收货量和库存）--------Finished    
    /// </summary>
    public  enum OrderState:int
    {
        /// <summary>
        /// 初始状态：从购物车提交（无单价）无单价；操作：可打印采购单，等待录入单价
        /// </summary>
        Init=0,

        /// <summary>
        /// 已录入成本价： 待录入实际售价
        /// </summary>
        HadPrice,

        /// <summary>
        /// 发货状态：已录入售价；操作：可打印发货单 && 待录入实际收货量-----HadDelivery 
        /// </summary>
        HadDelivery,

        /// <summary>
        /// 完成状态（已录入实际收货量和库存）
        /// </summary>
        Finished
    }
}
