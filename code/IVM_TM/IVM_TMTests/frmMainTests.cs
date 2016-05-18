using Microsoft.VisualStudio.TestTools.UnitTesting;
using VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM.Tests
{
    [TestClass()]
    public class frmMainTests
    {
        [TestMethod()]
        public void mmuImport_ClickTest()
        {
            frmMain frmMainTest = new frmMain();
            Object a = new object();
            EventArgs b = new EventArgs();

            frmMainTest.mmuImport_Click(a,b);
            bool Actual = true;
            bool Result = true;
            Assert.AreEqual(Actual, Result);

        }
    }
}