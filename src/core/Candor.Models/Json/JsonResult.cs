using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Candor.Models.Json
{
    public class JsonResult<T>
    {
        public int ResultCode { get; set; }
        public object ResultMsg { get; set; }
        public T Data { get; set; }
        public int? Total { get; set; }

        public DateTime ServerTime { get; set; }

        /// <summary>
        /// 附加数据
        /// </summary>
        public object Extras { get; set; }

        public JsonResult()
        {
            ResultMsg = string.Empty;
            ServerTime = DateTime.Now;
            //ServerTime = DateTimeOffset.Now.ToUnixTimeSeconds(); //时间戳
        }

        public bool ShouldSerializeTotal()
        {
            // 如果 Total 有值，则序列化 Total 属性
            return Total.HasValue;
        }

        public bool ShouldSerializeExtras()
        {
            // 根据条件决定是否序列化 Extras 属性
            return Debugger.IsAttached;
        }
    }
}
