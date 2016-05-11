using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClass;

namespace ControlClass
{
    class AddProjectList
    {
        public static int currentPage = 1;
        public static int PageCount = 1;
        public static ProjectList addProject(ProjectList mProjectList,string strWebContent,string projectStrLink)
        {
            int start = 0;
            int end = 0;
            int id = 0;
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
                end = strWebContent.IndexOf("</p>", start);
                project.dblRate = strWebContent.Substring(start, end - start);

                start = strWebContent.IndexOf("<p>", end) + "<p>".Length;
                end = strWebContent.IndexOf("</p>", start);
                string projectTime = strWebContent.Substring(start, end - start).Trim();
                project.intTime = projectTime;

                start = strWebContent.IndexOf("<em class=\"num-style\">", end) + "<em class=\"num-style\">".Length;
                end = strWebContent.IndexOf("</em>", start);
                project.dblMoney = strWebContent.Substring(start, end - start);
   
                mProjectList.Add(project);
            }
        /*    end = 0;
            start = strWebContent.IndexOf("id=\"currentPage\" value=\"", end) + "id=\"currentPage\" value=\"".Length;
            end = strWebContent.IndexOf("\"> ", start);
            currentPage = Int32.Parse(strWebContent.Substring(start, end - start));

            start = strWebContent.IndexOf("id=\"pageCount\" value=\"", end) + "id=\"pageCount\" value=\"".Length;
            end = strWebContent.IndexOf("\"> ", start);
            PageCount = Int32.Parse(strWebContent.Substring(start, end - start));*/
            return mProjectList;
        }
    }
}
