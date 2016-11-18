using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace codedecode
{
    class decode
    {
        private string filepath;
        private string outpath;
        private Boolean isFile = false;
        private byte[] buffer;
        private byte[] myByte;
        public decode(string name,string outname)
        {
            filepath = name;
            outpath = outname;
        }
        private void judgefile()
        {
            string[] sArray = filepath.Split('.');
            if (sArray[1]=="xin"&& Directory.Exists(outpath))
            //if (Path.GetExtension(filepath)=="xin")
            {
                isFile = true;
            }
            else
            {
                MessageBox.Show("文件类型有问题！", "decode错误");
            }
        }
        private Boolean readfile()
        {
            judgefile();
            if (!isFile)
                return false;
            FileInfo fi = new FileInfo(filepath);
            long len = fi.Length;
            FileStream fs = new FileStream(filepath, FileMode.Open);
            buffer = new byte[len];
            fs.Read(buffer, 0, (int)len);
            fs.Close();
            return true;
        }
        private Boolean decodefile()
        {
            if (!readfile())
                return false;
            byte[] btKey = Encoding.UTF8.GetBytes("ericxXin");

            byte[] btIV = Encoding.UTF8.GetBytes("Sg234g31");

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            using (MemoryStream ms = new MemoryStream())
            {
                byte[] inData = Convert.FromBase64String(Encoding.UTF8.GetString(buffer));
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(btKey, btIV), CryptoStreamMode.Write))
                {
                    cs.Write(inData, 0, inData.Length);

                    cs.FlushFinalBlock();
                }

                myByte = ms.ToArray();
                return true;
            }
        }
        public Boolean finaldecodefile()
        {
            if (!decodefile())
                return false;
            string path = outpath + "\\decode.rar";
            using (FileStream fsWrite = new FileStream(path, FileMode.Append))
            {
                fsWrite.Write(myByte, 0, myByte.Length);
            };
            File.Delete(filepath);
            Console.WriteLine(path);
            MessageBox.Show("可以正常的解压看了呢", "完成~~");
            return true;
        }
    }
}
