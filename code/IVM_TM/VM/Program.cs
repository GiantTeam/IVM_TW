using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Reflection;
using log4net;
using VM;

namespace IVM_TM
{
    static class Program
    {
           /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]

        public static void Main(string[] args)
        {
            //Application.Run(new MainForm());
            //创建日志记录组件实例
            ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            //记录错误日志
            log.Error("error", new Exception("发生了一个异常"));
            //记录严重错误
            log.Fatal("fatal", new Exception("发生了"));
            //记录一般信息
            log.Info("info");
            //记录调试信息
            log.Debug("debug");
            //记录警告信息
            log.Warn("warn");
            Console.WriteLine("日志记录完毕。");
            Console.Read();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
