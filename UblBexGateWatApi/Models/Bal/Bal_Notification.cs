using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace UblBexGateWatApi.Models.Bal
{
    public class Bal_Notification
    {
        public async Task<ResultApi> PushNotification(ViewModel_PushNotification data)
        {
            ResultApi model = new ResultApi();
            model.Status = "Fail";
            List<string> DeviceId = new List<string>();
            var senderId = System.Configuration.ConfigurationManager.AppSettings["SenderId"];
            var Authorization = System.Configuration.ConfigurationManager.AppSettings["Authorization"];
            var url = System.Configuration.ConfigurationManager.AppSettings["FireBaseUrl"];
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);

            request.AddHeader("SenderId", senderId);
            request.AddHeader("Authorization", Authorization);
            request.AddHeader("Content-Type", "application/json");

            var requestBody = new
            {
                registration_ids = data.DeviceId,
                notification = new
                {
                    title = data.Msg,
                    body = "",
                    data = new
                    {
                        key = "value"
                    }
                }
            };

            string jsonRequestBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            request.AddParameter("application/json", jsonRequestBody, ParameterType.RequestBody);
            RestResponse response = await client.ExecuteAsync(request);
            var result = response.Content;
            model.ApiResponse = JsonConvert.DeserializeObject<dynamic>(result);
            model.Code = Convert.ToInt32(response.StatusCode);
            if (model.Code == 200)
            {
                model.Status = "success";
            }

            return model;
        }
    }
}