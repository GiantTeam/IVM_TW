using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityClass
{
    using System.Collections;
    public class ProjectList
    {

        ArrayList proArray = new ArrayList();

        //Use Facade Pattern
        public Project getProject(int i)
        {
            return (Project)proArray[i];
        }
        // int a = proArray[3].id;
        public void Add(Project mProject)
        {
            proArray.Add(mProject);
        }
        public int Count()
        {
            return proArray.Count;
        }
        public void Sort()
        {
            proArray.Sort();
        }

    }

}

