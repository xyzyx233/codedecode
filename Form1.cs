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
    public partial class Form1 : Form
    {
        private string name;
        private string outname;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.filenameoutput.SelectedText = "";
                this.filenameoutput.SelectedText = dialog.FileName;
                name = dialog.FileName;
                Console.WriteLine(name);
            }
        }

        private void encode_Click(object sender, EventArgs e)
        {
            if (name != "" && outname != "")
            {
                encode en = new encode(name,outname);
                en.finalencodefile();
            }
            else
            {
                MessageBox.Show("hentai", "有路径为空！");
            }

        }

        private void decode_Click(object sender, EventArgs e)
        {
            if(name != "" && outname != "")
            {
                decode d = new decode(name,outname);
                d.finaldecodefile();
            }
            else
            {
                MessageBox.Show("hentai", "有路径为空！");
            }
        }

        private void outputpath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.output.SelectedText = "";
                this.output.SelectedText = dialog.SelectedPath;
                outname = dialog.SelectedPath;
                Console.WriteLine(outname);
            }
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("hentai", "是否开启里模式？", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dr == DialogResult.Yes)

            {

                encode.Enabled = true;

            }
            
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
