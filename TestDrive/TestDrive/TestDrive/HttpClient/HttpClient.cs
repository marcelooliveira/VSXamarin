using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace TestDrive.HttpClient
{
    public class RequestMethod
    {
        public static string Get = "GET";
        public static string Post = "POST";
    }

    public class HttpClient<T>
    {
        public delegate void RequestCompletedEventHandler(object sender, RequestEventArgs<T> e);
        public delegate void RequestErrorEventHandler(object sender, RequestEventArgs<T> e);

        public event RequestCompletedEventHandler RequestCompleted;
        public event RequestErrorEventHandler RequestError;

        public void Request(string requestMethod, string url)
        {
            Request(requestMethod, url, null);
        }

        public void Request(string requestMethod, string url, object requestObject)
        {
            try
            {
                var request = HttpWebRequest.Create(url);
                request.Method = requestMethod;
                
                var result = (IAsyncResult)request.BeginGetResponse(ResponseCallback, request);
            }
            catch (Exception ex)
            {
                if (RequestError != null)
                {
                    //Raise Request Error (with custom Exception during response call back)
                    RequestError(this, new RequestEventArgs<T>()
                    {
                        IsError = true,
                        ErrorMessage = Constants.REQUEST_EXCEPTION,
                        Exception = ex
                    });
                }
            }
        }

        private void ResponseCallback(IAsyncResult result)
        {
            try
            {
                var request = (HttpWebRequest)result.AsyncState;
                var response = request.EndGetResponse(result);

                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string contents = reader.ReadToEnd();
                    ParseJson(contents);
                }
            }
            catch (Exception ex)
            {
                if (RequestError != null)
                {
                    //Raise Sync Error (Custom Exception during response call back)
                    RequestError(this, new RequestEventArgs<T>()
                    {
                        IsError = true,
                        ErrorMessage = Constants.REQUEST_CALLBACK_EXCEPTION,
                        Exception = ex
                    });
                }
            }
        }

        private void ParseJson(string jsonString)
        {
            try
            {
                T[] rootObject = new T[] { };
                rootObject = JsonConvert.DeserializeObject<T[]>(jsonString);

                if(RequestCompleted!= null)
                {
                    RequestCompleted(this, new RequestEventArgs<T>
                    {
                        IsError = false,
                        ErrorMessage = string.Empty,
                        Exception = new NotSupportedException(Constants.GRACEFUL_EXECUTION_MESSAGE),
                        ResponseObjects = (T[])rootObject
                    });
                }
            }
            catch (Exception ex)
            {
                if(RequestError!= null)
                {
                    //Raise Sync Error (Custom Exception during parsing)
                    RequestError(this, new RequestEventArgs<T>()
                    {
                        IsError = true,
                        ErrorMessage = Constants.REQUEST_PARSE_JSON_EXCEPTION,
                        Exception = ex
                    });
                }
            }
        }
    }
}