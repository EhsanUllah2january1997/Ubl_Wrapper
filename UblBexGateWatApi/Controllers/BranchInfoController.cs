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
    
    [RoutePrefix("Api/Branches")]
    public class BranchInfoController : ApiController
    {
        Common main = new Common();

        [HttpPost]
        [Route("GetScheduleBracnhList")]
        public Object getScheduleBranchList(GetScheduleBranchListData res)
        {
            if (res != null)
            {
                ApiDetails data = new ApiDetails();
                data.ApiName = "GetScheduleBracnhList";
                data.Url = "Api/Branches/GetScheduleBracnhList";
                data.Type = "POST";
                data.Token = Convert.ToString(Request.Headers.GetValues("Authorization").FirstOrDefault());
                res.Token = data.Token.Replace("Bearer ", "");
                data.data = res;
                var result = main.ApiResponse(data);
                return Json(result);
            }
            else
            {
                ResultApi ublApi = new ResultApi();
                ublApi.Code = 404;
                ublApi.Status = "Fail";
                ublApi.ApiResponse = main.MsgToObject("Invalid Model");
                return Json(ublApi);
            }
        }

        [HttpGet]
        [Route("getAllBranches")]
        public Object getAllBranches()
        {
            string auth = Convert.ToString(Request.Headers.GetValues("Authorization").FirstOrDefault());
            if (!string.IsNullOrEmpty(auth))
            {
                GeToken res = new GeToken();
                ApiDetails data = new ApiDetails();
                res.Token = auth.Replace("Bearer ", "");

                data.ApiName = "getAllBranches";
                data.Url = "Api/Branches/getAllBranches";
                data.Type = "POST";
                data.Token = auth;
                data.data = res;
                var result = main.ApiResponse(data);
                return Json(result);
            }
            else
            {
                ResultApi ublApi = new ResultApi();
                ublApi.Code = 404;
                ublApi.Status = "Fail";
                ublApi.ApiResponse = main.MsgToObject("Authoriztion Token Missing In Header");
                return Json(ublApi);
            }
        }

        //[HttpPost]
        //[Route("GetUpComingScheduleBranchList")]
        //public Object getScheduleBranchListByDate(GetDetalByIdDate res)
        //{
        //    if (res != null)
        //    {
        //        ApiDetails data = new ApiDetails();
        //        data.ApiName = "GetUpComingScheduleBranchList";
        //        data.Url = "Api/Branches/GetUpComingScheduleBranchList";
        //        data.Type = "POST";
        //        data.Token = Convert.ToString(Request.Headers.GetValues("Authorization").FirstOrDefault());
        //        res.Token = data.Token.Replace("Bearer ", "");
        //        data.data = res;
        //        var result = main.ApiResponse(data);
        //        return Json(result);
        //    }
        //    else
        //    {
        //        ResultApi ublApi = new ResultApi();
        //        ublApi.Code = 404;
        //        ublApi.Status = "Fail";
        //        ublApi.ApiResponse = main.MsgToObject("Invalid Model");
        //        return Json(ublApi);
        //    }
        //}

    }
}
