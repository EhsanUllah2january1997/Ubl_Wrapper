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
                ublApi.ApiResponse = "Invalid Model";
                return Json(ublApi);
            }
        }

        [HttpPost]
        [Route("OtpVerify")]
        public async Task<object> VerifyOtpLogin(ViewModel_OTP res)
        {
            if (res != null)
            {
                string Token = Convert.ToString(Request.Headers.GetValues("Authorization").FirstOrDefault());
                var options = new RestClientOptions("http://localhost:10000")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/Api/Login/OtpVerify", Method.Post);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("Authorization", Token);
                request.AddParameter("username", res.username);
                request.AddParameter("password", res.password);
                request.AddParameter("deviceid", res.deviceId);
                request.AddParameter("Otp", res.Otp);

                RestResponse response = await client.ExecuteAsync(request);
                var result = JsonConvert.DeserializeObject<dynamic>(response.Content);
                return Json(result);
            }
            else
            {
                ResultApi ublApi = new ResultApi();
                ublApi.Code = 404;
                ublApi.Status = "Fail";
                ublApi.ApiResponse = "Invalid Model"; ;
                return Json(ublApi);
            }
        }
    }
}
