using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
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
                Req.Timeout = 3000;   //超时
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
        
        #region 代理换ip
        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);

        public static bool RefreshIESettings(string strProxy)
        {
            const int INTERNET_OPTION_PROXY = 38;
            const int INTERNET_OPEN_TYPE_PROXY = 3;

            Struct_INTERNET_PROXY_INFO struct_IPI;

            // Filling in structure 
            struct_IPI.dwAccessType = INTERNET_OPEN_TYPE_PROXY;
            struct_IPI.proxy = Marshal.StringToHGlobalAnsi(strProxy);
            struct_IPI.proxyBypass = Marshal.StringToHGlobalAnsi("local");

            // Allocating memory 
            IntPtr intptrStruct = Marshal.AllocCoTaskMem(Marshal.SizeOf(struct_IPI));

            // Converting structure to IntPtr 
            Marshal.StructureToPtr(struct_IPI, intptrStruct, true);

            bool iReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_PROXY, intptrStruct, Marshal.SizeOf(struct_IPI));
            return iReturn;
        }
        
        //定义结构体代理信息
        public struct Struct_INTERNET_PROXY_INFO
        {
            public int dwAccessType;
            public IntPtr proxy;
            public IntPtr proxyBypass;
        };
        #endregion

        #region 路由器换ip
        public static string Disconnect(string ip,string user,string pwd)
        {
            try
            {
                string url = "断 线";
                string uri = "http://" + ip + "/userRpm/StatusRpm.htm?Disconnect=" + System.Web.HttpUtility.UrlEncode(url, System.Text.Encoding.GetEncoding("gb2312")) + "&wan=1";
                string sUser = user;
                string sPwd = pwd;
                string sDomain = "";
                NetworkCredential oCredential;
                HttpWebRequest oRequest = (System.Net.HttpWebRequest)WebRequest.Create(uri);
                if (oRequest != null)
                {
                    oRequest.ProtocolVersion = HttpVersion.Version11;// send request
                    oRequest.Method = "GET";
                    oRequest.ContentType = "application/x-www-form-urlencoded";
                    oRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; GTB6.4; .NET CLR 2.0.50727; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                    oRequest.Referer = ip;

                    if (sUser != String.Empty)
                    {
                        oCredential = new NetworkCredential(sUser, sPwd, sDomain);
                        oRequest.Credentials = oCredential.GetCredential(new Uri(uri), String.Empty);
                    }
                    else
                    {
                        oRequest.Credentials = CredentialCache.DefaultCredentials;
                    }
                    StreamReader sr = new StreamReader(oRequest.GetResponse().GetResponseStream(), System.Text.Encoding.Default);
                    string line = sr.ReadToEnd();
                    sr.Close();
                    if (line.IndexOf("LAN口状态") > -1)//登录成功
                    {
                        return "success";
                    }
                    else
                    {
                        return "fail";
                    }
                }
            }catch(Exception ex)
            {
                return "fial:"+ex.Message;
            }
            return "fail";
        }
        #endregion

        #region 宽带换ip

        #endregion

        public static string getIp()
        {
            System.Net.IPHostEntry myEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            string ipAddress = myEntry.AddressList[0].ToString();
            return ipAddress;
        }
    }
}
