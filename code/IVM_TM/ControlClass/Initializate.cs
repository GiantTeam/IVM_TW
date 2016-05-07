using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClass;

namespace ControlClass
{

    using System.Net;
    using System.Collections;
    public class Initializate
    {

        List<string> aLinkList = new List<string>() { "https://list.lu.com/list/p2p" };

        public static ProjectList mProjectList = new ProjectList();//项目列表
        //从若干网页中筛选出所有项目的信息，生成总项目列表项
        public Initializate()
        {
            SetProjectList();
        }

        private void SetProjectList()
        {
            int intProjectListIndex = 0;
            for (int i = 0; i < aLinkList.Count; i++)
            {
                intProjectListIndex = i;
                string strTemp = LoadDataFromWeb(aLinkList[i]);
                if (strTemp.Length != 0)
                {
                    SetProject(strTemp, intProjectListIndex);

                    // this.mProjectList.Add(mProject);
                }

            }

        }


        //获取网页内容
        public string LoadDataFromWeb(string url)
        {
            WebClient ourSearchWeb = new WebClient();
            ourSearchWeb.Credentials = CredentialCache.DefaultCredentials;
            Byte[] webPageData = ourSearchWeb.DownloadData(url);
            string webPageHtml = Encoding.UTF8.GetString(webPageData);
            Console.Write(webPageHtml);
            return webPageHtml;
        }

        //从网页内容中整理出项目信息，返回一条项目信息
        private void SetProject(string strWebContent, int intProjectListIndex)
        {
            int start = 0;
            int end = 0;
            int id = 0;
            if (intProjectListIndex == 0)
            {

                int intIndexOflink = 0;
                if (intIndexOflink == 0)
                {
                    string projectStrLink = "https://list.lu.com";
                    while (true)
                    {

                        if (start == -1)
                        {
                            break;
                        }
                        Project project = new Project(id++);

                        start = strWebContent.IndexOf("<dt class=\"product-name\">", end);
                        if (start == -1)
                        {
                            break;
                        }
                        start = strWebContent.IndexOf("<a href='", start) + "<a href='".Length;
                        end = strWebContent.IndexOf("' target", start);
                        string s = strWebContent.Substring(start, end - start);
                        projectStrLink += s;
                        project.strLink = projectStrLink;

                        start = strWebContent.IndexOf("title=\"", end) + "title =\"".Length;
                        end = strWebContent.IndexOf("\">", start);
                        string projectName = strWebContent.Substring(start, end - start);
                        project.name = projectName;

                        start = strWebContent.IndexOf("<p class=\"num-style\">", end) + "<p class=\"num-style\">".Length;
                        end = strWebContent.IndexOf("%</p>", start);
                        Double projectRate = Convert.ToDouble(strWebContent.Substring(start, end - start));
                        project.dblRate = projectRate;

                        start = strWebContent.IndexOf("<p>", end) + "<p>".Length;
                        end = strWebContent.IndexOf("</p>", start);
                        string projectTime = strWebContent.Substring(start, end - start).Trim();
                        project.intTime = projectTime;

                        start = strWebContent.IndexOf("<em class=\"num-style\">", end) + "<em class=\"num-style\">".Length;
                        end = strWebContent.IndexOf("</em>", start);
                        Double projectMoney = Convert.ToDouble(strWebContent.Substring(start, end - start));
                        project.dblMoney = projectMoney;

                        mProjectList.Add(project);

                    }
                }
            }

        }



    }
}
