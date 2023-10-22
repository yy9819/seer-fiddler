using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using seer_fiddler.core;


namespace seer_fiddler
{
    internal static class Program
    {


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Win32Util.FindWindowByWindowName("啦啦啦赛尔号登录器") == IntPtr.Zero)
            {
                MessageBox.Show("本程序不可单独运行！");
            }else if(Win32Util.FindWindowByWindowName("seerFiddler") == IntPtr.Zero)
            {
                Application.Run(new FiddlerMainForm());
            }
        }
    }
}
