﻿/*----------------------------------------------------------------
    Copyright (C) 2015 Senparc
    
    文件名：CommonJsonSend.cs
    文件功能描述：向需要AccessToken的API发送消息的公共方法
    
    
    创建标识：Senparc - 20150211
    
    修改标识：Senparc - 20150303
    修改描述：整理接口
 
    修改标识：Senparc - 20150312
    修改描述：开放代理请求超时时间
----------------------------------------------------------------*/

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Senparc.Weixin.Entities;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.Helpers;
using Senparc.Weixin.HttpUtility;

namespace Senparc.Weixin.MP.CommonAPIs
{
    public static class CommonJsonSend
    {
        #region 同步请求

        /// <summary>
        /// 向需要AccessToken的API发送消息的公共方法
        /// </summary>
        /// <param name="accessToken">这里的AccessToken是通用接口的AccessToken，非OAuth的。如果不需要，可以为null，此时urlFormat不要提供{0}参数</param>
        /// <param name="urlFormat"></param>
        /// <param name="data">如果是Get方式，可以为null</param>
        /// <param name="sendType"></param>
        /// <param name="timeOut">代理请求超时时间（毫秒）</param>
        /// <param name="checkValidationResult"></param>
        /// <param name="jsonSetting"></param>
        /// <returns></returns>
        //[Obsolete("此方法已过期，请使用Senparc.Weixin.CommonAPIs.CommonJsonSend.Send()方法")]
        public static WxJsonResult Send(string accessToken, string urlFormat, object data, CommonJsonSendType sendType = CommonJsonSendType.POST, int timeOut = Config.TIME_OUT, bool checkValidationResult = false, JsonSetting jsonSetting = null/*, int retry40001ErrorTimes = 0*/)
        {
            WxJsonResult result = null;
            try
            {
                result = Senparc.Weixin.CommonAPIs.CommonJsonSend.Send(accessToken, urlFormat, data, sendType, timeOut,
                    checkValidationResult, jsonSetting);
            }
            //catch (ErrorJsonResultException ex)
            //{
            //    if (ex.JsonResult.errcode == ReturnCode.获取access_token时AppSecret错误或者access_token无效 /*40001*/)
            //    {
            //        if (retry40001ErrorTimes == 0)
            //        {
            //            result = Send(accessToken, urlFormat, data, sendType, timeOut, checkValidationResult,
            //                jsonSetting, retry40001ErrorTimes + 1);
            //        }
            //        else if (retry40001ErrorTimes == 1)
            //        {
                        
            //        }

            //    }
            //}
            catch
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// 向需要AccessToken的API发送消息的公共方法
        /// </summary>
        /// <param name="accessToken">这里的AccessToken是通用接口的AccessToken，非OAuth的。如果不需要，可以为null，此时urlFormat不要提供{0}参数</param>
        /// <param name="urlFormat">用accessToken参数填充{0}</param>
        /// <param name="data">如果是Get方式，可以为null</param>
        /// <param name="sendType"></param>
        /// <param name="timeOut">代理请求超时时间（毫秒）</param>
        /// <param name="checkValidationResult"></param>
        /// <param name="jsonSetting"></param>
        /// <returns></returns>
        //[Obsolete("此方法已过期，请使用Senparc.Weixin.CommonAPIs.CommonJsonSend.Send<T>()方法")]
        public static T Send<T>(string accessToken, string urlFormat, object data, CommonJsonSendType sendType = CommonJsonSendType.POST, int timeOut = Config.TIME_OUT, bool checkValidationResult = false, JsonSetting jsonSetting = null)
        {
            return Senparc.Weixin.CommonAPIs.CommonJsonSend.Send<T>(accessToken, urlFormat, data, sendType, timeOut, checkValidationResult, jsonSetting);
        }

        #endregion

    }
}