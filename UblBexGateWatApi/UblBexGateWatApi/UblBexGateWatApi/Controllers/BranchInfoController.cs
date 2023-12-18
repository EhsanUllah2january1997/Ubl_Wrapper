using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    [RoutePrefix("Api/Branches")]
    public class BranchInfoController : ApiController
    {
        Common main = new Common();

        [HttpGet]
        [Route("GetScheduleBracnhList")]
        public Object getScheduleBranchList(GetDetalById res)
        {
            if (res != null)
            {
                ApiDetails data = new ApiDetails();
                data.ApiName = "GetScheduleBracnhList";
                data.Url = "Api/Branches/GetScheduleBracnhList";
                data.Type = "POST";
                data.Token = Convert.ToString(Request.Headers.GetValues("Authorization").FirstOrDefault());
                data.data = res;
                var result = main.ApiResponse(data);
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
