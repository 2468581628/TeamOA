using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.ViewModel
{
    /// <summary>
    /// API呼叫时，传回统一格式
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 执行是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 结果代码(0000=成功，其余为错误)
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime DataTime { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }

        public ApiResult()
        {
        }

        /// <summary>
        /// 建立成功
        /// </summary>
        /// <param name="data"></param>
        public ApiResult(object data)
        {
            Code = "0000";
            Success = true;
            DataTime = DateTime.Now;
            Data = data;
        }

        /// <summary>
        /// 建立失败
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public ApiResult(string code, string message)
        {
            Code = code;
            Success = false;
            this.DataTime = DateTime.Now;
            Data = null;
            Message = message;
        }
    }
}
