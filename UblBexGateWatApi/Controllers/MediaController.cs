using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UblBexGateWatApi.Models;

namespace UblBexGateWatApi.Controllers
{

    [RoutePrefix("Api/Media")]
    public class MediaController : ApiController
    {
        Common com = new Common();
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
            path = System.Configuration.ConfigurationManager.AppSettings["DocsUrl"];
            HttpContent file1;
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                var provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(new InMemoryMultipartFormDataStreamProvider());
                //access form data  

                NameValueCollection formData = provider.FormData;
                var a = provider.Contents.Count;
                var isChecker = provider.FormData["isChecker"];
                if (!string.IsNullOrWhiteSpace(isChecker))
                {
                    path = System.Configuration.ConfigurationManager.AppSettings["DocsUrlChecker"];
                }
               
                Common.DetailsLog("Recv Data Count : " + provider.Contents.Count,"MediaUpload");
                Common.DetailsLog("Recv Data Count : " + provider.FormData.Count, "MediaUpload");
                Common.DetailsLog("Recv Data Count : " + provider.Files, "MediaUpload");

                //access files  
                IList<HttpContent> files = provider.Files;
                Common.DetailsLog("Recv Files List : " + provider.Files, "MediaUpload");

                string URL = String.Empty;
                try
                {
                    //Files Check Added By Ahsan 21-Oct-2020
                    if (files.Count == 0)
                    {
                        StepLog = StepLog + "\n Files Count : " + files.Count;
                        Common.DetailsLog("Recv Files List : " + provider.Files, "MediaUpload");

                        return Content(HttpStatusCode.BadRequest, "No Files Found");
                    }
                    //End
                    StepLog = StepLog + "\n Paramter Passed : " + files;
                    foreach (HttpContent file2 in files)
                    {
                        string thisFileName = string.Empty;
                        try
                        {
                            file1 = file2;
                            StepLog = StepLog + " \n " + DateTime.Now + "   file1 :  " + file1;
                            thisFileName = file1.Headers.ContentDisposition.FileName.Trim('\"');
                            StepLog = StepLog + " \n " + DateTime.Now + "   FileName :  " + thisFileName;
                        }
                        catch (Exception e)
                        {
                            file1 = file2;
                            // TextLogging.CreateExceptionLog(StepLog + " \n Erorr file name :" + thisFileName + " " + System.Configuration.ConfigurationManager.AppSettings["DocsUrl"] + " path " + path + " directoryName " + directoryName + " filename " + filename + " message : " + e.Message + " InnerException : " + e.InnerException + " Stack Trace : " + e.StackTrace, e.Message, e.StackTrace, "MediaUpload");
                        }
                        var namex = thisFileName.Split('_');

                        int indexr = thisFileName.IndexOf(".") - 1;
                        var remove = thisFileName.Remove(indexr + 1);
                        var name = remove.Split('_');
                        namex = name;
                        PostIdq = namex[0];
                        StepLog = StepLog + " \n " + DateTime.Now + "   Split File Name pass to parmeter  name :  " + name;
                        try
                        {


                            if (namex.Count() > 2 && !thisFileName.Contains(".mp4"))
                            {
                                //directoryName = System.IO.Path.Combine(path, "ClientDocument\\" + namex[0] + "\\" + namex[1] + "\\" + namex[2]);
                                directoryName = System.IO.Path.Combine(path, "ClientDocument\\" + namex[0] + "\\images\\");
                                filename = System.IO.Path.Combine(directoryName, thisFileName);
                                StepLog = StepLog + " \n " + DateTime.Now + "   File Path" + directoryName;
                                Stream input1 = await file1.ReadAsStreamAsync();
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
                                if (thisFileName.Contains("email"))
                                {
                                    var VideoDir = formData["Directory"];
                                    directoryName = System.IO.Path.Combine(path, "ClientDocument\\" + namex[0] + "\\images");
                                    filename = System.IO.Path.Combine(directoryName, thisFileName);
                                    StepLog = StepLog + " \n email images " + DateTime.Now + "   File Path" + directoryName;
                                    Stream input2 = await file1.ReadAsStreamAsync();
                                    if (!Directory.Exists(directoryName))
                                    {
                                        StepLog = StepLog + " \n " + DateTime.Now + "    directory doesnot Exist Create New Directory : " + directoryName;
                                        Directory.CreateDirectory(@directoryName);
                                    }
                                    using (Stream file = File.OpenWrite(filename))
                                    {

                                        StepLog = StepLog + " \n " + DateTime.Now + "   Move File to Directory : " + directoryName;

                                        input2.CopyTo(file);
                                        //close file  
                                        file.Close();
                                    }
                                }
                            }
                            else
                            {
                                try
                                {
                                    //Added this because images are saving to video folder.
                                    var VideoDir = formData["Directory"];
                                    directoryName = System.IO.Path.Combine(path, "ClientDocument\\" + namex[0] + "\\Video");
                                    filename = System.IO.Path.Combine(directoryName, thisFileName);
                                    StepLog = StepLog + " \n " + DateTime.Now + "   File Path" + directoryName;

                                }
                                catch (Exception e)
                                {
                                    Common.ErrorLogs(e.Message.ToString() + " | " + e.StackTrace.ToString() + " | " + e.InnerException.ToString(), "MediaUpload");

                                }
                            }

                            Stream input = await file1.ReadAsStreamAsync();
                            StepLog = StepLog + " \n " + DateTime.Now + "   Read File ReadAsStreamAsync";


                            if (!Directory.Exists(directoryName))
                            {
                                StepLog = StepLog + " \n " + DateTime.Now + "    directory doesnot Exist Create New Directory : " + directoryName;
                                Directory.CreateDirectory(@directoryName);
                            }
                            using (Stream file = File.OpenWrite(filename))
                            {
                                StepLog = StepLog + " \n " + DateTime.Now + "   Move File to Directory : " + directoryName;

                                input.CopyTo(file);
                                //close file  
                                file.Close();
                            }

                        }
                        catch (Exception e)
                        {
                            Common.ErrorLogs(e.Message.ToString() + " | " + e.StackTrace.ToString() + " | " + e.InnerException.ToString(), "MediaUpload");
                            return BadRequest("Erorr While Uploading Request :" + Request + " message : " + e.Message + " InnerException : " + e.InnerException + " Stack Trace : " + e.StackTrace);
                        }

                    }
                    return Ok("Sucessfull");
                }

                catch (Exception e)
                {
                    Common.ErrorLogs(e.Message.ToString() + " | " + e.StackTrace.ToString() + " | " + e.InnerException.ToString(), "MediaUpload");
                    if (formData["Directory"] == null || formData["Directory"] == string.Empty || formData["Directory"] == "")
                    {
                        return BadRequest("Erorr While Uploading Directory IS required");
                    }
                    else
                    {
                        return BadRequest("Erorr While Uploading Request :" + Request + " message : " + e.Message + " InnerException : " + e.InnerException + " Stack Trace : " + e.StackTrace);
                    }
                }
            }
            catch (Exception e)
            {
                Common.ErrorLogs(e.Message.ToString() + " | " + e.StackTrace.ToString() + " | " + e.InnerException.ToString(), "MediaUpload");
                return BadRequest("Erorr While Uploading Request :" + Request + " message : " + e.Message + " InnerException : " + e.InnerException + " Stack Trace : " + e.StackTrace);
            }
        }
    }
}
