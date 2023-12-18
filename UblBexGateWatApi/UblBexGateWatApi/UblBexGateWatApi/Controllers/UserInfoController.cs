using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UblBexGateWatApi.Models;

namespace UblBexGateWatApi.Controllers
{
    [Authorize]
    [RoutePrefix("Api/UserInfo")]
    public class UserInfoController : ApiController
    {
        Common main = new Common();
        [HttpGet]
        [Route("GetUserProfileInfo")]
        public object GetUserProfileInfo(GetDetalById res)
        {
            if (res != null)
            {
                ApiDetails data = new ApiDetails();
                data.ApiName = "GetUserProfileInfo";
                data.Url = "Api/UserInfo/GetUserProfileInfo";
                data.Type = "POST";
                data.Token = Convert.ToString(Request.Headers.GetValues("Authorization").FirstOrDefault());
                res.Token = Convert.ToString(data.Token.Replace("Bearer ", ""));
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
    }
}
