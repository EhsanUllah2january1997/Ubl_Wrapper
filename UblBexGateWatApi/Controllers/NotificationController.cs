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
using UblBexGateWatApi.Models.Bal;
using UblBexGateWatApi.Providers;

namespace UblBexGateWatApi.Controllers
{
    [RoutePrefix("Api/Notification")]
    public class NotificationController : ApiController
    {
        //        public async void CallingPushNotification(int userId, string Msg)
        //        {
        //            var options = new RestClientOptions("https://fcm.googleapis.com")
        //            {
        //                MaxTimeout = -1,
        //            };
        //            List<string> deviceIds = new List<string>();
        //            string d = """key=AAAArCU3tQw:APA91bHRZaOLYnoAI9-tmvEwvfnjqyHtFAOuSJzIIIVODgNHUCP5meFGegeDJnH3RLD76ecWB1r4na2F-Mgbuy9ILTKzPtqsgSfP1HBYHwNCqC6KDL6tGZjfiYlH7Qb8vH1oHmdSMMNo""";
        //            deviceIds.Add(d);
        //            deviceIds.Add(d);
        //            deviceIds.Add(d);
        //            var client = new RestClient(options);
        //            var request = new RestRequest("/fcm/send", Method.Post);
        //            request.AddHeader("Authorization", "key=AAAArCU3tQw:APA91bHRZaOLYnoAI9-tmvEwvfnjqyHtFAOuSJzIIIVODgNHUCP5meFGegeDJnH3RLD76ecWB1r4na2F-Mgbuy9ILTKzPtqsgSfP1HBYHwNCqC6KDL6tGZjfiYlH7Qb8vH1oHmdSMMNo");
        //            request.AddHeader("Content-Type", "application/json");
        //            var body = @"{
        //" + "\n" +
        //@"    ""registration_ids"": [""cE4lojKKdkJ9pIC-HeO8Rj:APA91bE7lkVzBjr9n6IjqaIyQgErotvafSKu6gYaJSTPW7zBQ9H7xIEumKPmkTZEzKLPpFVReej68h39CHfX7CFs74wTOdDcRRGzX6QjX2HXzjr435R4NaiBSgXHbnMXLl4mAIsmVyCN"",""cE4lojKKdkJ9pIC-HeO8Rj:APA91bE7lkVzBjr9n6IjqaIyQgErotvafSKu6gYaJSTPW7zBQ9H7xIEumKPmkTZEzKLPpFVReej68h39CHfX7CFs74wTOdDcRRGzX6QjX2HXzjr435R4NaiBSgXHbnMXLl4mAIsmVyCN""]
        //" + "\n" +
        //@"    
        //" + "\n" +
        //@"    ""notification"": {
        //" + "\n" +
        //@"        ""title"": ""ata mata sarakli"",
        //" + "\n" +
        //@"        ""body"": ""Sending push notification through Postman to run Application flow."",
        //" + "\n" +
        //@"        ""data"": {
        //" + "\n" +
        //@"            ""key"": ""value""
        //" + "\n" +
        //@"        }
        //" + "\n" +
        //@"    }
        //" + "\n" +
        //@"}";
        //            request.AddStringBody(body, DataFormat.Json);
        //            RestResponse response = await client.ExecuteAsync(request);
        //            Console.WriteLine(response.Content);
        //        }

        public async Task<ResultApi> PushNotification(ViewModel_PushNotification data)
        {
            //edit by eu
            string SecretKey = Convert.ToString(Request.Headers.GetValues("SecretKey").FirstOrDefault());
            var dekey = EncryptionDecryption.Encrypt(SecretKey);
            string MatchKey = System.Configuration.ConfigurationManager.AppSettings["PushSecretKey"];
            if (dekey == MatchKey)
            {
                Bal_Notification Bal = new Bal_Notification();
                return  await Bal.PushNotification(data);
            }
            else
            {
                ResultApi model = new ResultApi();
                model.Status = "Fail";
                model.ApiResponse = "Access Not Allowed";
                model.Code = 201;
                return  model;
            }
        }

    }
}
