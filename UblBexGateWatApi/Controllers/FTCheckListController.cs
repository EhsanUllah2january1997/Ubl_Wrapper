using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UblBexGateWatApi.Models;

namespace UblBexGateWatApi.Controllers
{
    
    [RoutePrefix("Api/FTCheckList")]
    public class FTCheckListController : ApiController
    {
        Common main = new Common();
        

        [HttpPost]
        [Route("GetUserCheckListDetails")]
        public Object GetUserCheckListDetails(GetDetalById res)
        {
            if (res != null)
            {
                ApiDetails data = new ApiDetails();
                data.ApiName = "GetUserCheckListDetails";
                data.Url = "Api/FTCheckList/GetUserCheckListDetails";
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


        [HttpPost]
        [Route("PostUserCheckListDetails")]
        public Object PostUserCheckListDetails(ViewModel_CheckListPostDetails res)
        {
            if (res != null)
            {
                ApiDetails data = new ApiDetails();
                data.ApiName = "PostUserCheckListDetails";
                data.Url = "Api/FTCheckList/PostUserCheckListDetails";
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
                ublApi.ApiResponse = main.MsgToObject("Invalid Model");
                return Json(ublApi);
            }
        }
    }
}
