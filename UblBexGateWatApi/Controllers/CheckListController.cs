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

    [RoutePrefix("Api/CheckList")]
    public class CheckListController : ApiController
    {

        Common main = new Common();
        [HttpPost]
        [Route("GetCheckListLastScore")]
        public Object GetCheckListLastScore(ViewMmodel_GetLastScore res)
        {
            if (res != null)
            {
                ApiDetails data = new ApiDetails();
                data.ApiName = "GetCheckListLastScore";
                data.Url = "Api/CheckList/GetCheckListLastScore";
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
                ublApi.ApiResponse = main.MsgToObject("Invalid Model");
                return Json(ublApi);
            }
        }

        //[HttpPost]
        //[Route("GetUserCheckListDetailsRecord")]
        //public Object GetUserCheckListDetailsRecord(GetDetalById res)
        //{
        //    if (res != null)
        //    {
        //        ApiDetails data = new ApiDetails();
        //        data.ApiName = "GetUserCheckListDetailsRecord";
        //        data.Url = "Api/CheckList/GetUserCheckListDetailsRecord";
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



        [HttpPost]
        [Route("PostUserCheckListDetails")]
        public Object PostUserCheckListDetails(ViewModel_CheckListPostDetails res)
        {
            if (res != null)
            {
                ApiDetails data = new ApiDetails();
                data.ApiName = "PostUserCheckListDetails";
                data.Url = "Api/CheckList/PostUserCheckListDetails";
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

        [HttpPost]
        [Route("GetAttributesDataBOM")]
        public Object Get_UserRatingDetailsForBranchUser(GetDetalById res)
        {
            if (res != null)
            {
                ApiDetails data = new ApiDetails();
                data.ApiName = "GetAttributesDataBOM";
                data.Url = "Api/CheckList/GetAttributesDataBOM";
                data.Type = "POST";
                data.Token = Convert.ToString(Request.Headers.GetValues("Authorization").FirstOrDefault());
                res.Token = data.Token.Replace("Bearer ", "");
                data.data = res;
                var result = main.ApiResponse(data);
                return Ok(result);
            }
            else
            {
                ResultApi ublApi = new ResultApi();
                ublApi.Code = 404;
                ublApi.Status = "Fail";
                ublApi.ApiResponse = main.MsgToObject("Invalid Model");
                return BadRequest("Invalid Model");
            }
        }


        [HttpPost]
        [Route("PostAttributesDataBOM")]
        public Object PostUserRatingDetailsForBranchUser(ViewModel_PostRatingBOM res)
        {
            if (res.PostRatingBOM != null)
            {
                ApiDetails data = new ApiDetails();
                data.ApiName = "PostAttributesDataBOM";
                data.Url = "Api/CheckList/PostAttributesDataBOM";
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

        [HttpPost]
        [Route("GetAttributesDataSQM")]
        public Object Get_UserRatingDetailsForSQMUser(GetDetalById res)
        {
            if (res != null)
            {
                ApiDetails data = new ApiDetails();
                data.ApiName = "GetAttributesDataSQM";
                data.Url = "Api/CheckList/GetAttributesDataSQM";
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
        [Route("PostAttributesDataSQM")]
        public Object PostUserRatingDetailsForSQMUser(ViewModel_PostRatingSQM res)
        {
            if (res.PostRatingSQM != null)
            {
                ApiDetails data = new ApiDetails();
                data.ApiName = "PostAttributesDataSQM";
                data.Url = "Api/CheckList/PostAttributesDataSQM";
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
