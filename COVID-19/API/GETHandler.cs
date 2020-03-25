using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace COVID_19.API
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    public class GETHandler
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        public GETHandler()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.GET;
        }

        public string GETRequest()
        {
            string responsevalue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = httpMethod.ToString();
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Error Code:" + response.StatusCode.ToString());
                }

                using (Stream streamresponse = response.GetResponseStream())
                {
                    if (streamresponse != null)
                    {
                        using (StreamReader streamreader = new StreamReader(streamresponse))
                        {
                            responsevalue = streamreader.ReadToEnd();
                        }
                    }
                }
            }
            return responsevalue;
        }
    }
}
