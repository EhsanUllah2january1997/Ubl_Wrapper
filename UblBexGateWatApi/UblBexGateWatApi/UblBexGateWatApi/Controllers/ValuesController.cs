using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using UblBexGateWatApi.Models;

namespace UblBexGateWatApi.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {


        [HttpPost]
        [Route("MediaUpload")]
        public async Task<IHttpActionResult> MediaUpload()
        {
            var PostIdq = string.Empty;
            string StepLog = "APi Method Called MediaUpload";
            var response = Request.CreateResponse(HttpStatusCode.OK);
            string filename = String.Empty;
            string directoryName = String.Empty;
            var path = string.Empty;

            path = System.Configuration.ConfigurationManager.AppSettings["_Logs_Path"];
            HttpContent file1;


            //Check if the request contains multipart / form - data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(new InMemoryMultipartFormDataStreamProvider());
            //access form data  
            NameValueCollection formData = provider.FormData;
            IList<HttpContent> files = provider.Files;
            var a = provider.Contents.Count;
            foreach (HttpContent file2 in files)
            {
                string thisFileName = string.Empty;
                files.Add(file2);
                thisFileName = file2.Headers.ContentDisposition.FileName.Trim('\"');
                path = System.Configuration.ConfigurationManager.AppSettings["DocsUrlChecker"];
                directoryName = System.IO.Path.Combine(path, "ClientDocument\\geteWay\\images\\");
                 filename = System.IO.Path.Combine(directoryName, thisFileName);
                var isChecker = provider.FormData["isChecker"];
                Stream input1 = await file2.ReadAsStreamAsync();
                if (!Directory.Exists(directoryName))
                {
                    StepLog = StepLog + " \n " + DateTime.Now + "    directory doesnot Exist Create New Directory : " + directoryName;
                    Directory.CreateDirectory(@directoryName);
                }
                using (Stream file = File.OpenWrite(filename))
                {
                    StepLog = StepLog + " \n " + DateTime.Now + "   Move File to Directory : " + directoryName;

                    input1.CopyTo(file);

                    //close file 
                    file.Close();
                }

                var options = new RestClientOptions("http://localhost:10000")
                {
                    MaxTimeout = -1,
                };
                //HttpFileCollection _HttpFileCollection = files;
                var client = new RestClient(options);
                var request = new RestRequest("/Api/Question/MediaUpload", Method.Post);
                request.AddHeader("Authorization", "Bearer jMGlINOQWXo25qrl8vIAPVyi0uwdRejwqnQBBa56dvbY_ZrumtBEjpb51NOyzaA65nRnxAUry7qt9ifmKdbGa1lFPrK1jNj1gon44LJRJZ5QwH8N84ZmQcXB-BSR1A3s5gsaAZxbiiE27m-XtZ85Xp6eTvFGFsRbujgFkOMeqVPRBWc-xrvYvcvnXzUNhXvlvbaAa0S0G1m_O5IzJG0R2SSVEiNmS4fn2v3ak_SGuWtyvdNR_wkILswRIjlHwIZuUmlvF2NOWTsxOwIsRyY12OhEIw5xfQilI7BcF5ESp16kT4xck306rveXsWT1CHLk");
                request.AlwaysMultipartFormData = true;
                for (int i = 0; i < a; i++)
                {
                    request.AddFile("iamges",filename);
                }

                request.AddParameter("Directory", "asdf");
                RestResponse dd = await client.ExecuteAsync(request);
                Console.WriteLine(response.Content);

            }


            StepLog = StepLog + "\n Recv Data Count : " + provider.Contents.Count;
            StepLog = StepLog + "\n Recv Data Count : " + provider.FormData.Count;
            StepLog = StepLog + "\n Recv Data Count : " + provider.Files;

            //access files  

            StepLog = StepLog + "\n Recv Files List : " + provider.Files; //Check Added By Ahsan 21-Oct-2020
            string URL = String.Empty;

            return null;
        }
        // GET api/values


        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
