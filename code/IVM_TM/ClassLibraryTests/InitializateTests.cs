using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClass.Tests
{
    using System.IO;
    [TestClass()]    
    public class InitializateTests
    {
        [TestMethod()]
        public void LoadDataFromWebTest()
        {
            Initializate k = new Initializate();
            string strSample =k.LoadDataFromWeb("https://e.lufunds.com/jijin/detail?productId=2278773");           
            StreamWriter sw = new StreamWriter("D:\\data.txt");
            sw.Write(strSample);
            sw.Close();
            Assert.IsTrue(strSample.Length > 0);         
            //  Assert.Fail();
        }
    }
}