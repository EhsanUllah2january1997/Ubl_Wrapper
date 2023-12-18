using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UblBexGateWatApi.Models;

namespace UblBexGateWatApi.Controllers
{

    [RoutePrefix("Api/Login")]
    public class LoginController : ApiController
    {
        Common main = new Common();
        [HttpPost]
        [Route("GetToken")]
        public async Task<object> Login(ViewModel_login res)
        {
            if (res != null)
            {
                ApiDetails data = new ApiDetails();
                data.ApiName = "LOGIN";
                data.Url = "Api/Login/Token";
                data.Type = "POST";
                data.data = res;
                var result = main.ApiResponse(data);
                return Json(result);
            }
            {
                ResultApi ublApi = new ResultApi();
                ublApi.Code = 404;
                ublApi.Status = "Fail";
                ublApi.ApiResponse = main.MsgToObject("Invalid Model");
                return Json(ublApi);
            }
        }

        [HttpPost]
        [Route("OtpVerify")]
        public async Task<object> VerifyOtpLogin(ViewModel_OTP res)
        {
            ResultApi ublApi = new ResultApi();
            ApiResponse ar = new ApiResponse();
            ar.Message = "Success";
            ar.Code = 200;
            ar.JsonObject = null;

            if (res != null)
            {
                string baseUrlApi = System.Configuration.ConfigurationManager.AppSettings["baseUrlApi"];
                string Token = Convert.ToString(Request.Headers.GetValues("Authorization").FirstOrDefault());
                var options = new RestClientOptions(baseUrlApi)
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("Api/Login/OtpVerify", Method.Post);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("Authorization", Token);
                request.AddParameter("username", res.username);
                request.AddParameter("password", res.password);
                request.AddParameter("deviceid", res.deviceId);
                request.AddParameter("fcmToken", res.fcmToken);
                request.AddParameter("Otp", res.Otp);

                RestResponse response = await client.ExecuteAsync(request);
                var result = JsonConvert.DeserializeObject<dynamic>(response.Content);
                int ublApiCode = Convert.ToInt32(response.StatusCode);
                ar.Code = ublApiCode;
                if (response.Content != null && ublApiCode == 200)
                {
                    ublApi.ApiResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);

                }
                else
                {
                    if (response.Content != null)
                    {
                        ar.Message = "Fail";
                        ar.JsonObject = JsonConvert.DeserializeObject<dynamic>(response.Content);
                        object record = JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(ar));
                        ublApi.ApiResponse = JsonConvert.DeserializeObject<dynamic>(record.ToString());
                    }
                }

                ublApi.Code = 200;
                ublApi.Status = "Success";
            }
            else
            {
                ublApi.Code = 404;
                ublApi.Status = "Fail";
                ublApi.ApiResponse = ublApi.ApiResponse = main.MsgToObject("Invalid Model");
            }
            return Json(ublApi);
        }
    }
}
