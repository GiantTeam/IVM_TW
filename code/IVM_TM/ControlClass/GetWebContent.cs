using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlClass
{
    public class GetWebContent
    {
        public static Boolean mark = false;
        //获取网页内容
        public static string LoadDataFromWeb(string url)
        {
          string webPageHtml = "";
            try {
                WebClient ourSearchWeb = new WebClient();
                ourSearchWeb.Credentials = CredentialCache.DefaultCredentials;
                Byte[] webPageData = ourSearchWeb.DownloadData(url);
                webPageHtml = Encoding.UTF8.GetString(webPageData);
                mark = true;
            } catch (Exception e)
            {
                MessageBox.Show("网络异常");
                mark = false;
            }
           // Console.Write(webPageHtml);
            return webPageHtml;            
        }
    }
}
