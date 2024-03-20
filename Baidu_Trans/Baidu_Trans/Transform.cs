using System;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using Baidu_Trans;

namespace Baidu_Trans
{
    public class Transform
    {

        string q;
        string from;
        string to;
        string appId;
        string salt;
        string secretKey;

        public Transform(string q,string from,string to,string appId,string salt,string secretKey)
        {

            this.q = q;
            this.from = from;
            this.to = to;
            this.appId = appId;
            this.salt = salt;
            this.secretKey = secretKey;
        }

        /*
         *  完成转换并返回json结果 
         */
        public string TransString()
        {
            string sign = EncryptString.Encryptstring(appId + q + salt + secretKey);
            string url = "http://api.fanyi.baidu.com/api/trans/vip/translate?";

            url += "q=" + WebUtility.UrlEncode(q);
            url += "&from=" + from;
            url += "&to=" + to;
            url += "&appid=" + appId;
            url += "&salt=" + salt;
            url += "&sign=" + sign;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = null;
            request.Timeout = 6000;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
    }
}
