using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlClass
{
    public class GetWebContent
    {
        //获取网页内容
        public static string LoadDataFromWeb(string url)
        {
            WebClient ourSearchWeb = new WebClient();
            ourSearchWeb.Credentials = CredentialCache.DefaultCredentials;
           Byte[] webPageData = ourSearchWeb.DownloadData(url);
            string webPageHtml = Encoding.UTF8.GetString(webPageData);
            Console.Write(webPageHtml);
            return webPageHtml;            
        }
    }
}
