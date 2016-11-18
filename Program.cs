using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace codedecode
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            check form2 = new check();
            form2.ShowDialog();  //模式窗口，先运行Form1的作用
            if (form2.closeflag == false && form2.isok == true)
            {
                Application.Run(new Form1());
            }
            else
            {
                return;
            }
        }
    }
}
