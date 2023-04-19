using System;
using System.Collections.Generic;
using System.Text;

namespace Candor.Models.Json
{
    public class JsonResult<T>
    {
        public int ResultCode { get; set; }
        public string ResultMsg { get; set; }
        public T Data { get; set; }
    }
}
