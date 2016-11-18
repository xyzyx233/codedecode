using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace codedecode
{
    class encode
    {
        private string filepath;
        private Boolean isFile=false;
        private byte[] buffer;
        private byte[] desresult;
        private string result;
        private string outpath;
        public encode(string name,string outname)
        {
            filepath = name;
            outpath = outname;
        }
        private void judgefile()
        {
            if (File.Exists(filepath) && Directory.Exists(outpath))
            {
                isFile = true;
            }
            //else
            //{
            //    MessageBox.Show("文件类型有问题！", "encode错误");
            //}
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
        private Boolean encodefile()
        {
            if (!readfile())
                return false;
            byte[] btKey = Encoding.UTF8.GetBytes("ericxXin");

            byte[] btIV = Encoding.UTF8.GetBytes("Sg234g31");

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            using (MemoryStream ms = new MemoryStream())
            {
                byte[] inData = buffer;
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(btKey, btIV), CryptoStreamMode.Write))
                {
                    cs.Write(inData, 0, inData.Length);
                    cs.FlushFinalBlock();
                }
                desresult = ms.ToArray();
            }
            return true;
        }
        public Boolean finalencodefile()
        {
            if (!encodefile())
                return false;
            result = Convert.ToBase64String(desresult);
            byte[] myByte = System.Text.Encoding.UTF8.GetBytes(result);
            string path = outpath + "\\encode.xin";
            using (FileStream fsWrite = new FileStream(path, FileMode.Append))
            {
                fsWrite.Write(myByte, 0, myByte.Length);
            };
            Console.WriteLine(path);
            MessageBox.Show("已经变成一堆狗屎了呢", "完成~~");
            return true;
        }
    }
}
