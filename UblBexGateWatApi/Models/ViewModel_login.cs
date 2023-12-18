using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UblBexGateWatApi.Models
{
    public class ResponseMessage
    {
        public string error { get; set; }
    }

    public class ViewModel_login
    {
        public string username { get; set; }
        public string password { get; set; }
        public string deviceId { get; set; }
        public string fcmToken { get; set; }
    }

    public class ViewModel_OTP
    {
        public string username { get; set; }
        public string password { get; set; }
        public string deviceId { get; set; }
        public string token { get; set; }
        public decimal Otp { get; set; }
        public string fcmToken { get; set; }
    }

    public class ApiDetails
    {
        public string ApiName { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string Token { get; set; }
        public object data { get; set; }

    }

    public class ApiLogsDetails
    {
        public string ApiName { get; set; }
        public string Request { get; set; }
        public string Respose { get; set; }
        public string Message { get; set; }
        public long Code { get; set; }
        public object JsonObject { get; set; }
        public int Ubl_ApiResponseCode { get; set; }
    }

    public class ResultApi
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public object ApiResponse { get; set; }
    }


    public class ApiResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object JsonObject { get; set; }
    }

}