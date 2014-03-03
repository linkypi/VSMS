using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSMS.Models.Model
{
    /// <summary>
    /// 错误信息Model
    /// </summary>
    public class ErrorHandle
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public string Error_code { get; set; }
        /// <summary>
        /// 请求页面
        /// </summary>
        public string Request { get; set; }
        /// <summary>
        /// 错误提示信息
        /// </summary>
        public string Error { get; set; }

    }
}
