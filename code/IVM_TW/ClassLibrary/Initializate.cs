using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    
    using System.Net;
    using System.Collections;
    public class Initializate
    {
   
        List<string> aLinkList =new List<string>()
                                {"https://user.lu.com/user/lpreg?action=se_lu&seo=se_lu&marketFeedbackCode=eyJ1cmxUaWQiOiItNzc5MCIsInVybFNvdXJjZSI6IjE4MzgyIn0" ,
                                  "https://e.lufunds.com/jijin/detail?productId=2278773",
                                "https://list.lu.com/list/productDetail/fa?riskFlag=false&productId=30033843"} ;
        public ProjectList mProjectList  = new ProjectList();
        //从若干网页中筛选出所有项目的信息，生成总项目列表项
        public  Initializate()
        {
            SetProjectList();
        }
        
        private void SetProjectList()
        {
            int intProjectListIndex = 0;
            for (int i = 0; i < aLinkList.Count; i++)
            {
                string strTemp = LoadDataFromWeb(aLinkList[i]);
                Project mProject;
                if (strTemp.Length != 0)
                {
                    mProject = SetProject(strTemp, intProjectListIndex);
                    mProject.strLink = strTemp;
                    this.mProjectList.Add(mProject);
                }

            }
            
        }


        //获取网页内容
        public  string LoadDataFromWeb(string url)
        {
            WebClient ourSearchWeb = new WebClient();
            ourSearchWeb.Credentials = CredentialCache.DefaultCredentials;
            Byte[] webPageData = ourSearchWeb.DownloadData(url);
            string webPageHtml = Encoding.UTF8.GetString(webPageData);
            Console.Write(webPageHtml);
            return webPageHtml;
        }

        //从网页内容中整理出项目信息，返回一条项目信息
        private Project SetProject(string strWebContent,int intIndex)
        {
            Project a = new Project(intIndex);
            //筛选算法还没有实现
            return a;
        }



    }
}
