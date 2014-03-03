using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.Model
{
    /// <summary>
    /// Ajax请求结果
    /// </summary>
    public class AjaxResult
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public ErrorHandle error { get; set; }

        /// <summary>
        /// 请求结果
        /// </summary>
        public string Result { get; set; }

    }
}
