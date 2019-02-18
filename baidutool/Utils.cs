using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace baidutool
{
   public static class Utils
    {
        public static string GetHtml(string myUrl)
        {
            HttpWebRequest myHttpWebRequest;

            HttpWebResponse myHttpWebResponse;

            //string Html; 

            try
            {

                string URL = myUrl;

                Uri myUri = new Uri(myUrl);

                WebRequest myWebRequest = WebRequest.Create(URL);

                //使用Creat方法创建WebRequest实例 

                myHttpWebRequest = (HttpWebRequest)myWebRequest;

                //实现WebRequest类型和HttpWebRequest类型的转换 

                WebResponse myWebResponse = myHttpWebRequest.GetResponse();

                //获得响应信息 

                myHttpWebResponse = (HttpWebResponse)myWebResponse;

                Stream myStream = myHttpWebResponse.GetResponseStream();

                //获得从当前Internet资源返回的响应流数据 

                StreamReader srReader = new StreamReader(myStream, Encoding.Default);

                //利用获得的响应流和系统缺省编码来初始化StreamReader实例。 

                string sTemp = srReader.ReadToEnd();

                //从响应流从读取数据 

                srReader.Close();

                return sTemp;
            }

            //显示读取的数据 ( ) 

            catch (WebException WebExcp)
            {

                return WebExcp.Message.ToString();
            }
        }

        public static bool VerIP(string ip, int port)
        {
            try
            {
                HttpWebRequest Req;
                HttpWebResponse Resp;
                WebProxy proxyObject = new WebProxy(ip, port);// port为端口号 整数型
                Req = WebRequest.Create("https://www.baidu.com") as HttpWebRequest;
                Req.Proxy = proxyObject; //设置代理
                Req.Timeout = 1000;   //超时
                Resp = (HttpWebResponse)Req.GetResponse();
                Encoding bin = Encoding.GetEncoding("UTF-8");
                using (StreamReader sr = new StreamReader(Resp.GetResponseStream(), bin))
                {
                    string str = sr.ReadToEnd();
                    if (str.Contains("百度"))
                    {
                        Resp.Close();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
