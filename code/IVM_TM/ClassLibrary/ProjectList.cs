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

        //Use Facade Pattern
        ArrayList proArray = new ArrayList();
        
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
