using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Collections.Specialized;
using System.Net.Http;


namespace UblBexGateWatApi.Models
{
    public class Common
    {

        public dynamic ApiResponse(ApiDetails data)
        {
            ResultApi ublApi = new ResultApi();
            ApiLogsDetails log = new ApiLogsDetails();
            log.ApiName = data.ApiName + " | " + data.Url + " | " + data.Type;

            try
            {
                var options = new RestClientOptions("http://localhost:10000/")
                {
                    MaxTimeout = -1,
                };

                var body = JsonConvert.SerializeObject(data.data);
                var client = new RestClient(options);
                var request = new RestRequest(data.Url, Method.Post);
                if (data.Url.ToLower() != "api/login/token")
                {
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("Authorization", Convert.ToString(data.Token));
                }
                request.AddStringBody(body, DataFormat.Json);
                RestResponse response = client.Execute(request);
                int ublApiCode = Convert.ToInt32(response.StatusCode);
                if (response.Content != null)
                {
                    ublApi.ApiResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
                }
                log.Code = 200;
                log.Message = "Success";
                log.Request = body;
                log.Respose = Convert.ToString(JsonConvert.DeserializeObject(ublApi.ApiResponse.ToString()));
                log.Ubl_ApiResponseCode = ublApiCode;

            }
            catch (Exception ex)
            {
                log.Message = "Fail";
                log.Code = 404;
                log.JsonObject = ex.Message.ToString() + " | " + ex.InnerException.ToString() + " | " + ex.StackTrace.ToString();

                var ErrorLog = JsonConvert.SerializeObject(log);
                ErrorLogs(ErrorLog.ToString(), data.ApiName);
            }


            var detailsLog = JsonConvert.SerializeObject(log);
            DetailsLog(detailsLog.ToString(), data.ApiName);
            ublApi.Code = Convert.ToInt32(log.Code);
            ublApi.Status = log.Message;
            return ublApi;
        }
        public static void DetailsLog(string LOG, string Method)
        {
            string detailLogEnable = System.Configuration.ConfigurationManager.AppSettings["detailLogEnable"];
            if (detailLogEnable.ToLower() == "y")
            {
                string ProjectPath = System.Configuration.ConfigurationManager.AppSettings["LogsPath"];
                ProjectPath = ProjectPath + "//" + "DetailsLog";
                if (!Directory.Exists(ProjectPath))
                {
                    Directory.CreateDirectory(ProjectPath);
                }
                if (Directory.Exists(ProjectPath))
                {
                    string FileName = ProjectPath + Method + "[-API]" + DateTime.Now.ToString("MMM-dd-yyyy") + ".txt";
                    if (File.Exists(FileName))
                    {
                        using (StreamWriter sw = File.AppendText(FileName))
                        {
                            //sw.WriteLine("This");
                            sw.WriteLine(string.Format("Time Recorded     \t:{0}{1}", DateTime.Now.ToString(), "\n\r"));
                            sw.WriteLine(string.Format("Detail\t:{0}{1}", LOG, "\n\r"));
                            sw.WriteLine("=======================================================================================================\n\r");
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.CreateText(FileName))
                        {
                            System.Text.StringBuilder str = new System.Text.StringBuilder();
                            str.Append(string.Format("Time Recorded     \t:{0}", DateTime.Now.ToString())).Append(Environment.NewLine);
                            str.Append(string.Format("Detail\t:{0}", LOG)).Append(Environment.NewLine);
                            str.Append("=======================================================================================================").Append(Environment.NewLine);
                            sw.WriteLine(str.ToString());
                        }
                    }
                }
                else
                {
                    throw new DirectoryNotFoundException();
                }
            }
        }
        public static void ErrorLogs(string LOG, string Method)
        {
            string ProjectPath = System.Configuration.ConfigurationManager.AppSettings["LogsPath"];
            ProjectPath = ProjectPath + "//" + "ErrorLogs";
            if (!Directory.Exists(ProjectPath))
            {
                Directory.CreateDirectory(ProjectPath);
            }
            if (Directory.Exists(ProjectPath))
            {
                string FileName = ProjectPath + Method + "-[API]" + DateTime.Now.ToString("MMM-dd-yyyy") + ".txt";
                if (File.Exists(FileName))
                {
                    using (StreamWriter sw = File.AppendText(FileName))
                    {
                        //sw.WriteLine("This");
                        sw.WriteLine(string.Format("Time Recorded     \t:{0}{1}", DateTime.Now.ToString(), "\n\r"));
                        sw.WriteLine(string.Format("Detail\t:{0}{1}", LOG, "\n\r"));
                        sw.WriteLine("=======================================================================================================\n\r");
                    }
                }
                else
                {
                    using (StreamWriter sw = File.CreateText(FileName))
                    {
                        System.Text.StringBuilder str = new System.Text.StringBuilder();
                        str.Append(string.Format("Time Recorded     \t:{0}", DateTime.Now.ToString())).Append(Environment.NewLine);
                        str.Append(string.Format("Detail\t:{0}", LOG)).Append(Environment.NewLine);
                        str.Append("=======================================================================================================").Append(Environment.NewLine);
                        sw.WriteLine(str.ToString());
                    }
                }
            }
            else
            {
                throw new DirectoryNotFoundException();
            }
        }




    }
}
