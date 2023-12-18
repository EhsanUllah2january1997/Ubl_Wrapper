using Newtonsoft.Json;
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
    //[Authorize]
    [RoutePrefix("Api/CheckList")]
    public class CheckListController : ApiController
    {

        Common main = new Common();

        [HttpGet]
        [Route("GetUserCheckListDetails")]
        public Object GetUserCheckListDetails(GetDetalById res)
        {
            if (res != null)
            {
                ApiDetails data = new ApiDetails();
                data.ApiName = "GetUserCheckListDetails";
                data.Url = "Api/CheckList/GetUserCheckListDetails";
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
                ublApi.ApiResponse = "Invalid Model"; ;
                return Json(ublApi);
            }
        }



        [HttpPost]
        [Route("PostUserCheckListDetails")]
        public Object PostUserCheckListDetails(ViewModel_CheckListPostDetails res)
        {
            ApiDetails data = new ApiDetails();
            data.ApiName = "GetUserCheckListDetails";
            data.Url = "Api/CheckList/PostUserCheckListDetails";
            data.Type = "POST";
            data.data = res;
            var result = main.ApiResponse(data);
            return Json(result);

        }
    }
}
