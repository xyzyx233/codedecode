using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace codedecode
{
    public partial class check : Form
    {
        public bool closeflag = true;
        public bool isok = false;
        public check()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = textBox1.Text;
            Dcode d = new Dcode();
            Console.WriteLine("输入的动态密码："+code);
            //code != ""&&
            if (d.check(code)==true)
            {
                closeflag = false;
                isok = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("动态密码有问题", "密码错误");
                //this.Close();
            }
            
        }
    }
}
