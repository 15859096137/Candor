using Candor.Exceptions;
using Candor.Models.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;

namespace Candor.WebAspNet.Handlers
{
    /// <summary>
    /// AjaxHandler 的摘要说明
    /// </summary>
    public class AjaxHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var action = string.Empty;
            object result = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(action))
                {
                    throw new InvalidActionException();
                }
                Type type = this.GetType();
                MethodInfo method = type.GetMethod(action);
                if (method == null)
                {
                    throw new InvalidActionException();
                }
                result = method.Invoke(this, null);
                if (result == null || string.IsNullOrWhiteSpace(result.ToString()))
                {
                    throw new InvalidActionException("响应结果不正确");
                }
            }
            catch (BaseException ex)
            {
                // 处理自定义异常
                result = HandleException(ex.ResultCode, ex.Message);
            }
            catch (Exception ex)
            {
                result = HandleException(ResultCodes.InternalServerError, ex.Message);
            }

            result = new JavaScriptSerializer().Serialize(result);

            context.Response.ContentType = "application/json";
            context.Response.Write(result);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private object HandleException(int resultCode, string resultMsg)
        {
            JsonResult<object> result = new JsonResult<object>();
            result.Data = null;
            result.ResultCode = resultCode;
            result.ResultMsg = resultMsg;
            return new JavaScriptSerializer().Serialize(result);
        }
    }
}